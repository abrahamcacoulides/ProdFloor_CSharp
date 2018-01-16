using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProdFloor.Migrations
{
    public partial class NewLS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTypes_LandingSystems_LandingSystemID",
                table: "JobTypes");

            migrationBuilder.DropIndex(
                name: "IX_JobTypes_LandingSystemID",
                table: "JobTypes");

            migrationBuilder.DropColumn(
                name: "LandingSystemID",
                table: "JobTypes");

            migrationBuilder.AddColumn<string>(
                name: "UsedIn",
                table: "LandingSystems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsedIn",
                table: "LandingSystems");

            migrationBuilder.AddColumn<int>(
                name: "LandingSystemID",
                table: "JobTypes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobTypes_LandingSystemID",
                table: "JobTypes",
                column: "LandingSystemID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTypes_LandingSystems_LandingSystemID",
                table: "JobTypes",
                column: "LandingSystemID",
                principalTable: "LandingSystems",
                principalColumn: "LandingSystemID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
