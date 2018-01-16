using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProdFloor.Migrations
{
    public partial class NewCity1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CurrentFireCode",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Cities");

            migrationBuilder.AddColumn<int>(
                name: "CountryID",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentFireCodeFireCodeID",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateID",
                table: "Cities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryID",
                table: "Cities",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CurrentFireCodeFireCodeID",
                table: "Cities",
                column: "CurrentFireCodeFireCodeID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateID",
                table: "Cities",
                column: "StateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryID",
                table: "Cities",
                column: "CountryID",
                principalTable: "Countries",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_FireCodes_CurrentFireCodeFireCodeID",
                table: "Cities",
                column: "CurrentFireCodeFireCodeID",
                principalTable: "FireCodes",
                principalColumn: "FireCodeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateID",
                table: "Cities",
                column: "StateID",
                principalTable: "States",
                principalColumn: "StateID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryID",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_FireCodes_CurrentFireCodeFireCodeID",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateID",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryID",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CurrentFireCodeFireCodeID",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_StateID",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CurrentFireCodeFireCodeID",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "StateID",
                table: "Cities");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentFireCode",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Cities",
                nullable: true);
        }
    }
}
