using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using ProjectHennisJustin.Pages.Billing;
using ProjectHennisJustin.Pages.DataVisualization.Views;
using ProjectHennisJustin.Pages.Diagnosis;
using ProjectHennisJustin.Pages.Doctor;
using ProjectHennisJustin.Pages.Insurance;
using ProjectHennisJustin.Pages.Patient;

namespace ProjectHennisJustin;

public partial class Jhennis1Context : DbContext
{
    public Jhennis1Context(DbContextOptions<Jhennis1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<spGetDiagnosisByFL> spGetDiagnosisByFLs { get; set; }

    public virtual DbSet<spGetMyBill> spGetMyBills { get; set; }

    public virtual DbSet<TblBilling> TblBillings { get; set; }

    public virtual DbSet<TblDiagnosis> TblDiagnoses { get; set; }
    
    public virtual DbSet<TblDoctor> TblDoctors { get; set; }
    public virtual DbSet<TblInsurance> TblInsurances { get; set; }

    public virtual DbSet<TblPatient> TblPatients { get; set; }

    public virtual DbSet<VwCostandTreat> VwCostandTreats { get; set; }

    public virtual DbSet<VwSymptomRelation> VwSymptomRelations { get; set; }

    public IConfiguration myconfig { get; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(myconfig.GetConnectionString("JHennisConnect"));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.Entity<TblBilling>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK__tblBilli__6D903F23067872BD");

            entity.ToTable("tblBilling");

            entity.Property(e => e.BillId).HasColumnName("billID");
            entity.Property(e => e.BillDate).HasColumnName("billDate");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cost");
            entity.Property(e => e.PatientId).HasColumnName("patientID");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblBillings)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__tblBillin__patie__66603565");
        });


        modelBuilder.Entity<TblDiagnosis>(entity =>
        {
            entity.HasKey(e => e.DiagnosisId).HasName("PK__tblDiagn__F1D4AC78881DB5DB");

            entity.ToTable("tblDiagnosis");

            entity.Property(e => e.DiagnosisId).HasColumnName("diagnosisID");
            entity.Property(e => e.BillId).HasColumnName("billID");
            entity.Property(e => e.DiagnosisDate).HasColumnName("diagnosisDate");
            entity.Property(e => e.DiseaseName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("diseaseName");
            entity.Property(e => e.DiseaseType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("diseaseType");
            entity.Property(e => e.DoctorId).HasColumnName("doctorID");
            entity.Property(e => e.PatientId).HasColumnName("patientID");
            entity.Property(e => e.Treatment)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("treatment");

            entity.HasOne(d => d.Bill).WithMany(p => p.TblDiagnoses)
                .HasForeignKey(d => d.BillId)
                .HasConstraintName("FK__tblDiagno__billI__6B24EA82");

            entity.HasOne(d => d.Doctor).WithMany(p => p.TblDiagnoses)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__tblDiagno__docto__6A30C649");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblDiagnoses)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__tblDiagno__patie__693CA210");
        });

        modelBuilder.Entity<TblDoctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__tblDocto__722485962B8F105D");

            entity.ToTable("tblDoctors");

            entity.Property(e => e.DoctorId).HasColumnName("doctorID");
            entity.Property(e => e.CareUnit)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("careUnit");
            entity.Property(e => e.EmploymentDate).HasColumnName("employmentDate");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.NpiNumber).HasColumnName("npiNumber");
        });

        modelBuilder.Entity<TblInsurance>(entity =>
        {
            entity.HasKey(e => e.InsuranceId).HasName("PK__tblInsur__79D82EF0E6DCB463");

            entity.ToTable("tblInsurance");

            entity.Property(e => e.InsuranceId).HasColumnName("insuranceID");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("companyName");
            entity.Property(e => e.Coverage)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("coverage");
            entity.Property(e => e.GroupId).HasColumnName("groupID");
        });

        modelBuilder.Entity<TblPatient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__tblPatie__A17005CC4A892C70");

            entity.ToTable("tblPatient");

            entity.Property(e => e.PatientId).HasColumnName("patientID");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.InsuranceId).HasColumnName("insuranceID");
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.SymptomCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("symptomCode");
            entity.Property(e => e.VisitDate).HasColumnName("visitDate");

            entity.HasOne(d => d.Insurance).WithMany(p => p.TblPatients)
                .HasForeignKey(d => d.InsuranceId)
                .HasConstraintName("FK__tblPatien__insur__6383C8BA");
        });     


        modelBuilder.Entity<VwCostandTreat>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwCostandTreat");

            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TotalCost).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.Treatment)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("treatment");
        });

        modelBuilder.Entity<VwSymptomRelation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwSymptomRelation");

            entity.Property(e => e.DiseaseName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("diseaseName");
            entity.Property(e => e.SymptomCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("symptomCode");
        });

        modelBuilder.Entity<spGetDiagnosisByFL>(entity =>
        {
            entity
            .HasNoKey();
         
            entity
            .Property(e => e.FirstName)
            .HasColumnName("firstName");
            entity
            .Property(e => e.LastName)
            .HasColumnName("lastName");
            entity
            .Property(e => e.DiseaseName)
            .HasColumnName("diseaseName");
            entity
            .Property(e => e.Treatment)
            .HasColumnName("treatment");
            entity
            .Property(e => e.Prescriber)
            .HasColumnName("Prescriber");
            entity
            .Property(e => e.DiagnosisDate)
            .HasColumnName("diagnosisDate");
        });

        modelBuilder.Entity<spGetMyBill>(entity =>
        {
            entity
            .HasNoKey();

            entity
            .Property(e => e.FirstName)
            .HasColumnName("firstName");
            entity
            .Property(e => e.LastName)
            .HasColumnName("lastName");
            entity
            .Property(e => e.Cost)
            .HasColumnName("cost");
            entity
            .Property(e => e.Coverage)
            .HasColumnName("coverage");
        });



    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
