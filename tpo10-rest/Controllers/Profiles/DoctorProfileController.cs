using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using tpo10_rest.Models;

namespace tpo10_rest.Controllers.Profiles
{
    [RoutePrefix("api/DoctorProfile")]
    //[Authorize(Roles = "Doctor, Administrator")]
    public class DoctorProfileController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/DoctorProfile
        public IQueryable<DoctorProfile> GetProfiles()
        {
            return db.Profiles.OfType<DoctorProfile>();
        }

        // GET: api/DoctorProfile/5
        [Authorize(Roles = "Doctor")]
        [HttpGet]
        [Route("{userId}")]
        [ResponseType(typeof(DoctorProfileViewModel))]
        public IHttpActionResult GetDoctorProfile(string userId)
        {
            Doctor user = db.Users.Find(userId) as Doctor;
            if (user == null)
            {
                return NotFound();
            }
            DoctorProfile doctorProfile = user.DoctorProfile;
            if (doctorProfile == null)
            {
                return NotFound();
            }
            HelperHealthCareProvider care = new HelperHealthCareProvider();
            care.Key = doctorProfile.HealthCareProvider.Key;
            care.Name = doctorProfile.HealthCareProvider.Name;
            var profile = new DoctorProfileViewModel
            {
                Id = doctorProfile.Id,
                FirstName = doctorProfile.FirstName,
                LastName = doctorProfile.LastName,
                Telephone = doctorProfile.Telephone,
                DoctorKey = doctorProfile.DoctorKey,
                PatientNumber = doctorProfile.PatientNumber,
                CurrentPatientNumber = doctorProfile.CurrentPatientNumber,
                DocOrDentist = doctorProfile.DocOrDentist,
                HealthCareProvider = care,
                Email = user.Email
            };

            return Ok(profile);
        }

        // PUT: api/DoctorProfile/5
        [Authorize(Roles = "Doctor")]
        [HttpPut]
        [Route("{doctorId}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDoctorProfile(Guid doctorId, DoctorProfileBindingModel doctorProfile)
        {
            var userId = User.Identity.GetUserId();
            if (User.IsInRole("Doctor") && userId != doctorId.ToString())
                return Unauthorized();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await db.Users.Where(e => e.Id == doctorId.ToString()).FirstOrDefaultAsync() as Doctor;
            var healthCareProvider = await db.HealthCareProviders.Where(e => e.Key == doctorProfile.HealthCareProviderNumber).FirstOrDefaultAsync();
            var profile = db.Profiles.Find(doctorProfile.Id) as DoctorProfile;
            if (user.DoctorProfile.Id != doctorProfile.Id || user.DoctorProfile.CurrentPatientNumber > doctorProfile.PatientNumber || (user.Email != doctorProfile.Email && db.Users.Any(e => e.Email == doctorProfile.Email)))
            {
                return BadRequest();
            }
            if (user == null || healthCareProvider == null || profile == null)
                return NotFound();

            if (doctorProfile.DoctorKey != profile.DoctorKey &&  (db.Profiles.OfType<NurseProfile>().Any(e => e.NurseKey == doctorProfile.DoctorKey) || db.Profiles.OfType<DoctorProfile>().Any(e => e.DoctorKey == doctorProfile.DoctorKey)))
                return BadRequest("Doctor or nurse with that key already exsists");


            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    profile.DoctorKey = doctorProfile.DoctorKey;
                    profile.FirstName = doctorProfile.FirstName;
                    profile.LastName = doctorProfile.LastName;
                    profile.Telephone = doctorProfile.Telephone;
                    profile.PatientNumber = doctorProfile.PatientNumber;
                    profile.DocOrDentist = doctorProfile.DocOrDentist;
                    profile.HealthCareProvider = healthCareProvider;

                    db.Entry(profile).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    user.Email = doctorProfile.Email;
                    user.UserName = doctorProfile.Email;


                    db.Entry(user).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    transaction.Commit();
                    return StatusCode(HttpStatusCode.NoContent);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            
        }

        // POST: api/DoctorProfile/{doctorId}
        [Authorize(Roles = "Doctor, Administrator")]
        [HttpPost]
        [Route("{doctorId}")]
        [ResponseType(typeof(DoctorProfile))]
        public async Task<IHttpActionResult> PostDoctorProfile(string doctorId, DoctorProfileBindingModel doctorProfile)
        {
            var userId = User.Identity.GetUserId();
            if (User.IsInRole("Doctor") && userId != doctorId)
                return Unauthorized();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await db.Users.Where(e => e.Id == doctorId).FirstOrDefaultAsync() as Doctor;
            var healthCareProvider = await db.HealthCareProviders.Where(e => e.Key == doctorProfile.HealthCareProviderNumber).FirstOrDefaultAsync();

            if(user == null || healthCareProvider == null)
                return NotFound();

            if (db.Profiles.OfType<NurseProfile>().Any(e => e.NurseKey == doctorProfile.DoctorKey) || db.Profiles.OfType<DoctorProfile>().Any(e => e.DoctorKey == doctorProfile.DoctorKey))
                return BadRequest("Doctor or nurse with that key already exsists");

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var docProfile = new DoctorProfile
                    {
                        DoctorKey = doctorProfile.DoctorKey,
                        FirstName = doctorProfile.FirstName,
                        LastName = doctorProfile.LastName,
                        Telephone = doctorProfile.Telephone,
                        PatientNumber = doctorProfile.PatientNumber,
                        DocOrDentist = doctorProfile.DocOrDentist,
                        CurrentPatientNumber = 0,
                        HealthCareProvider = healthCareProvider
                    };

                    db.Profiles.Add(docProfile);
                    await db.SaveChangesAsync();

                    user.Email = doctorProfile.Email;
                    user.DoctorProfile = docProfile;
                    await db.SaveChangesAsync();

                    transaction.Commit();
                    return Ok(docProfile);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        // DELETE: api/DoctorProfile/5
       /* [ResponseType(typeof(DoctorProfile))]
        public async Task<IHttpActionResult> DeleteDoctorProfile(Guid id)
        {
            DoctorProfile doctorProfile = await db.Profiles.FindAsync(id) as DoctorProfile;
            if (doctorProfile == null)
            {
                return NotFound();
            }

            db.Profiles.Remove(doctorProfile);
            await db.SaveChangesAsync();

            return Ok(doctorProfile);
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoctorProfileExists(Guid id)
        {
            return db.Profiles.Count(e => e.Id == id) > 0;
        }
        [AllowAnonymous]
        [AcceptVerbs("OPTIONS")]
        public HttpResponseMessage Options()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Headers", "*");
            response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            return response;
        }
    }
}