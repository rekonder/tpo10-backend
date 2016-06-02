using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tpo10_rest.Models
{
   
    public class ObservationBindingModel
    {
        public DateTime ObservationTime { get; set; }
        public Guid PatientProfileId { get; set; }
        public Guid DoctorProfileId { get; set; }
        public string Notes { get; set; }
        public ICollection<AllergyBindingModel> Allergies { get; set; } = new List<AllergyBindingModel>();
        public ICollection<DiseaseBindingModel> Diseases { get; set; } = new List<DiseaseBindingModel>();
        public ICollection<DietBindingModel> Diets { get; set; } = new List<DietBindingModel>();
        public ICollection<MedicationBindingModel> Medications { get; set; } = new List<MedicationBindingModel>();
        public ICollection<ObservationMeasurementBindingModel> ObservationMeasurements { get; set; } = new List<ObservationMeasurementBindingModel>();
    }

    public class MedicationObservationBindingModel
    {
        public ICollection<AllergyBindingModel> Allergies { get; set; } = new List<AllergyBindingModel>();
        public ICollection<DiseaseBindingModel> Diseases { get; set; } = new List<DiseaseBindingModel>();
    }

    public class AllergyBindingModel
    {
        public string AllergyKey { get; set; }
    }

    public class DiseaseBindingModel
    {
        public string DiseaseKey { get; set; }
    }

    public class MedicationBindingModel
    {
        public string MedicationKey { get; set; }
    }

    public class DietBindingModel
    {
        public string DietKey { get; set; }
    }

    public class ObservationMeasurementBindingModel
    {
        public double Value { get; set; }
        public DateTime MeasurementTime { get; set; }
        public Guid MeasurementPartId { get; set; }
    }

    public class PatientProfileMeasurementBindingModel
    {
        [Required]
        public Guid PatientProfileId { get; set; }
        [Required]
        public DateTime MeasurementTime { get; set; }
        [Required]
        public Guid MeasurementPartId { get; set; }
        [Required]
        public double Value { get; set; }
        public string Note { get; set; }
    }


}