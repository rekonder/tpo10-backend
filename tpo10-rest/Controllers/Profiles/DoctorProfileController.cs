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
    [Authorize(Roles = "Doctor, Administrator")]
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

        // POST: api/DoctorProfile
        [ResponseType(typeof(DoctorProfile))]
        public async Task<IHttpActionResult> PostDoctorProfile(DoctorProfile doctorProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profiles.Add(doctorProfile);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DoctorProfileExists(doctorProfile.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = doctorProfile.Id }, doctorProfile);
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
    }
}