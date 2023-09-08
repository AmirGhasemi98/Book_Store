using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Store.Persistence.Migrations
{
    public partial class UpdateRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserTokenId",
                table: "RefreshTokens");

            migrationBuilder.AddColumn<string>(
                name: "JwtTokenId",
                table: "RefreshTokens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JwtTokenId",
                table: "RefreshTokens");

            migrationBuilder.AddColumn<int>(
                name: "UserTokenId",
                table: "RefreshTokens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
