using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StartFromScratch.Data.Migrations
{
    public partial class make_image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Rent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Buy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Rent");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Buy");
        }
    }
}
