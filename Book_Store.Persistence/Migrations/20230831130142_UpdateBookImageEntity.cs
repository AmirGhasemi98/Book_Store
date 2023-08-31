using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Store.Persistence.Migrations
{
    public partial class UpdateBookImageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "BookImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "BookImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "BookImages");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "BookImages");
        }
    }
}
