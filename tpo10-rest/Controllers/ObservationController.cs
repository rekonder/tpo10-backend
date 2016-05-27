using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        [AllowAnonymous]
        [HttpGet]
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

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAlergies/{patientId}/{number}")]
        [ResponseType(typeof(List<AlergiesViewModel>))]
        public async Task<IHttpActionResult> GetAlergies(Guid patientId, int number)
        {
            var patient = db.PatientProfiles.Find(patientId) as PatientProfile;
            if (patient == null)
            {
                return NotFound();
            }

            var observations = db.Observations.Where(o => o.PatientProfile.Id == patient.Id).OrderByDescending(s => s.ObservationTime);

            List<AlergiesViewModel> alergies = new List<AlergiesViewModel>();

            foreach (var observation in observations)
            {
                var alergiesObs = observation.Allergies;
                foreach(var alergyObs in alergiesObs)
                {
                    AlergiesViewModel al = new AlergiesViewModel();
                    al.Name = alergyObs.AllergyName;
                    if (!alergies.Any(f => f.Name == al.Name))
                    {
                        if (number == -1)
                            alergies.Add(al);
                        else if (number != -1 && alergies.Count < number)
                            alergies.Add(al);
                    }
                    else
                        break;
                }
                if(number != -1 && alergies.Count >= number)
                    break;
            }
            return Ok(alergies.ToList());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetDiases/{patientId}/{number}")]
        [ResponseType(typeof(List<DiseaseViewModel>))]
        public async Task<IHttpActionResult> GetDiases(Guid patientId, int number)
        {
            var patient = db.PatientProfiles.Find(patientId) as PatientProfile;
            if (patient == null)
            {
                return NotFound();
            }

            var observations = db.Observations.Where(o => o.PatientProfile.Id == patient.Id).OrderByDescending(s => s.ObservationTime);

            List<DiseaseViewModel> diases = new List<DiseaseViewModel>();

            foreach (var observation in observations)
            {
                var diseasesObs = observation.Diseases;
                foreach (var diseaseObs in diseasesObs)
                {
                    DiseaseViewModel al = new DiseaseViewModel();
                    al.DiseaseName = diseaseObs.DiseaseName;
                    al.ObservationTime = observation.ObservationTime;
                    al.DoctorName = observation.DoctorProfile.FirstName + ' ' + observation.DoctorProfile.LastName;
                    if (observation.DoctorProfile.DocOrDentist == 0)
                        al.DoctorName += ", zdravnik";
                    else
                        al.DoctorName += ", zobozdravnik";
                    if (!diases.Any(f => f.DiseaseName == al.DiseaseName && f.ObservationTime == al.ObservationTime))
                    {
                        if (number == -1)
                            diases.Add(al);
                        else if (number != -1 && diases.Count < number)
                            diases.Add(al);
                    }
                    else
                        break;
                }
                if (number != -1 && diases.Count >= number)
                    break;
            }
            return Ok(diases.ToList());
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("GetDiets/{patientId}/{number}")]
        [ResponseType(typeof(List<DietViewModel>))]
        public async Task<IHttpActionResult> GetDiets(Guid patientId, int number)
        {
            var patient = db.PatientProfiles.Find(patientId) as PatientProfile;
            if (patient == null)
            {
                return NotFound();
            }

            var observations = db.Observations.Where(o => o.PatientProfile.Id == patient.Id).OrderByDescending(s => s.ObservationTime);

            List<DietViewModel> diets = new List<DietViewModel>();

            foreach (var observation in observations)
            {
                var dietsObs = observation.Diets;
                foreach (var dietObs in dietsObs)
                {
                    DietViewModel al = new DietViewModel();
                    al.ObservationTime = observation.ObservationTime;
                    al.DietName = dietObs.DietName;
                    al.DietUrl = dietObs.DietInstructions.ToList();
                    al.DoctorName = observation.DoctorProfile.FirstName + ' ' + observation.DoctorProfile.LastName;
                    if (observation.DoctorProfile.DocOrDentist == 0)
                        al.DoctorName += ", zdravnik";
                    else
                        al.DoctorName += ", zobozdravnik";
                    if (!diets.Any(f => f.DietName == al.DietName && f.ObservationTime == al.ObservationTime))
                    {
                        if (number == -1)
                            diets.Add(al);
                        else if (number != -1 && diets.Count < number)
                            diets.Add(al);
                    }
                    else
                        break;
                }
                if (number != -1 && diets.Count >= number)
                    break;
            }
            return Ok(diets.ToList());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetMedications/{patientId}/{number}")]
        [ResponseType(typeof(List<MedicationsViewModel>))]
        public async Task<IHttpActionResult> GetMedications(Guid patientId, int number)
        {
            var patient = db.PatientProfiles.Find(patientId) as PatientProfile;
            if (patient == null)
            {
                return NotFound();
            }

            var observations = db.Observations.Where(o => o.PatientProfile.Id == patient.Id).OrderByDescending(s => s.ObservationTime);

            List<MedicationsViewModel> medications = new List<MedicationsViewModel>();

            foreach (var observation in observations)
            {
                var medicationsObs = observation.Medications;
                foreach (var medicationObs in medicationsObs)
                {
                    MedicationsViewModel al = new MedicationsViewModel();
                    al.ObservationTime = observation.ObservationTime;
                    al.MedicationName = medicationObs.MedicationName;
                    al.MedicationUrl = medicationObs.MedicationInstruction.Url;
                    al.DoctorName = observation.DoctorProfile.FirstName + ' ' + observation.DoctorProfile.LastName;
                    if (observation.DoctorProfile.DocOrDentist == 0)
                        al.DoctorName += ", zdravnik";
                    else
                        al.DoctorName += ", zobozdravnik";
                    if (!medications.Any(f => f.MedicationName == al.MedicationName && f.ObservationTime == al.ObservationTime)) { 
                        if (number == -1)
                            medications.Add(al);
                        else if (number != -1 && medications.Count < number)
                            medications.Add(al);
                    }
                    else
                        break;
                }
                if (number != -1 && medications.Count >= number)
                    break;
            }
            return Ok(medications.ToList());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetMeasurements/{patientId}/{number}")]
        [ResponseType(typeof(List<MeasurementsViewModel>))]
        public async Task<IHttpActionResult> GetMeasurements(Guid patientId, int number)
        {
            var patient = db.PatientProfiles.Find(patientId) as PatientProfile;
            if (patient == null)
            {
                return NotFound();
            }

            var observations = db.Observations.Where(o => o.PatientProfile.Id == patient.Id).OrderByDescending(s => s.ObservationTime);

            List<MeasurementsViewModel> measurements = new List<MeasurementsViewModel>();

            foreach (var observation in observations)
            {
                var measurementsObs = observation.ObservationMeasurements;
                foreach (var measurementObs in measurementsObs)
                {
                    MeasurementsViewModel al = new MeasurementsViewModel();
                    al.MeasurementTime = measurementObs.MeasurementTime;
                    al.Value = measurementObs.Value;
                    if (measurementObs.MeasurementPart != null)
                    {
                        al.MeasurementPartName = measurementObs.MeasurementPart.MeasurementPartName;
                        al.MeasurementUnit = measurementObs.MeasurementPart.MeasurementUnit;
                    }
                    else
                    {
                        al.MeasurementPartName = "Ni na voljo";
                        al.MeasurementUnit = "e";
                    }
                    al.DoctorName = observation.DoctorProfile.FirstName + ' ' + observation.DoctorProfile.LastName;
                    if (observation.DoctorProfile.DocOrDentist == 0)
                        al.DoctorName += ", zdravnik";
                    else
                        al.DoctorName += ", zobozdravnik";
                    if (!measurements.Any(f => f.MeasurementPartName == al.MeasurementPartName && al.MeasurementPartName != "Ni na voljo" && f.MeasurementTime == al.MeasurementTime))
                    {
                        if (number == -1)
                            measurements.Add(al);
                        else if (number != -1 && measurements.Count < number)
                            measurements.Add(al);
                    }
                    else
                        break;
                }
                if (number != -1 && measurements.Count >= number)
                    break;
            }
            return Ok(measurements.OrderByDescending(s =>s.MeasurementTime).ToList());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("OldObservations/{patientId}/{number}")]
        [ResponseType(typeof(List<OldObservationsViewModel>))]
        public async Task<IHttpActionResult> OldObservations(Guid patientId, int number)
        {
            var patient = db.PatientProfiles.Find(patientId) as PatientProfile;
            if (patient == null)
            {
                return NotFound();
            }

            var observations = db.Observations.Where(o => o.PatientProfile.Id == patient.Id).OrderByDescending(s => s.ObservationTime);

            List<OldObservationsViewModel> oldObservations = new List<OldObservationsViewModel>();

            foreach (var observation in observations)
            {
                OldObservationsViewModel al = new OldObservationsViewModel();
                al.ObservationTime = observation.ObservationTime;
                al.DoctorName = observation.DoctorProfile.FirstName + ' ' + observation.DoctorProfile.LastName;
                if (observation.DoctorProfile.DocOrDentist == 0)
                    al.DoctorName += ", zdravnik";
                else
                    al.DoctorName += ", zobozdravnik";
                if (number == -1)
                    oldObservations.Add(al);
                else if (number != -1 && oldObservations.Count < number)
                    oldObservations.Add(al);
                else
                    break;
            }
            return Ok(oldObservations.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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
    }
}