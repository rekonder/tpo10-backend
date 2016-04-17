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
    [Authorize(Roles = "Patient, Administrator")]
    public class PatientProfilesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PatientProfiles
        public IQueryable<PatientProfile> GetProfiles()
        {
            return db.Profiles.OfType<PatientProfile>();
        }

        // GET: api/PatientProfiles/5
        [ResponseType(typeof(PatientProfile))]
        public async Task<IHttpActionResult> GetPatientProfile(Guid id)
        {
            PatientProfile patientProfile = await db.Profiles.FindAsync(id) as PatientProfile;
            if (patientProfile == null)
            {
                return NotFound();
            }

            return Ok(patientProfile);
        }

        // PUT: api/PatientProfiles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPatientProfile(Guid id, PatientProfile patientProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patientProfile.Id)
            {
                return BadRequest();
            }

            db.Entry(patientProfile).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientProfileExists(id))
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

        // POST: api/PatientProfiles
        [ResponseType(typeof(PatientProfile))]
        public async Task<IHttpActionResult> PostPatientProfile(PatientProfile patientProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profiles.Add(patientProfile);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PatientProfileExists(patientProfile.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = patientProfile.Id }, patientProfile);
        }

        // DELETE: api/PatientProfiles/5
        [ResponseType(typeof(PatientProfile))]
        public async Task<IHttpActionResult> DeletePatientProfile(Guid id)
        {
            PatientProfile patientProfile = await db.Profiles.FindAsync(id) as PatientProfile;
            if (patientProfile == null)
            {
                return NotFound();
            }

            db.Profiles.Remove(patientProfile);
            await db.SaveChangesAsync();

            return Ok(patientProfile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientProfileExists(Guid id)
        {
            return db.Profiles.Count(e => e.Id == id) > 0;
        }
    }
}