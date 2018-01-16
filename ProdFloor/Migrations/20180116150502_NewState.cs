using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProdFloor.Migrations
{
    public partial class NewState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryID",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_CountryID",
                table: "States");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "States");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "States",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "States");

            migrationBuilder.AddColumn<int>(
                name: "CountryID",
                table: "States",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryID",
                table: "States",
                column: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_CountryID",
                table: "States",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
