using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using tpo10_rest.Models;

namespace tpo10_rest.Controllers
{
    [RoutePrefix("api/Observation")]
    public class ObservationController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Observation/PatientProfile/{patientId}
        [Route("PatientProfile/{patientId}")]
        [ResponseType(typeof(List<Observation>))]
        public IHttpActionResult GetObservations(Guid patientId)
        {
            var patient = db.PatientProfiles.Find(patientId) as PatientProfile;
            if(patient == null)
            {
                return NotFound();
            }

            var observations = db.Observations.Where(o => o.PatientProfile.Id == patient.Id);

           
            return Ok(observations.ToList());
        }

        // GET: api/Observation/5
        [ResponseType(typeof(Observation))]
        public IHttpActionResult GetObservation(Guid id)
        {
            Observation observation = db.Observations.Find(id);
            if (observation == null)
            {
                return NotFound();
            }

            return Ok(observation);
        }

        // PUT: api/Observation/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutObservation(Guid id, Observation observation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != observation.Id)
            {
                return BadRequest();
            }

            db.Entry(observation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObservationExists(id))
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

        // TODO popravi to metodo... zgolj placeholder (deluje za silo)
        // POST: api/Observation
        [ResponseType(typeof(Observation))]
        public IHttpActionResult PostObservation(ObservationBindingModel observationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Observation observation = new Observation()
            {
                ObservationTime = observationModel.ObservationTime,
                PatientProfile = db.PatientProfiles.Find(observationModel.PatientProfileId),
                DoctorProfile = db.DoctorProfile.Find(observationModel.DoctorProfileId),
                Notes = observationModel.Notes
            };


            foreach(var allergy in observationModel.Allergies)
            {
                if (db.Allergies.Find(allergy.AllergyKey) != null)
                    observation.Allergies.Add(db.Allergies.Find(allergy.AllergyKey));
            }

            foreach (var disease in observationModel.Diseases)
            {
                if (db.Diseases.Find(disease.DiseaseKey) != null)
                    observation.Diseases.Add(db.Diseases.Find(disease.DiseaseKey));
            }

            foreach (var diet in observationModel.Diets)
            {
                if (db.Diets.Find(diet.DietKey) != null)
                    observation.Diets.Add(db.Diets.Find(diet.DietKey));
            }

            foreach (var medication in observationModel.Medications)
            {
                if (db.Medications.Find(medication.MedicationKey) != null)
                    observation.Medications.Add(db.Medications.Find(medication.MedicationKey));
            }
            foreach (var observationMeasurement in observationModel.ObservationMeasurements)
            {
                observation.ObservationMeasurements.Add(new ObservationMeasurement()
                {
                    Value = observationMeasurement.Value,
                    MeasurementTime = observationMeasurement.MeasurementTime,
                    MeasurementPart = db.MeasurementParts.Find(observationMeasurement.MeasurementPartId)
                });
            } 
            

            db.Observations.Add(observation);
            db.SaveChanges();

            return Ok(observation);
        }

        // DELETE: api/Observation/5
        [ResponseType(typeof(Observation))]
        public IHttpActionResult DeleteObservation(Guid id)
        {
            Observation observation = db.Observations.Find(id);
            if (observation == null)
            {
                return NotFound();
            }

            db.Observations.Remove(observation);
            db.SaveChanges();

            return Ok(observation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ObservationExists(Guid id)
        {
            return db.Observations.Count(e => e.Id == id) > 0;
        }
    }
}