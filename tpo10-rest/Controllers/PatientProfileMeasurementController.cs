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
    [RoutePrefix("api/PatientProfileMeasurement")]
    public class PatientProfileMeasurementController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PatientProfileMeasurement
        public IQueryable<PatientProfileMeasurement> GetAllPatientProfileMeasurements()
        {
            return db.PatientProfileMeasurements;
        }

        // GET: api/PatientProfileMeasurement/PatientProfile/:patientProfileId
        [Route("PatientProfile/{patientProfileId}")]
        [ResponseType(typeof(List<PatientProfileMeasurement>))]
        public async Task<IHttpActionResult> GetPatientProfileMeasurements(Guid patientProfileId)
        {
            var result = db.PatientProfileMeasurements.Where(o => o.PatientProfile.Id == patientProfileId).ToList();
            return Ok(result);
        }

        // GET: api/PatientProfileMeasurement/5
        [ResponseType(typeof(PatientProfileMeasurement))]
        public async Task<IHttpActionResult> GetPatientProfileMeasurement(Guid id)
        {
            PatientProfileMeasurement patientProfileMeasurement = await db.PatientProfileMeasurements.FindAsync(id);
            if (patientProfileMeasurement == null)
            {
                return NotFound();
            }

            return Ok(patientProfileMeasurement);
        }

        // PUT: api/PatientProfileMeasurement/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPatientProfileMeasurement(Guid id, PatientProfileMeasurementBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.MeasurementPartId)
            {
                return BadRequest();
            }

            var patientProfileMeasurement = await db.PatientProfileMeasurements.FindAsync(id);
            if(patientProfileMeasurement == null)
            {
                return NotFound();
            }

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    patientProfileMeasurement.MeasurementTime = model.MeasurementTime;
                    patientProfileMeasurement.Notes = model.Note;
                    patientProfileMeasurement.Value = model.Value;
                    patientProfileMeasurement.MeasurementPart = patientProfileMeasurement.MeasurementPart;
                    patientProfileMeasurement.PatientProfile = patientProfileMeasurement.PatientProfile;

                    db.Entry(patientProfileMeasurement).State = EntityState.Modified;
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

        // POST: api/PatientProfileMeasurement
        [ResponseType(typeof(PatientProfileMeasurement))]
        public async Task<IHttpActionResult> PostPatientProfileMeasurement(PatientProfileMeasurementBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            using (var transacion = db.Database.BeginTransaction())
            {
                try
                {
                    var patientProfileMeasurement = new PatientProfileMeasurement()
                    {
                        MeasurementPart = await db.MeasurementParts.FindAsync(model.MeasurementPartId),
                        MeasurementTime = model.MeasurementTime,
                        Notes = model.Note,
                        PatientProfile = await db.PatientProfiles.FindAsync(model.PatientProfileId),
                        Value = model.Value
                    };
                    
                    db.PatientProfileMeasurements.Add(patientProfileMeasurement);
                    await db.SaveChangesAsync();
                    transacion.Commit();
                    return Ok(patientProfileMeasurement);

                }
                catch (Exception e)
                {
                    transacion.Rollback();
                    throw;
                }
            }

        }

        // DELETE: api/PatientProfileMeasurement/5
        [ResponseType(typeof(PatientProfileMeasurement))]
        public async Task<IHttpActionResult> DeletePatientProfileMeasurement(Guid id)
        {
            PatientProfileMeasurement patientProfileMeasurement = await db.PatientProfileMeasurements.FindAsync(id);
            if (patientProfileMeasurement == null)
            {
                return NotFound();
            }

            db.PatientProfileMeasurements.Remove(patientProfileMeasurement);
            await db.SaveChangesAsync();

            return Ok(patientProfileMeasurement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientProfileMeasurementExists(Guid id)
        {
            return db.PatientProfileMeasurements.Count(e => e.Id == id) > 0;
        }
    }
}