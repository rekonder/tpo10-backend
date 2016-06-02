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
    [RoutePrefix("api/PatientProfiles")]
    //[Authorize(Roles = "Patient, Administrator")]
    public class PatientProfilesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PatientProfiles/Account/{userId}
        [AllowAnonymous]
        [HttpGet]
        [Route("Account/{userId}")]
        [ResponseType(typeof(List<PatientProfileViewModel>))]
        public IHttpActionResult GetPatientProfiles(string userId)
        {
            var user = db.Users.Find(userId) as Patient;
            if(user == null)
            {
                return NotFound();
            }

            var patientProfiles = user.PatientProfiles.ToList();
            var profiles = new List<PatientProfileViewModel>();
            foreach (var patientProfile in patientProfiles)
            {
                var profile = new PatientProfileViewModel
                {
                    Id = patientProfile.Id,

                    HealthInsuranceNumber = patientProfile.HealthInsuranceNumber,
                    FirstName = patientProfile.FirstName,
                    LastName = patientProfile.LastName,
                    Address = patientProfile.Address,
                    PostNumber = patientProfile.Post.PostNumber,
                    Telephone = patientProfile.Telephone,
                    Gender = patientProfile.Gender,
                    BirthDate = patientProfile.BirthDate,

                    ContactFirstName = patientProfile.PatientProfileContact.FirstName,
                    ContactLastName = patientProfile.PatientProfileContact.LastName,
                    ContactAddress = patientProfile.PatientProfileContact.Address,
                    ContactPostNumber = patientProfile.PatientProfileContact.Post.PostNumber,
                    ContactTelephone = patientProfile.PatientProfileContact.Telephone,
                    ContactFamilyRelationship = patientProfile.PatientProfileContact.FamilyRelationship,

                    IsGuardian = patientProfile.IsGuardian,
                    //ContactProfile = patientProfile.PatientProfileContact,

                    PersonalDoctor = patientProfile.PersonalDoctor,
                    DentistDoctor = patientProfile.DentistDoctor

                };

                profiles.Add(profile);
            }

            return Ok(profiles);
        }

        // GET: api/PatientProfiles/{patinetId}
        [AllowAnonymous]
        [HttpGet]
        [Route("{patientId}")]
        [ResponseType(typeof(PatientProfileViewModel))]
        public IHttpActionResult GetPatientProfile(Guid patientId)
        {
            var patientProfile = db.PatientProfiles.Find(patientId);
            if (patientProfile == null)
            {
                return NotFound();
            }

            var profile = new PatientProfileViewModel
            {
                Id = patientProfile.Id,

                HealthInsuranceNumber = patientProfile.HealthInsuranceNumber,
                FirstName = patientProfile.FirstName,
                LastName = patientProfile.LastName,
                Address = patientProfile.Address,
                PostNumber = patientProfile.Post.PostNumber,
                Telephone = patientProfile.Telephone,
                Gender = patientProfile.Gender,
                BirthDate = patientProfile.BirthDate,

                ContactFirstName = patientProfile.PatientProfileContact.FirstName,
                ContactLastName = patientProfile.PatientProfileContact.LastName,
                ContactAddress = patientProfile.PatientProfileContact.Address,
                ContactPostNumber = patientProfile.PatientProfileContact.Post.PostNumber,
                ContactTelephone = patientProfile.PatientProfileContact.Telephone,
                ContactFamilyRelationship = patientProfile.PatientProfileContact.FamilyRelationship,

                PersonalDoctor = patientProfile.PersonalDoctor,
                DentistDoctor = patientProfile.DentistDoctor
            };
            
            return Ok(profile);
        }

        // PUT: api/PatientProfiles/{patientProfileId}
        [AllowAnonymous]
        [HttpPut]
        [Route("{patientProfileId}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPatientProfile(Guid patientProfileId, PatientProfileBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (patientProfileId != model.Id)
            {
                return BadRequest();
            }

            var profile = db.Profiles.Find(patientProfileId) as PatientProfile;
            var profileContact = profile.PatientProfileContact;
            var profilePost = db.Posts.Find(model.PostNumber);
            var profileContactPost = db.Posts.Find(model.ContactPostNumber);

            if(profile == null || profilePost == null || profileContactPost == null)
            {
                return NotFound();
            }

            // TODO - preverjanje duplikatov
            //if (db.Profiles.OfType<PatientProfile>().Where(e => e.HealthInsuranceNumber == model.HealthInsuranceNumber).Count() > 0)
            //{
            //    return BadRequest("Ta ZZZS številka že obstaja.");
            //}

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    profileContact.FirstName = model.ContactFirstName;
                    profileContact.LastName = model.ContactLastName;
                    profileContact.Address = model.ContactAddress;
                    profileContact.Post = profileContactPost;
                    profileContact.Telephone = model.ContactTelephone;
                    profileContact.FamilyRelationship = model.ContactFamilyRelationship;

                    db.Entry(profileContact).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    profile.HealthInsuranceNumber = model.HealthInsuranceNumber;
                    profile.FirstName = model.FirstName;
                    profile.LastName = model.LastName;
                    profile.Address = model.Address;
                    profile.Post = profilePost;
                    profile.Telephone = model.Telephone;
                    profile.Gender = model.Gender;
                    profile.BirthDate = model.BirthDate;
                    profile.PatientProfileContact = profileContact;

                    db.Entry(profile).State = EntityState.Modified;
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

        // POST: api/PatientProfiles/{userId}
        [AllowAnonymous]
        [HttpPost]
        [Route("{userId}")]
        [ResponseType(typeof(PatientProfile))]
        public async Task<IHttpActionResult> PostPatientProfile(string userId, PatientProfileBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (db.Profiles.OfType<PatientProfile>().Where(e => e.HealthInsuranceNumber == model.HealthInsuranceNumber).Count() > 0)
            {
                return BadRequest("Ta ZZZS številka že obstaja.");
            }

            var user = await db.Users.Where(e => e.Id == userId).FirstOrDefaultAsync() as Patient;
            var post = await db.Posts.Where(e => e.PostNumber == model.PostNumber).FirstOrDefaultAsync();
            var contactPost = await db.Posts.Where(e => e.PostNumber == model.ContactPostNumber).FirstOrDefaultAsync();

            if (user == null || post == null || contactPost == null)
            {
                return NotFound();
            }

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var contact = new PatientProfileContact
                    {
                        FirstName           = model.ContactFirstName,
                        LastName            = model.ContactLastName,
                        Address             = model.ContactAddress,
                        Post                = contactPost,
                        Telephone           = model.ContactTelephone,
                        FamilyRelationship  = model.ContactFamilyRelationship
                    };
                    db.PatientProfileContacts.Add(contact);
                    await db.SaveChangesAsync();

                    var profile = new PatientProfile
                    {
                        HealthInsuranceNumber   = model.HealthInsuranceNumber,
                        FirstName               = model.FirstName,
                        LastName                = model.LastName,
                        Address                 = model.Address,
                        Post                    = post,
                        Telephone               = model.Telephone,
                        Gender                  = model.Gender,
                        BirthDate               = model.BirthDate,
                        PatientProfileContact   = contact,
                        IsGuardian = false
                    };

                    bool hasNoGuardian = (user.PatientProfiles.Any(p=>p.IsGuardian == true))? false: true;
                    if(hasNoGuardian)
                    {
                        // Make it guardian profile (also applies when user creates first profile)
                        profile.IsGuardian = true;
                    }

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

        // DELETE: api/PatientProfiles/{patientProfileId}
        [AllowAnonymous]
        [HttpDelete]
        [Route("{patientProfileId}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> DeletePatientProfile(Guid patientProfileId)
        {
            PatientProfile patientProfile = await db.Profiles.FindAsync(patientProfileId) as PatientProfile;
            if (patientProfile == null)
            {
                return NotFound();
            }

            db.Profiles.Remove(patientProfile);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
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

        // get zdravnike za 1 profil
        // GET: api/PatientProfiles/{patientProfileId}/Doctors
        [AllowAnonymous]
        [HttpGet]
        [Route("{patientProfileId}/Doctors")]
        [ResponseType(typeof(PatientProfileDoctorsViewModel))]
        public IHttpActionResult GetPatientProfileDoctors(Guid patientProfileId)
        {
            PatientProfile patientProfile = db.Profiles.Find(patientProfileId) as PatientProfile;
            if (patientProfile == null)
            {
                return NotFound();
            }

            return Ok(patientProfile);
        }



        // PUT: api/PatientProfiles/{patientProfileId}/Doctors
        [AllowAnonymous]
        [HttpPut]
        [Route("{patientProfileId}/Doctors")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPatientProfileDoctor(Guid patientProfileId, PatientProfileDoctorsBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var profile = db.Profiles.Find(patientProfileId) as PatientProfile;

            if (profile == null)
            {
                return BadRequest();
            }

            DoctorProfile oldPersonalDoctor = null;
            if (profile.PersonalDoctor != null)
            {
                oldPersonalDoctor = db.Profiles.Find(profile.PersonalDoctor.Id) as DoctorProfile;
            }

            DoctorProfile oldDentistDoctor = null;
            if (profile.DentistDoctor != null)
            {
                oldDentistDoctor = db.Profiles.Find(profile.DentistDoctor.Id) as DoctorProfile;
            }

            var personalDoctor = db.Profiles.Find(model.PersonalDoctor) as DoctorProfile;
            var dentistDoctor = db.Profiles.Find(model.DentistDoctor) as DoctorProfile;


            if (model.PersonalDoctor != Guid.Empty && personalDoctor == null)
            {
                return NotFound();
            }
            if (model.DentistDoctor != Guid.Empty && dentistDoctor == null)
            {
                return NotFound();
            }
            if(personalDoctor != null && personalDoctor.PatientNumber - personalDoctor.CurrentPatientNumber <= 0 && personalDoctor.DoctorKey != oldPersonalDoctor.DoctorKey)
            {
                return BadRequest();
            }
            if (dentistDoctor != null && dentistDoctor.PatientNumber - dentistDoctor.CurrentPatientNumber <= 0 && dentistDoctor.DoctorKey != dentistDoctor.DoctorKey)
            {
                return BadRequest();
            }
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    if(personalDoctor != null)
                    {
                        profile.PersonalDoctor = personalDoctor;
                        if (oldPersonalDoctor != null)
                        {
                            oldPersonalDoctor.CurrentPatientNumber--;
                        }
                        personalDoctor.CurrentPatientNumber++;
                       
                        if (oldPersonalDoctor != null)
                        {
                            db.Entry(oldPersonalDoctor).State = EntityState.Modified;
                        }

                        db.Entry(personalDoctor).State = EntityState.Modified;
                    }
                    if (dentistDoctor != null)
                    {
                        profile.DentistDoctor = dentistDoctor;


                        if (oldDentistDoctor != null)
                        {
                            oldDentistDoctor.CurrentPatientNumber--;
                        }

                        dentistDoctor.CurrentPatientNumber++;

                        if (oldDentistDoctor != null)
                        {
                            db.Entry(oldDentistDoctor).State = EntityState.Modified;
                        }
                        db.Entry(dentistDoctor).State = EntityState.Modified;
                    }
                    db.Entry(profile).State = EntityState.Modified;
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

        [Authorize(Roles = "Doctor")]
        [HttpGet]
        [Route("{doctorId}/patients")]
        [ResponseType(typeof(PatientProfileDoctorsViewModel))]
        public async Task<IHttpActionResult> GetPatientProfileForDoctor(Guid doctorId)
        {
            var doctor = await db.Users.Where(e => e.Id == doctorId.ToString()).FirstOrDefaultAsync() as Doctor;
            IEnumerable<PatientProfile> patientProfiles;
            if(doctor.DoctorProfile.DocOrDentist == 0)
                patientProfiles = db.Profiles.OfType<PatientProfile>().Where(e => e.PersonalDoctor.Id == doctor.DoctorProfile.Id).ToList();
            else
                patientProfiles = db.Profiles.OfType<PatientProfile>().Where(e => e.DentistDoctor.Id == doctor.DoctorProfile.Id).ToList();
            if (doctor == null || User.Identity.GetUserId() != doctorId.ToString())
            {
                return NotFound();
            }
            var profiles = new List<PatientProfileViewModel>();
            foreach (var patientProfile in patientProfiles)
            {
                var profile = new PatientProfileViewModel
                {
                    Id = patientProfile.Id,

                    HealthInsuranceNumber = patientProfile.HealthInsuranceNumber,
                    FirstName = patientProfile.FirstName,
                    LastName = patientProfile.LastName,
                    Address = patientProfile.Address,
                    PostNumber = patientProfile.Post.PostNumber,
                    Telephone = patientProfile.Telephone,
                    Gender = patientProfile.Gender,
                    BirthDate = patientProfile.BirthDate,

                    ContactFirstName = patientProfile.PatientProfileContact.FirstName,
                    ContactLastName = patientProfile.PatientProfileContact.LastName,
                    ContactAddress = patientProfile.PatientProfileContact.Address,
                    ContactPostNumber = patientProfile.PatientProfileContact.Post.PostNumber,
                    ContactTelephone = patientProfile.PatientProfileContact.Telephone,
                    ContactFamilyRelationship = patientProfile.PatientProfileContact.FamilyRelationship,

                    //ContactProfile = patientProfile.PatientProfileContact,

                    PersonalDoctor = patientProfile.PersonalDoctor,
                    DentistDoctor = patientProfile.DentistDoctor

                };

                profiles.Add(profile);
            }
            return Ok(profiles);
        }

    }
}