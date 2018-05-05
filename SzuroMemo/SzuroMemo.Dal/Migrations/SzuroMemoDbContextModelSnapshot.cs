﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using SzuroMemo.Dal;

namespace SzuroMemo.Dal.Migrations
{
    [DbContext(typeof(SzuroMemoDbContext))]
    partial class SzuroMemoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SzuroMemo.Dal.Entities.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("PictureUrl");

                    b.HasKey("Id");

                    b.ToTable("Hospital");
                });

            modelBuilder.Entity("SzuroMemo.Dal.Entities.LastScreening", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MedicalRecordId");

                    b.Property<int>("NextRecommended");

                    b.Property<int>("ScreeningId");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.HasAlternateKey("MedicalRecordId", "ScreeningId");

                    b.HasIndex("ScreeningId");

                    b.ToTable("LastScreening");
                });

            modelBuilder.Entity("SzuroMemo.Dal.Entities.MedicalRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Height");

                    b.Property<bool>("Male");

                    b.Property<int>("UserId");

                    b.Property<double>("Weight");

                    b.HasKey("Id");

                    b.HasAlternateKey("UserId");

                    b.ToTable("MedicalRecord");
                });

            modelBuilder.Entity("SzuroMemo.Dal.Entities.Occasion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndTime");

                    b.Property<int>("HospitalId");

                    b.Property<int>("ScreeningId");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.HasIndex("ScreeningId");

                    b.ToTable("Occasion");
                });

            modelBuilder.Entity("SzuroMemo.Dal.Entities.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Arrival");

                    b.Property<int>("OccasionId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasAlternateKey("OccasionId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("SzuroMemo.Dal.Entities.Screening", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<bool>("ReferralNeeded");

                    b.HasKey("Id");

                    b.ToTable("Screenings");
                });

            modelBuilder.Entity("SzuroMemo.Dal.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<int>("MedicalRecordId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasAlternateKey("MedicalRecordId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SzuroMemo.Dal.Entities.Hospital", b =>
                {
                    b.OwnsOne("SzuroMemo.Dal.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("HospitalId");

                            b1.Property<string>("Settlement");

                            b1.Property<string>("StreetAddress");

                            b1.Property<int>("ZipCode");

                            b1.ToTable("Hospital");

                            b1.HasOne("SzuroMemo.Dal.Entities.Hospital")
                                .WithOne("Address")
                                .HasForeignKey("SzuroMemo.Dal.Entities.Address", "HospitalId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("SzuroMemo.Dal.Entities.LastScreening", b =>
                {
                    b.HasOne("SzuroMemo.Dal.Entities.MedicalRecord", "MedicalRecord")
                        .WithMany("LastScreenings")
                        .HasForeignKey("MedicalRecordId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SzuroMemo.Dal.Entities.Screening", "Screening")
                        .WithMany("LastScreenings")
                        .HasForeignKey("ScreeningId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SzuroMemo.Dal.Entities.MedicalRecord", b =>
                {
                    b.HasOne("SzuroMemo.Dal.Entities.User", "User")
                        .WithOne("MedicalRecord")
                        .HasForeignKey("SzuroMemo.Dal.Entities.MedicalRecord", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SzuroMemo.Dal.Entities.Occasion", b =>
                {
                    b.HasOne("SzuroMemo.Dal.Entities.Hospital", "Hospital")
                        .WithMany("Occasions")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SzuroMemo.Dal.Entities.Screening", "Screening")
                        .WithMany("Occasions")
                        .HasForeignKey("ScreeningId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SzuroMemo.Dal.Entities.Registration", b =>
                {
                    b.HasOne("SzuroMemo.Dal.Entities.Occasion", "Occasion")
                        .WithMany("Registrations")
                        .HasForeignKey("OccasionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SzuroMemo.Dal.Entities.User", "User")
                        .WithMany("Registrations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
