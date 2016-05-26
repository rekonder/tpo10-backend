using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tpo10_rest.Models
{
    public class ObservationViewModels
    {
    }

    public class AlergiesViewModel
    {
        public string Name { get; set; }
    }
    public class OldObservationsViewModel
    {
        public DateTime ObservationTime { get; set; }
        public string DoctorName { get; set; }
    }
    public class DiseaseViewModel
    {
        public DateTime ObservationTime { get; set; }
        public string DiseaseName { get; set; }
        public string DoctorName { get; set; }
    }
    public class DietViewModel
    {
        public DateTime ObservationTime { get; set; }
        public string DietName { get; set; }
        public List<DietInstruction> DietUrl { get; set; }
        public string DoctorName { get; set; }

    }
    public class MedicationsViewModel
    {
        public DateTime ObservationTime { get; set; }
        public string MedicationName { get; set; }
        public string MedicationUrl { get; set; }
        public string DoctorName { get; set; }

    }
    public class MeasurementsViewModel
    {
        public DateTime MeasurementTime { get; set; }
        public double Value { get; set; }
        public string MeasurementPartName { get; set; }
        public string MeasurementUnit { get; set; }
        public string DoctorName { get; set; }

    }
}