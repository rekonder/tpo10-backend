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
        [ResponseType(typeof(DoctorProfile))]
        public async Task<IHttpActionResult> GetDoctorProfile(Guid id)
        {
            DoctorProfile doctorProfile = await db.Profiles.FindAsync(id) as DoctorProfile;
            if (doctorProfile == null)
            {
                return NotFound();
            }

            return Ok(doctorProfile);
        }

        // PUT: api/DoctorProfile/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDoctorProfile(Guid id, DoctorProfile doctorProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doctorProfile.Id)
            {
                return BadRequest();
            }

            db.Entry(doctorProfile).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorProfileExists(id))
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

            if( db.Profiles.OfType<DoctorProfile>().Any(e => e.DoctorKey == doctorProfile.DoctorKey))
                return BadRequest("Doctor with that key already exsists");

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
                        CurrectPatientNumber = 0,
                        HealthCareProvider = healthCareProvider
                    };

                    db.Profiles.Add(docProfile);
                    await db.SaveChangesAsync();

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
        [ResponseType(typeof(DoctorProfile))]
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
        }

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