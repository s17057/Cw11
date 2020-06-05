using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Models
{
    public class MedicalDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }



        public MedicalDbContext() { }

        public MedicalDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Medicament>().HasKey(m => m.IdMedicament).HasAnnotation("DatabaseGenerated","DatabaseGeneratedOption.Identity");
            modelBuilder.Entity<Prescription>().HasKey(p => p.IdPrescription).HasAnnotation("DatabaseGenerated", "DatabaseGeneratedOption.Identity");
            modelBuilder.Entity<Prescription_Medicament>().HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });

            modelBuilder.Entity<Prescription_Medicament>().HasOne(pm => pm.Medicament).WithMany(m => m.Prescription_Medicaments).HasForeignKey(pm => pm.IdMedicament);
            modelBuilder.Entity<Prescription_Medicament>().HasOne(pm => pm.Prescription).WithMany(p => p.Prescription_Medicaments).HasForeignKey(pm => pm.IdPrescription);

            seedData(modelBuilder);
        }
        private void seedData(ModelBuilder modelBuilder)
        {
            var dictMedicament = new List<Medicament>();
            dictMedicament.Add(new Medicament { IdMedicament = 1, Name = "Ketonal", Description = "Opis leku", Type = "Steryd" });
            dictMedicament.Add(new Medicament { IdMedicament = 2, Name = "Apap", Description = "Opis leku2", Type = "Lek" });
            var dictDoctors = new List<Doctor>();
            dictDoctors.Add(new Doctor { IdDoctor = 1, FirstName = "Janina", LastName = "Kowalkiewicz", Email = "janinakowalkiewicz@gmail.com" });
            dictDoctors.Add(new Doctor { IdDoctor = 2, FirstName = "Adrianna", LastName = "Fiołek", Email = "oleksa@gmail.com" });
            var dictPatients = new List<Patient>();
            dictPatients.Add(new Patient { IdPatient = 1, FirstName = "Dominik", LastName = "Domagalski", BirthDate = DateTime.Parse("19-05-1998") });
            dictPatients.Add(new Patient { IdPatient = 2, FirstName = "Dawid", LastName = "Kosa", BirthDate = DateTime.Parse("01-01-1990") });
            var dictPrescriptions = new List<Prescription>();
            dictPrescriptions.Add(new Prescription { IdPrescription = 1, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(5), IdDoctor = 1, IdPatient = 1 });
            dictPrescriptions.Add(new Prescription { IdPrescription = 2, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(5), IdDoctor = 1, IdPatient = 2 });
            dictPrescriptions.Add(new Prescription { IdPrescription = 3, Date = DateTime.Now, DueDate = DateTime.Now.AddDays(5), IdDoctor = 2, IdPatient = 2 });
            var dictPrescriptionMedicaments = new List<Prescription_Medicament>();
            dictPrescriptionMedicaments.Add(new Prescription_Medicament { IdMedicament = 1, IdPrescription = 1, Dose = 3, Details = "Szczegóły1" });
            dictPrescriptionMedicaments.Add(new Prescription_Medicament { IdMedicament = 2, IdPrescription = 1, Dose = 150, Details = "Szczegóły2" });
            dictPrescriptionMedicaments.Add(new Prescription_Medicament { IdMedicament = 1, IdPrescription = 2, Dose = 6, Details = "Szczegóły3" });
            dictPrescriptionMedicaments.Add(new Prescription_Medicament { IdMedicament = 2, IdPrescription = 2, Dose = 50, Details = "Szczegóły4" });
            dictPrescriptionMedicaments.Add(new Prescription_Medicament { IdMedicament = 2, IdPrescription = 3, Dose = 100, Details = "Szczegóły5" });
            modelBuilder.Entity<Medicament>().HasData(dictMedicament);
            modelBuilder.Entity<Doctor>().HasData(dictDoctors);
            modelBuilder.Entity<Patient>().HasData(dictPatients);
            modelBuilder.Entity<Prescription>().HasData(dictPrescriptions);
            modelBuilder.Entity<Prescription_Medicament>().HasData(dictPrescriptionMedicaments);
        }

    }
}
