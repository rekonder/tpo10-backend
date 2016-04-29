using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using tpo10_rest.Models;

namespace tpo10_rest.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "*" });
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET", "POST", "PUT", "DELETE", "OPTIONS" });

            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            var db = context.OwinContext.Get<ApplicationDbContext>();

            var user = await userManager.FindByNameAsync(context.UserName);

            if (user == null)
            {
                context.SetError("invalid_grant", "Napačno uporabniško ime ali geslo.");
                return;
            }

            if (await userManager.IsLockedOutAsync(user.Id))
            {
                context.SetError("invalid_grant", "Uporabniški račun je bil zaklenjen za 5 minut.");
                return;
            }

            var check = await userManager.CheckPasswordAsync(user, context.Password);

            if (!check)
            {
                await userManager.AccessFailedAsync(user.Id);
                context.SetError("invalid_grant", "Napačno uporabniško ime ali geslo.");
                return;
            }

            if (!user.EmailConfirmed)
            {
                context.SetError("invalid_grant", "Uporabniški račun še ni aktiviran.");
                return;
            }

            await userManager.ResetAccessFailedCountAsync(user.Id);

            string lastLogin = "";
            string lastLoginIp = "";
            if (user.LastLogin.HasValue)
            {
                lastLogin = user.LastLogin.Value.ToUniversalTime().ToString("o");
            }
            if (user.LastLoginIp != null)
            {
                lastLoginIp = user.LastLoginIp;
            }
            user.LastLogin = DateTime.UtcNow;
            user.LastLoginIp = context.Request.RemoteIpAddress;
            await db.SaveChangesAsync();

            string role = (await userManager.GetRolesAsync(user.Id)).FirstOrDefault();
            if(role == null)
            {
                role = "";
            }

            string profileCount = "0";
            switch (role)
            {
                case nameof(Administrator):
                    var a = db.Users.Find(user.Id) as Administrator;
                    if (a != null)
                        profileCount = "0";
                    break;
                case nameof(Doctor):
                    var d = db.Users.Find(user.Id) as Doctor;
                    if (d != null && d.DoctorProfile != null)
                        profileCount = "1";
                    break;
                case nameof(Nurse):
                    var n = db.Users.Find(user.Id) as Nurse;
                    if (n != null && n.NurseProfile != null)
                        profileCount = "1";
                    break;
                case nameof(Patient):
                    var p = db.Users.Find(user.Id) as Patient;
                    if (p != null) profileCount = p.PatientProfiles.LongCount().ToString();                        
                    break;
                default: break;
            }

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
               OAuthDefaults.AuthenticationType);
            ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
                CookieAuthenticationDefaults.AuthenticationType);

            AuthenticationProperties properties = CreateProperties(user.Id, user.Email,  role, lastLogin, lastLoginIp, profileCount);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userId, string email, string role, string lastLogin, string lastLoginIp, string profileCount)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userId", userId },
                { "email", email },
                { "role", role },
                { "lastLogin", lastLogin },
                { "lastLoginIp", lastLoginIp },
                { "profileCount", profileCount }
            };
            return new AuthenticationProperties(data);
        }
    }
}