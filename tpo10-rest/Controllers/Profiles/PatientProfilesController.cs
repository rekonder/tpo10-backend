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
    [RoutePrefix("api/PatientProfiles")]
    //[Authorize(Roles = "Patient, Administrator")]
    public class PatientProfilesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public PatientProfilesController()
        {

        }

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

        //// PUT: api/PatientProfiles/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutPatientProfile(Guid id, PatientProfile patientProfile)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != patientProfile.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(patientProfile).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PatientProfileExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/PatientProfiles/{userId}
        [AllowAnonymous]
        [Route("{userId}")]
        [ResponseType(typeof(PatientProfile))]
        public async Task<IHttpActionResult> PostPatientProfile(string userId, PatientProfileBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await db.Users.Where(e => e.Id == userId).FirstOrDefaultAsync() as Patient;
            var post = await db.Posts.Where(e => e.PostNumber == model.PostNumber).FirstOrDefaultAsync();
            var contactPost = await db.Posts.Where(e => e.PostNumber == model.ContactPostNumber).FirstOrDefaultAsync();

            if (user == null || post == null || contactPost == null)
            {
                return BadRequest();
            }

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var contact = new PatientProfileContact
                    {
                        FirstName = model.ContactFirstName,
                        LastName = model.ContactLastName,
                        Address = model.ContactAddress,
                        Post = contactPost,
                        Telephone = model.ContactTelephone,
                        FamilyRelationship = model.ContactFamilyRelationship
                    };
                    db.PatientProfileContacts.Add(contact);
                    await db.SaveChangesAsync();

                    var profile = new PatientProfile
                    {
                        HealthInsuranceNumber = model.HealthInsuranceNumber,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Address = model.Address,
                        Post = post,
                        Telephone = model.Telephone,
                        Gender = model.Gender,
                        BirthDate = model.BirthDate,
                        PatientProfileContact = contact
                    };
                    db.Profiles.Add(profile);
                    await db.SaveChangesAsync();

                    user.PatientProfiles.Add(profile);
                    await db.SaveChangesAsync();

                    transaction.Commit();
                    return Ok(profile);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        //// DELETE: api/PatientProfiles/5
        //[ResponseType(typeof(PatientProfile))]
        //public async Task<IHttpActionResult> DeletePatientProfile(Guid id)
        //{
        //    PatientProfile patientProfile = await db.Profiles.FindAsync(id) as PatientProfile;
        //    if (patientProfile == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Profiles.Remove(patientProfile);
        //    await db.SaveChangesAsync();

        //    return Ok(patientProfile);
        //}

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