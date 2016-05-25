using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using tpo10_rest.Models;

namespace tpo10_rest.Controllers
{
    [RoutePrefix("api/Observation")]
    public class ObservationController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: api/Observation/5
        [ResponseType(typeof(Observation))]
        public async Task<IHttpActionResult> GetObservation(Guid id)
        {
            Observation observation = await db.Observations.FindAsync(id);
            if (observation == null)
            {
                return NotFound();
            }

            return Ok(observation);
        }
        
        // POST: api/Observation
        [ResponseType(typeof(Observation))]
        public async Task<IHttpActionResult> PostObservation(ObservationBindingModel observationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            using (var transaction = db.Database.BeginTransaction())
            {
                try
                { 
                    Observation observation = new Observation()
                    {
                        ObservationTime = observationModel.ObservationTime,
                        PatientProfile = db.PatientProfiles.Find(observationModel.PatientProfileId),
                        DoctorProfile = db.DoctorProfile.Find(observationModel.DoctorProfileId),
                        Notes = observationModel.Notes
                    };


                    foreach (var allergy in observationModel.Allergies)
                    {
                       observation.Allergies.Add(db.Allergies.Find(allergy.AllergyKey));
                    }
                    

                    foreach (var disease in observationModel.Diseases)
                    {
                       observation.Diseases.Add(db.Diseases.Find(disease.DiseaseKey));
                    }

                    foreach (var diet in observationModel.Diets)
                    {
                       observation.Diets.Add(db.Diets.Find(diet.DietKey));
                    }

                    foreach (var medication in observationModel.Medications)
                    {
                       observation.Medications.Add(db.Medications.Find(medication.MedicationKey));
                    }

                    foreach (var observationMeasurement in observationModel.ObservationMeasurements)
                    {
                        var om = new ObservationMeasurement()
                        {
                            Value = observationMeasurement.Value,
                            MeasurementTime = observationMeasurement.MeasurementTime,
                            MeasurementPart = db.MeasurementParts.Find(observationMeasurement.MeasurementPartId)
                        };
                        
                        observation.ObservationMeasurements.Add(om);
                    }


                    db.Observations.Add(observation);
                    await db.SaveChangesAsync();

                    transaction.Commit();
                    return Ok(observation);


                } catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            } 
        }
       
        // GET: api/Observation/PatientProfile/{patientId}
        [Route("PatientProfile/{patientId}")]
        [ResponseType(typeof(List<Observation>))]
        public async Task<IHttpActionResult> GetPatientObservations(Guid patientId)
        {
            var patient = db.PatientProfiles.Find(patientId) as PatientProfile;
            if (patient == null)
            {
                return NotFound();
            }

            var observations = db.Observations.Where(o => o.PatientProfile.Id == patient.Id);


            return Ok(observations.ToList());
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }
}