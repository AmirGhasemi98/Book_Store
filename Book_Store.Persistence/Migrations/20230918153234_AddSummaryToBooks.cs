using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Store.Persistence.Migrations
{
    public partial class AddSummaryToBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Books");
        }
    }
}
