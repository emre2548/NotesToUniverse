using Microsoft.EntityFrameworkCore.Migrations;

namespace NotesToUniverse.DataAccess.Migrations
{
    public partial class UpdateDBImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Notes");
        }
    }
}
