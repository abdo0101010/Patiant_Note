using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PatiantNoteCQRS.Models;

public partial class MedicalPassportContext : DbContext
{
    public MedicalPassportContext()
    {
    }

    public MedicalPassportContext(DbContextOptions<MedicalPassportContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmergencyAccessToken> EmergencyAccessTokens { get; set; }

    public virtual DbSet<ExtractedDocumentDatum> ExtractedDocumentData { get; set; }

    public virtual DbSet<LabTestResult> LabTestResults { get; set; }

    public virtual DbSet<MedicalDocument> MedicalDocuments { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PrescriptionItem> PrescriptionItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmergencyAccessToken>(entity =>
        {
            entity.HasKey(e => e.TokenId).HasName("PK__Emergenc__658FEEEAA8176261");

            entity.HasIndex(e => e.AccessToken, "UQ__Emergenc__A4E40AB262D0676B").IsUnique();

            entity.Property(e => e.AccessToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ExpiresAt).HasColumnType("datetime");

            entity.HasOne(d => d.Patient).WithMany(p => p.EmergencyAccessTokens)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Emergency__Patie__693CA210");
        });

        modelBuilder.Entity<ExtractedDocumentDatum>(entity =>
        {
            entity.HasKey(e => e.ExtractionId).HasName("PK__Extracte__DA8CD94EA296D435");

            entity.HasIndex(e => e.DocumentId, "UQ__Extracte__1ABEEF0E470CD245").IsUnique();

            entity.Property(e => e.DoctorName).HasMaxLength(150);
            entity.Property(e => e.EntityName).HasMaxLength(150);

            entity.HasOne(d => d.Document).WithOne(p => p.ExtractedDocumentDatum)
                .HasForeignKey<ExtractedDocumentDatum>(d => d.DocumentId)
                .HasConstraintName("FK__Extracted__Docum__5DCAEF64");
        });

        modelBuilder.Entity<LabTestResult>(entity =>
        {
            entity.HasKey(e => e.LabTestResultId).HasName("PK__LabTestR__D5812DC353C4B2A7");

            entity.Property(e => e.IsAbnormal).HasDefaultValue(false);
            entity.Property(e => e.ReferenceRange).HasMaxLength(100);
            entity.Property(e => e.ResultValue).HasMaxLength(50);
            entity.Property(e => e.TestName).HasMaxLength(200);
            entity.Property(e => e.Unit).HasMaxLength(50);

            entity.HasOne(d => d.Extraction).WithMany(p => p.LabTestResults)
                .HasForeignKey(d => d.ExtractionId)
                .HasConstraintName("FK__LabTestRe__Extra__6477ECF3");
        });

        modelBuilder.Entity<MedicalDocument>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__MedicalD__1ABEEF0F4E646D3E");

            entity.Property(e => e.DocumentType).HasMaxLength(30);
            entity.Property(e => e.FileUrl).HasMaxLength(500);
            entity.Property(e => e.ProcessingStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            entity.Property(e => e.UploadDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Patient).WithMany(p => p.MedicalDocuments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__MedicalDo__Patie__59FA5E80");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC366BCBA5FE2");

            entity.HasIndex(e => e.UserId, "UQ__Patients__1788CC4DD6BCA7CE").IsUnique();

            entity.Property(e => e.BloodType)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactName).HasMaxLength(150);
            entity.Property(e => e.EmergencyContactPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithOne(p => p.Patient)
                .HasForeignKey<Patient>(d => d.UserId)
                .HasConstraintName("FK__Patients__UserId__534D60F1");
        });

        modelBuilder.Entity<PrescriptionItem>(entity =>
        {
            entity.HasKey(e => e.PrescriptionItemId).HasName("PK__Prescrip__1AADD9FAD1580D88");

            entity.Property(e => e.Dosage).HasMaxLength(100);
            entity.Property(e => e.Duration).HasMaxLength(100);
            entity.Property(e => e.Frequency).HasMaxLength(100);
            entity.Property(e => e.MedicationName).HasMaxLength(200);

            entity.HasOne(d => d.Extraction).WithMany(p => p.PrescriptionItems)
                .HasForeignKey(d => d.ExtractionId)
                .HasConstraintName("FK__Prescript__Extra__60A75C0F");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C84EA1049");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Users__85FB4E389A63A0CF").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534FF925BCA").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
