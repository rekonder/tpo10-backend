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
    public class NurseProfileController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/NurseProfile
        public IQueryable<NurseProfile> GetProfiles()
        {
            return db.Profiles.OfType<NurseProfile>();
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
        [ResponseType(typeof(NurseProfile))]
        public async Task<IHttpActionResult> PostNurseProfile(NurseProfile nurseProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profiles.Add(nurseProfile);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NurseProfileExists(nurseProfile.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nurseProfile.Id }, nurseProfile);
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