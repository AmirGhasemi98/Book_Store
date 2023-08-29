using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Store.Persistence.Migrations
{
    public partial class DeleteImageFromBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "9927413a-b476-494e-b98e-6937179e139e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c1cddc69-4abd-4ffb-a1a3-d95f08a9c5e7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e1697e5e-1e17-44a7-821f-f1f9737f4d33", "AQAAAAEAACcQAAAAECPynJtQ4+4V1730o7BjrE0kmmb+csq8jQkN93XuOJr/Vlmn7lI54RUG33JYrJuv3w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "231df1fc-4a14-40f9-ba0d-349de2ac7968", "AQAAAAEAACcQAAAAEDbvjqvyZtSSAMK6ihKa2AIc4BYpivHr3N2s9ZU1GfDhTE5jcdMTpItxjUvo2rldtg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Books",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "740c15c3-3fe0-4c79-8c7c-13562b21617f", "AQAAAAEAACcQAAAAEAWcSarBe0rU0a4gSPWTqbpYCKmVgkW9dMczkmblYH/XxpmKn4CmCLCueFxMoSZHAg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7b023c48-c3a5-4a2a-9ebb-cc9d3aa62682", "AQAAAAEAACcQAAAAEKpaR1SsSCTwPJzxzA92ZZvCgfNI4KFTxm+vXz9KVuIDudzmunQtbxTv9SOWIWY7GA==" });
        }
    }
}
