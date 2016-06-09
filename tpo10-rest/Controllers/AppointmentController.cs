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

namespace tpo10_rest.Controllers
{
    [RoutePrefix("api/Appointment")]
    public class AppointmentController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Appointment
        [Route("DoctorProfile/{doctorProfileId}")]
        [ResponseType(typeof(List<Appointment>))]
        public async Task<IHttpActionResult> GetAppointments(Guid doctorProfileId)
        {
            //var result = db.Appointments.Where(o => o.DoctorProfile.Id == doctorProfileId && o.IsAvailable == true).ToList();
            var result = db.Appointments.Where(o => o.DoctorProfile.Id == doctorProfileId).ToList();

            return Ok(result);
        }

        // GET: api/Appointment/5
        [ResponseType(typeof(Appointment))]
        public async Task<IHttpActionResult> GetAppointment(Guid id)
        {
            Appointment appointment = await db.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        // PUT: api/Appointment/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAppointment(Guid id, AppointmentBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var appointment = await db.Appointments.FindAsync(id);
            if(appointment == null)
            {
                return NotFound();
            }

            var patientProfile = await db.PatientProfiles.FindAsync(model.PatientProfileId) as PatientProfile;
            var doctorProfile = await db.DoctorProfile.FindAsync(model.DoctorProfileId) as DoctorProfile;
            var observation = await db.Observations.FindAsync(model.ObservationId) as Observation;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    appointment.EndDateTime = model.EndDateTime;
                    appointment.StartDateTime = model.StartDateTime;
                    appointment.PatientProfile = patientProfile;
                    appointment.DoctorProfile = doctorProfile;
                    appointment.IsAvailable = model.IsAvailable;
                    appointment.Notes = model.Notes;
                    appointment.Observation = observation;

                    db.Entry(appointment).State = EntityState.Modified;
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

        // PUT: api/Appointment/Subscription/{appointmentId}
        [Route("Subscription/{id}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAppointmentSubscription(Guid id, AppointmentSubscriptionBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appointment = await db.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            var subscriber = await db.Profiles.FindAsync(model.SubscriberId);
            var patientProfile = await db.PatientProfiles.FindAsync(model.PatientProfileId) as PatientProfile;
            var doctorProfile = await db.DoctorProfile.FindAsync(model.DoctorProfileId) as DoctorProfile;

            if (subscriber == null)
            {
                return NotFound();
            }

            if (patientProfile == null)
            {
                return NotFound();
            }

            if(doctorProfile == null)
            {
                return NotFound();
            }

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    // Subscribe to available appointment
                    if (model.Subscribe)
                    {
                        // All appointments that are not finished yet but are subscribed by a patient
                        var q = db.Appointments.Where(x => x.Observation == null && x.StartDateTime > DateTime.Now &&  x.PatientProfile.Id == patientProfile.Id).ToList();
                        if ((User.IsInRole("Patient") && q.Count() == 0) ||  User.IsInRole("Doctor"))
                        {
                            appointment.PatientProfile = patientProfile;
                            appointment.IsAvailable = false;
                            appointment.Subscriber = subscriber;
                        } else
                        {
                            return Content(HttpStatusCode.Forbidden, "Trenutno že imate rezerviran termin.");
                        }
                        
                    }
                    // Unsubscribe
                    // must be >=12h before appointment StartDateTime
                    else
                    {
                       if(appointment.StartDateTime.AddHours(-12) >= DateTime.Now)
                        {
                            if (appointment.Subscriber.GetType().BaseType == typeof(PatientProfile) && User.IsInRole("Doctor")) // Or nurse ? not yet implemented
                            {
                               return Content(HttpStatusCode.Forbidden, "Kot zdravnik ne morate sproščati terminov, ki so jih rezervirali pacientje.");
                            }  

                            appointment.PatientProfile = null;
                            appointment.Subscriber = null;
                            appointment.IsAvailable = true;

                        } else
                        {
                            return Content(HttpStatusCode.Forbidden, "Rok za odjavo/preklic termina je potekel.");
                        }
                    }
                    
                    db.Entry(appointment).State = EntityState.Modified;
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

        // POST: api/Appointment
        [ResponseType(typeof(Appointment))]
        public async Task<IHttpActionResult> PostAppointment(AppointmentBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DoctorProfile docProfile = await db.DoctorProfile.FindAsync(model.DoctorProfileId);
            if(docProfile == null)
            {
                return BadRequest("Doktor ne obstaja!");
            }
            PatientProfile patientProfile = null;

            // If patientProfile is given, then must be valid one! 
            if (!model.PatientProfileId.Equals(Guid.Empty))
            {
                patientProfile = await db.Profiles.FindAsync(model.PatientProfileId) as PatientProfile;
                if(patientProfile == null)
                {
                    return BadRequest("Pacient ne obstaja!");
                }

            }
            
            Appointment appointment = new Appointment()
            {
                Notes = model.Notes,
                DoctorProfile = docProfile,
                StartDateTime = model.StartDateTime,
                EndDateTime = model.EndDateTime,
                IsAvailable = model.IsAvailable,
                PatientProfile = patientProfile
            };
            
            db.Appointments.Add(appointment);
            await db.SaveChangesAsync();

            return Ok(appointment);
        }

        // DELETE: api/Appointment/5
        [ResponseType(typeof(Appointment))]
        public async Task<IHttpActionResult> DeleteAppointment(Guid id)
        {
            Appointment appointment = await db.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            db.Appointments.Remove(appointment);
            await db.SaveChangesAsync();

            return Ok(appointment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppointmentExists(Guid id)
        {
            return db.Appointments.Count(e => e.Id == id) > 0;
        }


        // GET: api/Appointment/upcoming/patient/{PatientProfileId}/{number}
        [Route("upcoming/patient/{PatientProfileId}/{number}")]
        [ResponseType(typeof(List<Appointment>))]
        public async Task<IHttpActionResult> GetUpcomingAppointments(Guid PatientProfileId, int number)
        {
            
            var patient = db.PatientProfiles.Find(PatientProfileId) as PatientProfile;
            if (patient == null)
            {
                return NotFound();
            }

            var appointments = db.Appointments.Where(o => o.PatientProfile.Id == PatientProfileId).Where(o => o.StartDateTime > DateTime.Now).ToList();
            return Ok(appointments);



        }


        // POST: api/Appointment/InitializeAppointments/{doctorEmail}
        [Route("InitializeAppointments")]
        public async Task<IHttpActionResult> InitializeAppointments(string doctorEmail)
        {
            var doctor = db.Users.FirstOrDefault(e => e.Email == doctorEmail) as Doctor;

            if (doctor == null)
            {
                return BadRequest("Zdravnik ne obstaja");
            }

            if(doctor.DoctorProfile == null)
            {
                return BadRequest("Zdravnik nima profila");
            }

            // Two week appointments schedule
            for (int i = 0; i < 8; i++)
            {
                DateTime currentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + i, 7, 30, 0);

                int appointmentEndHour = 15;

                if (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    appointmentEndHour = 14;
                }

                int j = 0;
                while(currentDate.Hour < appointmentEndHour)
                {
                    Appointment appointment = new Appointment()
                    {
                        DoctorProfile = doctor.DoctorProfile,
                        StartDateTime = currentDate,
                        EndDateTime = currentDate.AddMinutes(40),
                        Notes = "Prosti termin " + (j + 1).ToString(),
                        IsAvailable = true
                    };

                    db.Appointments.Add(appointment);

                    currentDate = currentDate.AddMinutes(50);

                    // Fix
                    //if (currentDate.Hour == 12 && currentDate.Minute == 10)
                    //    currentDate = currentDate.AddMinutes(-10);

                    j++;
                }

            }

            try
            {
                await db.SaveChangesAsync();
                return StatusCode(HttpStatusCode.NoContent);
            } catch (Exception e)
            {
                throw e;
            }

        }


    }
}