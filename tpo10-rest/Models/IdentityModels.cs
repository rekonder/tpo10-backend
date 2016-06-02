using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Data.Entity;

namespace tpo10_rest.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }

        public DateTime? LastLogin { get; set; }
        public string LastLoginIp { get; set; }
        public DateTime CreatedOn { get; set; }
        //public bool IsDeleted { get; set; } = false;
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("tpo10db", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<PatientProfileContact> PatientProfileContacts { get; set; }
        public virtual DbSet<HealthCareProvider> HealthCareProviders { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PatientProfile> PatientProfiles {get;set;}
        public virtual DbSet<DoctorProfile> DoctorProfile { get; set; }
        public virtual DbSet<Allergy> Allergies { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<Diet> Diets { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<Observation> Observations { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<MeasurementPart> MeasurementParts { get; set; }
        public virtual DbSet<MedicationInstruction> MedicationInstructions { get; set; }
        public virtual DbSet<DietInstruction> DietInstructions { get; set; } 
        public virtual DbSet<ObservationMeasurement> ObservationMeasurement { get; set; }
        public virtual DbSet<PatientProfileMeasurement> PatientProfileMeasurements { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PatientProfile>()
                .HasRequired(e => e.Post)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientProfileContact>()
                .HasRequired(e => e.Post)
                .WithMany()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<DoctorProfile>()
               .HasRequired(e => e.HealthCareProvider)
               .WithMany()
               .WillCascadeOnDelete(false);
            modelBuilder.Entity<NurseProfile>()
               .HasRequired(e => e.HealthCareProvider)
               .WithMany()
               .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Doctor>()
            //    .HasOptional(e => e.DoctorProfile)
            //    .WithOptionalPrincipal(e => e.Doctor);

            //modelBuilder.Entity<Nurse>()
            //    .HasOptional(e => e.NurseProfile)
            //    .WithOptionalPrincipal(e => e.Nurse);

            //modelBuilder.Entity<PatientProfile>()
            //    .HasRequired(e => e.PatientProfileContact)
            //    .WithRequiredPrincipal(e => e.PatientProfile);
        }

    }
}