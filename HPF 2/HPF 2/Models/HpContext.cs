using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HPF_2.Models;

public partial class HpContext : DbContext
{
    public HpContext(DbContextOptions<HpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<PatientHistory> PatientHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Connection string configuration
        optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels; Database=HP; Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("appointments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Duration).HasColumnName("duration");

        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("doctors");

            entity.Property(e => e.Department).HasColumnName("department");
            entity.Property(e => e.IsLogged).HasColumnName("isloged");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Salary).HasColumnName("salary");

            
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("patients");
        });

        modelBuilder.Entity<PatientHistory>(entity =>
        {
            entity.ToTable("Patient_Histories");

            entity.Property(e => e.DoctorId).HasColumnName("doctorID");
            entity.Property(e => e.PatientId).HasColumnName("patientID");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.TreatmentStat).HasColumnName("Treatment_Stat");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
