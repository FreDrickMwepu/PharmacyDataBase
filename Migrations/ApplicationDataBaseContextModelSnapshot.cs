﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PharmacyDataBase.Data;

#nullable disable

namespace PharmacyDataBase.Migrations
{
    [DbContext(typeof(ApplicationDataBaseContext))]
    partial class ApplicationDataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("PharmacyDataBase.Model.Contract", b =>
                {
                    b.Property<int>("ContractID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ContractID"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PharmacyName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SupervisorSSN")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ContractID");

                    b.HasIndex("CompanyName");

                    b.HasIndex("PharmacyName");

                    b.HasIndex("SupervisorSSN");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("PharmacyDataBase.Model.Doctor", b =>
                {
                    b.Property<string>("SSN")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasKey("SSN");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("PharmacyDataBase.Model.Drug", b =>
                {
                    b.Property<string>("TradeName")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Formula")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("TradeName");

                    b.HasIndex("CompanyName");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("PharmacyDataBase.Model.Patient", b =>
                {
                    b.Property<string>("SSN")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PrimaryPhysicianSSN")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("SSN");

                    b.HasIndex("PrimaryPhysicianSSN");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("PharmacyDataBase.Model.PharmaceuticalCompany", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Name");

                    b.ToTable("PharmaceuticalCompanies");
                });

            modelBuilder.Entity("PharmacyDataBase.Model.Pharmacy", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Name");

                    b.ToTable("Pharmacies");
                });

            modelBuilder.Entity("PharmacyDataBase.Model.PharmacyDrug", b =>
                {
                    b.Property<string>("PharmacyName")
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(0);

                    b.Property<string>("DrugTradeName")
                        .HasColumnType("varchar(255)")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("PharmacyName", "DrugTradeName");

                    b.HasIndex("DrugTradeName");

                    b.ToTable("PharmacyDrugs");
                });

            modelBuilder.Entity("PharmacyDataBase.Model.Prescription", b =>
                {
                    b.Property<int>("PrescriptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PrescriptionID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DoctorSSN")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DrugTradeName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PatientSSN")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("PrescriptionID");

                    b.HasIndex("DoctorSSN");

                    b.HasIndex("DrugTradeName");

                    b.HasIndex("PatientSSN");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("PharmacyDataBase.Model.Contract", b =>
                {
                    b.HasOne("PharmacyDataBase.Model.PharmaceuticalCompany", "PharmaceuticalCompany")
                        .WithMany()
                        .HasForeignKey("CompanyName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyDataBase.Model.Pharmacy", "Pharmacy")
                        .WithMany()
                        .HasForeignKey("PharmacyName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyDataBase.Model.Doctor", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorSSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PharmaceuticalCompany");

                    b.Navigation("Pharmacy");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("PharmacyDataBase.Model.Drug", b =>
                {
                    b.HasOne("PharmacyDataBase.Model.PharmaceuticalCompany", "PharmaceuticalCompany")
                        .WithMany()
                        .HasForeignKey("CompanyName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PharmaceuticalCompany");
                });

            modelBuilder.Entity("PharmacyDataBase.Model.Patient", b =>
                {
                    b.HasOne("PharmacyDataBase.Model.Doctor", "PrimaryPhysician")
                        .WithMany("Patient")
                        .HasForeignKey("PrimaryPhysicianSSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PrimaryPhysician");
                });

            modelBuilder.Entity("PharmacyDataBase.Model.PharmacyDrug", b =>
                {
                    b.HasOne("PharmacyDataBase.Model.Drug", "Drug")
                        .WithMany("PharmacyDrug")
                        .HasForeignKey("DrugTradeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyDataBase.Model.Pharmacy", "Pharmacy")
                        .WithMany("PharmacyDrug")
                        .HasForeignKey("PharmacyName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drug");

                    b.Navigation("Pharmacy");
                });

            modelBuilder.Entity("PharmacyDataBase.Model.Prescription", b =>
                {
                    b.HasOne("PharmacyDataBase.Model.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorSSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyDataBase.Model.Drug", "Drug")
                        .WithMany()
                        .HasForeignKey("DrugTradeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyDataBase.Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientSSN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Drug");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PharmacyDataBase.Model.Doctor", b =>
                {
                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PharmacyDataBase.Model.Drug", b =>
                {
                    b.Navigation("PharmacyDrug");
                });

            modelBuilder.Entity("PharmacyDataBase.Model.Pharmacy", b =>
                {
                    b.Navigation("PharmacyDrug");
                });
#pragma warning restore 612, 618
        }
    }
}
