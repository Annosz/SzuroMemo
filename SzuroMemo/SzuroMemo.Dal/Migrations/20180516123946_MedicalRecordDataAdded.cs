using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SzuroMemo.Dal.Migrations
{
    public partial class MedicalRecordDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BirthName",
                table: "MedicalRecord",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BloodType",
                table: "MedicalRecord",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FatherAllergy",
                table: "MedicalRecord",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FatherAsthma",
                table: "MedicalRecord",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FatherDiabetes",
                table: "MedicalRecord",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FatherHeartDisease",
                table: "MedicalRecord",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FatherObese",
                table: "MedicalRecord",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FatherTumour",
                table: "MedicalRecord",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "MedicalRecord",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MotherAllergy",
                table: "MedicalRecord",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MotherAsthma",
                table: "MedicalRecord",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MotherBirthName",
                table: "MedicalRecord",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MotherDiabetes",
                table: "MedicalRecord",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MotherHeartDisease",
                table: "MedicalRecord",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MotherObese",
                table: "MedicalRecord",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MotherTumour",
                table: "MedicalRecord",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "MedicalRecord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TajNumber",
                table: "MedicalRecord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Settlement",
                table: "MedicalRecord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_StreetAddress",
                table: "MedicalRecord",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Address_ZipCode",
                table: "MedicalRecord",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthName",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "FatherAllergy",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "FatherAsthma",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "FatherDiabetes",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "FatherHeartDisease",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "FatherObese",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "FatherTumour",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "MotherAllergy",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "MotherAsthma",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "MotherBirthName",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "MotherDiabetes",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "MotherHeartDisease",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "MotherObese",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "MotherTumour",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "TajNumber",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "Address_Settlement",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "Address_StreetAddress",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "Address_ZipCode",
                table: "MedicalRecord");
        }
    }
}
