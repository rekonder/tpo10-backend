using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tpo10_rest.Models
{
    public class PatientProfileViewModel
    {
        public Guid Id { get; set; }

        public string HealthInsuranceNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int PostNumber { get; set; }
        public string Telephone { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactAddress { get; set; }
        public int ContactPostNumber { get; set; }
        public string ContactTelephone { get; set; }
        public string ContactFamilyRelationship { get; set; }
    }
}