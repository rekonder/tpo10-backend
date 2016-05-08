using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace tpo10_rest.Models
{
    public class Patient : ApplicationUser
    {
        public virtual ICollection<PatientProfile> PatientProfiles { get; set; } = new List<PatientProfile>();
    }

    public class Doctor : ApplicationUser
    {
        public virtual DoctorProfile DoctorProfile { get; set; }
    }

    public class Nurse : ApplicationUser
    {
        public virtual NurseProfile NurseProfile { get; set; }
    }

    public class Administrator : ApplicationUser
    {

    }

    public class Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
    
    public class Profile : Entity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Telephone { get; set; }
    }

    public class PatientProfile : Profile
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string HealthInsuranceNumber { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        public virtual DoctorProfile PersonalDoctor { get; set; }
        public virtual DoctorProfile DentistDoctor { get; set; }
        public virtual Post Post { get; set; }

        public virtual PatientProfileContact PatientProfileContact { get; set; }
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

        public virtual Post Post { get; set; }
    }

    public class DoctorProfile : Profile
    {
        [Required]
        [StringLength(4)]
        public string DoctorKey { get; set; }
        [Required]
        public int PatientNumber { get; set; }
        [Required]
        [Range(0, 1)]
        public int DocOrDentist { get; set; } //0-Doctor, 1-Dentist
        [Required]
        public int CurrentPatientNumber { get; set; }

        public virtual HealthCareProvider HealthCareProvider { get; set; }
    }

    public class NurseProfile : Profile
    {
        [Required]
        [StringLength(4)]
        public string NurseKey { get; set; }
        public virtual HealthCareProvider HealthCareProvider { get; set; }
    }


    public class HealthCareProvider
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Key { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }

        public virtual Post Post { get; set; }
        public virtual ICollection<DoctorProfile> DoctorProfiles { get; set; } = new List<DoctorProfile>();
        public virtual ICollection<NurseProfile> NurseProfiles { get; set; } = new List<NurseProfile>();
    }

    public class Post
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostNumber { get; set; }
        [Required]
        public string PostName { get; set; }

        [JsonIgnore]
        public virtual ICollection<HealthCareProvider> HealthCareProviders { get; set; } = new List<HealthCareProvider>();
        [JsonIgnore]
        public virtual ICollection<Profile> Profiles { get; set; } = new List<Profile>();
        [JsonIgnore]
        public virtual ICollection<PatientProfileContact> PatientProfileContacts { get; set; } = new List<PatientProfileContact>();
    }
}