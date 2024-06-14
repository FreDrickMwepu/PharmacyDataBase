using Microsoft.EntityFrameworkCore;
using PharmacyDataBase.Model;

namespace PharmacyDataBase.Data;

public class ApplicationDataBaseContext : DbContext
{
    public ApplicationDataBaseContext(DbContextOptions<ApplicationDataBaseContext> options)
        : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet<PharmaceuticalCompany> PharmaceuticalCompanies { get; set; } = null!;
    public DbSet<Drug> Drugs { get; set; } = null!;
    public DbSet<Pharmacy> Pharmacies { get; set; } = null!;
    public DbSet<Prescription> Prescriptions { get; set; } = null!;
    public DbSet<Contract> Contracts { get; set; } = null!;
    public DbSet<PharmacyDrug> PharmacyDrugs { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureCompositeKey(modelBuilder);
        ConfigureRelationships(modelBuilder);
    }

    private void ConfigureCompositeKey(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PharmacyDrug>()
            .HasKey(pd => new { pd.PharmacyName, pd.DrugTradeName });
    }

    private void ConfigureRelationships(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>()
            .HasOne(p => p.PrimaryPhysician)
            .WithMany(d => d.Patient)
            .HasForeignKey(p => p.PrimaryPhysicianSSN);

        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.Patient)
            .WithMany()
            .HasForeignKey(p => p.PatientSSN);

        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.Doctor)
            .WithMany()
            .HasForeignKey(p => p.DoctorSSN);

        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.Drug)
            .WithMany()
            .HasForeignKey(p => p.DrugTradeName);

        modelBuilder.Entity<Contract>()
            .HasOne(c => c.PharmaceuticalCompany)
            .WithMany()
            .HasForeignKey(c => c.CompanyName);

        modelBuilder.Entity<Contract>()
            .HasOne(c => c.Pharmacy)
            .WithMany()
            .HasForeignKey(c => c.PharmacyName);

        modelBuilder.Entity<Contract>()
            .HasOne(c => c.Supervisor)
            .WithMany()
            .HasForeignKey(c => c.SupervisorSSN);

        modelBuilder.Entity<PharmacyDrug>()
            .HasOne(pd => pd.Pharmacy)
            .WithMany(p => p.PharmacyDrug)
            .HasForeignKey(pd => pd.PharmacyName);

        modelBuilder.Entity<PharmacyDrug>()
            .HasOne(pd => pd.Drug)
            .WithMany(d => d.PharmacyDrug)
            .HasForeignKey(pd => pd.DrugTradeName);
    }
}