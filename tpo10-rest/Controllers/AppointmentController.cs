﻿using System;
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
            var result = db.Appointments.Where(o => o.DoctorProfile.Id == doctorProfileId && o.IsAvailable == true).ToList();

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

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    appointment.EndDateTime = model.EndDateTime;
                    appointment.StartDateTime = model.StartDateTime;
                    appointment.PatientProfile = await db.PatientProfiles.FindAsync(model.PatientProfileId);
                    appointment.DoctorProfile = await db.DoctorProfile.FindAsync(model.DoctorProfileId);
                    appointment.IsAvailable = model.IsAvailable;
                    appointment.Notes = model.Notes;
                    appointment.Observation = await db.Observations.FindAsync(model.ObservationId);

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
    }
}