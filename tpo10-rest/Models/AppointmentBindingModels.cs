using System;
using System.ComponentModel.DataAnnotations;

namespace tpo10_rest.Models
{
    public class AppointmentBindingModel
    {
        [Required]
        public DateTime StartDateTime { get; set; }
        [Required]
        public DateTime EndDateTime { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        public string Notes { get; set; }
        public virtual Guid PatientProfileId { get; set; }
        [Required]
        public virtual Guid DoctorProfileId { get; set; }
    }

}