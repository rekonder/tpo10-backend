using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace tpo10_rest.Models
{
    public class Patient : ApplicationUser
    {
        public ICollection<PatientProfile> Profiles { get; set; } = new List<PatientProfile>();
    }

    public class Doctor : ApplicationUser
    {
        public DoctorProfile Profile { get; set; }
    }

    public class Nurse : ApplicationUser
    {
        public NurseProfile Profile { get; set; }
    }

    public class Administrator : ApplicationUser
    {
        public AdministratorProfile Profile { get; set; }
    }

    public class Entity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
    
    public class Profile : Entity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Telephone { get; set; }
    }

    public class PatientProfile : Profile
    {
        [Required]
        public string HealthInsuranceNumber { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public PatientProfileContact Contact { get; set; }
    }

    public class PatientProfileContact : Entity
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
        public string FamilyRelationship { get; set; }
    }

    public class DoctorProfile : Profile
    {

    }

    public class NurseProfile : Profile
    {

    }

    public class AdministratorProfile : Profile
    {

    }
}