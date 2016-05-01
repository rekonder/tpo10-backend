using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tpo10_rest.Models
{
    public class PatientProfileBindingModel
    {
        public Guid Id { get; set; }

        [Required]
        public string HealthInsuranceNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int PostNumber { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string ContactFirstName { get; set; }
        [Required]
        public string ContactLastName { get; set; }
        [Required]
        public string ContactAddress { get; set; }
        [Required]
        public int ContactPostNumber { get; set; }
        [Required]
        public string ContactTelephone { get; set; }
        [Required]
        public string ContactFamilyRelationship { get; set; }
    }

    public class DoctorProfileBindingModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        [Range(1000, 9999)]
        public string DoctorKey { get; set; }
        [Required]
        public int PatientNumber { get; set; }
        [Required]
        public int HealthCareProviderNumber { get; set; }
    }

}