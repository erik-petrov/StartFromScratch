using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StartFromScratch.Data.Migrations
{
    public partial class changeTomeetUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "Buy");

            migrationBuilder.RenameColumn(
                name: "Until",
                table: "Buy",
                newName: "Meetup");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Meetup",
                table: "Buy",
                newName: "Until");

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "Buy",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
