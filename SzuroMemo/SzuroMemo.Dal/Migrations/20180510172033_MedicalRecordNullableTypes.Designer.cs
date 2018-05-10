﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using SzuroMemo.Dal;
using SzuroMemo.Dal.Entities;

namespace SzuroMemo.Dal.Migrations
{
    [DbContext(typeof(SzuroMemoDbContext))]
    [Migration("20180510172033_MedicalRecordNullableTypes")]
    partial class MedicalRecordNullableTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

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

                    b.Property<int?>("Gender");

                    b.Property<double?>("Height");

                    b.Property<int>("UserId");

                    b.Property<int?>("UserId1");

                    b.Property<double?>("Weight");

                    b.HasKey("Id");

                    b.HasAlternateKey("UserId");

                    b.HasIndex("UserId1");

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

                    b.ToTable("Screening");
                });

            modelBuilder.Entity("SzuroMemo.Dal.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("SzuroMemo.Dal.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("SzuroMemo.Dal.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SzuroMemo.Dal.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("SzuroMemo.Dal.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                        .WithMany()
                        .HasForeignKey("UserId1");
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
