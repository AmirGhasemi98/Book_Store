using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Store.Persistence.Migrations
{
    public partial class AddBookImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    File = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookImages_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "3d8a3f4e-89e3-4bda-9cba-15341ae34694");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "5f234723-d691-488b-89dd-40763345f1aa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "740c15c3-3fe0-4c79-8c7c-13562b21617f", "AQAAAAEAACcQAAAAEAWcSarBe0rU0a4gSPWTqbpYCKmVgkW9dMczkmblYH/XxpmKn4CmCLCueFxMoSZHAg==", "e943ea3c-33e2-49c0-be3e-2c587f87739a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b023c48-c3a5-4a2a-9ebb-cc9d3aa62682", "AQAAAAEAACcQAAAAEKpaR1SsSCTwPJzxzA92ZZvCgfNI4KFTxm+vXz9KVuIDudzmunQtbxTv9SOWIWY7GA==", "a0e7bb30-2bd4-455e-a645-30c8fb64bbcf" });

            migrationBuilder.CreateIndex(
                name: "IX_BookImages_BookId",
                table: "BookImages",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookImages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d6b32751-e05c-44cc-9810-504051689208");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4d01e55e-9fc6-427a-8b0c-004036e526c6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbca89ed-33a0-4a4a-8d98-bbda23f93cdb", "AQAAAAEAACcQAAAAEFrD9LRVFI7ocSGK3mi3OwQu/cYc6IQQ1ttjVmnDyW2iO3qeyyy+/kv1qybQd54DMg==", "4e0bfc50-9525-444b-9440-a4fcb5034211" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99bf7a33-68b2-41ca-828a-3db78ffe2cea", "AQAAAAEAACcQAAAAEHHF0b8fuKHCFcXk0R7yoY1tVJdmS+MJqqWPKLZ+Vx4Co3R5H1Vn6Ky6oDl0DbEUKA==", "96ac7343-950a-471c-87c9-572f0c4b3d0d" });
        }
    }
}
