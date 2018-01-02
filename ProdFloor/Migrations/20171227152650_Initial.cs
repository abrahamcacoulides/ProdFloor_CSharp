using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProdFloor.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Contractor = table.Column<string>(nullable: true),
                    JobType = table.Column<string>(nullable: true),
                    Cust = table.Column<string>(nullable: true),
                    JobNum = table.Column<int>(nullable: false),
                    JobState = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PO = table.Column<int>(nullable: false),
                    SafetyCode = table.Column<string>(nullable: true),
                    ShipDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
