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
        [Required]
        public bool IsGuardian { get; set; } = false;   

        public virtual DoctorProfile PersonalDoctor { get; set; }
        public virtual DoctorProfile DentistDoctor { get; set; }

        public virtual Post Post { get; set; }

        public virtual PatientProfileContact PatientProfileContact { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<PatientProfileMeasurement> PatientProfileMeasurements { get; set; } = new List<PatientProfileMeasurement>();
        
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
        public string Key { get; set; }
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
    
    public partial class Allergy 
    {
        [Key]
        [MaxLength(200)]
        public string AllergyKey { get; set; }
        [Required]
        public string AllergyName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Medication> Medications { get; set; } = new List<Medication>();
        [JsonIgnore]
        public virtual ICollection<Observation> Observations { get; set; } = new List<Observation>();
    }

    public partial class Disease 
    {
        [Key]
        [MaxLength(200)]
        public string DiseaseKey { get; set; }
        public string DiseaseName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Medication> Medications { get; set; } = new List<Medication>();
        [JsonIgnore]
        public virtual ICollection<Observation> Observations { get; set; } = new List<Observation>();
    }

    public partial class Diet
    {
        [Key]
        [MaxLength(200)]
        public string DietKey { get; set; }
        public string DietName { get; set; }
        public virtual ICollection<DietInstruction> DietInstructions { get; set; } = new List<DietInstruction>();
        [JsonIgnore]
        public virtual ICollection<Observation> Observations { get; set; } = new List<Observation>();
    }

    public partial class Instruction : Entity
    {
        [Index(IsUnique = true)]
        [Required]
        [MaxLength(200)]
        public string Url { get; set; }
    }

    public partial class DietInstruction : Instruction
    {
        public string DietRefId { get; set; }
        [JsonIgnore]
        [ForeignKey("DietRefId")]
        public virtual Diet Diet { get; set; }
    }

    public partial class MedicationInstruction : Instruction
    {
        [JsonIgnore]
        public virtual ICollection<Medication> Medications { get; set; } = new List<Medication>();
    }


    public partial class Medication 
    {
        [Key]
        [MaxLength(200)]
        public string MedicationKey { get; set; }
        public string MedicationName { set; get; }
        public virtual MedicationInstruction MedicationInstruction { get; set; }
        [JsonIgnore]
        public virtual ICollection<Observation> Observations { get; set; } = new List<Observation>();
        [JsonIgnore]
        public virtual ICollection<Allergy> Allergies { get; set; } = new List<Allergy>();
        [JsonIgnore]
        public virtual ICollection<Disease> Diseases { get; set; } = new List<Disease>();
    }

    public partial class Observation : Entity
    {   
        //public virtual Appointment Appointment { get; set; }
        public virtual string Notes { get; set; }
        public virtual DateTime ObservationTime { get; set; }
        public virtual PatientProfile PatientProfile { get; set; }
        public virtual DoctorProfile DoctorProfile { get; set; }
        public virtual ICollection<Allergy> Allergies { get; set; } = new List<Allergy>();
        public virtual ICollection<Disease> Diseases { get; set; } = new List<Disease>();
        public virtual ICollection<Diet> Diets { get; set; } = new List<Diet>();
        public virtual ICollection<Medication> Medications { get; set; } = new List<Medication>();
        public virtual ICollection<ObservationMeasurement> ObservationMeasurements { get; set; } = new List<ObservationMeasurement>();
    }

    // An intermediate table between Observation and MeasurementPart
    public class ObservationMeasurement : Entity
    {
        [Required]
        public double Value { get; set; }
        public string Notes { get; set; }
        [Required]
        public virtual DateTime MeasurementTime { get; set; }
        [JsonIgnore]
        public virtual Observation Observation { get; set; }
        public virtual MeasurementPart MeasurementPart { get; set; }
    }

    // An intermediate table between PatientProfile and MeasurementPart
    public class PatientProfileMeasurement : Entity
    {
        [Required]
        public double Value { get; set; }
        public string Notes { get; set; }
        [Required]
        public virtual DateTime MeasurementTime { get; set; }
        [Required]
        public virtual PatientProfile PatientProfile { get; set; }
        [Required]
        public virtual MeasurementPart MeasurementPart { get; set; }
    }

    public partial class Measurement : Entity
    {
        [Index(IsUnique = true)]
        [Required]
        [MaxLength(200)]
        public string MeasurementName { get; set; }
        public string MeasurementNotes { get; set; }
        public virtual ICollection<MeasurementPart> MeasurementParts { get; set; } = new List<MeasurementPart>();
    }

    public partial class MeasurementPart : Entity
    {
        [Index(IsUnique = true)]
        [Required]
        [MaxLength(200)]
        public string MeasurementPartName { get; set; }
        public string MeasurementTake { get; set; }
        [Required]
        public string MeasurementUnit { get; set; }
        public string MeasurementTime { get; set; } //Which part of day
        //public string MeasurementNormal { get; set; }
        //public string MeasurementBelow { get; set; }
        //public string MeasurementMore { get; set; }
        //public string MeasurementExtreme { get; set; }

        public double MeasurementMin { get; set; }
        public double MeasurementMax { get; set; }
        public double MeasurementNormalMin { get; set; }
        public double MeasurementNormalMax { get; set; }
        [JsonIgnore]
        public virtual Measurement Measurement { get; set; }
        //public virtual ICollection<ObservationMeasurementParts> ObservationMeasurementParts { get; set; } = new List<ObservationMeasurementParts>();
        //public virtual ICollection<PatientProfile> PatientsProfile { get; set; } = new List<PatientProfile>();
    }
    
}