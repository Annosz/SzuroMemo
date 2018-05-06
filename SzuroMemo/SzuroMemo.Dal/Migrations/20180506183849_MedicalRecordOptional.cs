using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SzuroMemo.Dal.Migrations
{
    public partial class MedicalRecordOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_MedicalRecordId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalRecordId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MedicalRecordId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_MedicalRecordId",
                table: "Users",
                column: "MedicalRecordId");
        }
    }
}
