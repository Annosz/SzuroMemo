using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SzuroMemo.Dal.Migrations
{
    public partial class MedicalRecordEnumerationAndKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_Users_UserId",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "MedicalRecordId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Male",
                table: "MedicalRecord");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "MedicalRecord",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "MedicalRecord",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_UserId1",
                table: "MedicalRecord",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_Users_UserId1",
                table: "MedicalRecord",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecord_Users_UserId1",
                table: "MedicalRecord");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecord_UserId1",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "MedicalRecord");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "MedicalRecord");

            migrationBuilder.AddColumn<int>(
                name: "MedicalRecordId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Male",
                table: "MedicalRecord",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecord_Users_UserId",
                table: "MedicalRecord",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
