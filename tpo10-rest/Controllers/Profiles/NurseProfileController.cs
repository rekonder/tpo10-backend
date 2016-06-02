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
    [RoutePrefix("api/NurseProfile")]
    public class NurseProfileController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/NurseProfile
        public async Task<IHttpActionResult> GetProfiles()
        {
            return Ok(db.Profiles.OfType<NurseProfile>().ToList());
        }

        // GET: api/NurseProfile/5
        [ResponseType(typeof(NurseProfile))]
        public async Task<IHttpActionResult> GetNurseProfile(Guid id)
        {
            NurseProfile nurseProfile = await db.Profiles.FindAsync(id) as NurseProfile;
            if (nurseProfile == null)
            {
                return NotFound();
            }

            return Ok(nurseProfile);
        }

        // PUT: api/NurseProfile/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNurseProfile(Guid id, NurseProfile nurseProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nurseProfile.Id)
            {
                return BadRequest();
            }

            db.Entry(nurseProfile).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NurseProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/NurseProfile
        [Authorize(Roles = "Nurse, Administrator")]
        [HttpPost]
        [Route("{nurseId}")]
        [ResponseType(typeof(NurseProfile))]
        public async Task<IHttpActionResult> PostNurseProfile(string nurseId, NurseProfileBindingModel nurseProfile)
        {
            var userId = User.Identity.GetUserId();
            if (User.IsInRole("Nurse") && userId != nurseId)
                return Unauthorized();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await db.Users.Where(e => e.Id == nurseId).FirstOrDefaultAsync() as Nurse;
            var healthCareProvider = await db.HealthCareProviders.Where(e => e.Key == nurseProfile.HealthCareProviderNumber).FirstOrDefaultAsync();

            if (user == null || healthCareProvider == null)
                return NotFound();

            if (db.Profiles.OfType<NurseProfile>().Any(e => e.NurseKey == nurseProfile.NurseKey) || db.Profiles.OfType<DoctorProfile>().Any(e => e.DoctorKey == nurseProfile.NurseKey))
                return BadRequest("Doctor or nurse with that key already exsists");

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var nurProfile = new NurseProfile
                    {
                        NurseKey = nurseProfile.NurseKey,
                        FirstName = nurseProfile.FirstName,
                        LastName = nurseProfile.LastName,
                        Telephone = nurseProfile.Telephone,
                        HealthCareProvider = healthCareProvider
                    };

                    db.Profiles.Add(nurProfile);
                    await db.SaveChangesAsync();

                    user.NurseProfile = nurProfile;
                    await db.SaveChangesAsync();

                    transaction.Commit();
                    return Ok(nurProfile);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        // DELETE: api/NurseProfile/5
        [ResponseType(typeof(NurseProfile))]
        public async Task<IHttpActionResult> DeleteNurseProfile(Guid id)
        {
            NurseProfile nurseProfile = await db.Profiles.FindAsync(id) as NurseProfile;
            if (nurseProfile == null)
            {
                return NotFound();
            }

            db.Profiles.Remove(nurseProfile);
            await db.SaveChangesAsync();

            return Ok(nurseProfile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NurseProfileExists(Guid id)
        {
            return db.Profiles.Count(e => e.Id == id) > 0;
        }
    }
}