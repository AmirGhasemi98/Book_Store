using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Store.Persistence.Migrations
{
    public partial class UpdateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "d0a09309-b170-4380-b183-4b3bd2d6fbb5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "495fc749-1c68-4b50-85cc-a0f43d1b1b5f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3c74e21-0220-41f1-a594-13a95812c7df", "AQAAAAEAACcQAAAAEA5wI+Yv2pZF0bsxH6w8TvzCHQQ6WnknUOeOEv9G961rVANfR8158e1s90HneKFaZQ==", "fd082ef5-d1d9-4809-9b8c-fb04d25ed106" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4bd89ae-3267-4844-85c3-01b4859fce6d", "AQAAAAEAACcQAAAAECY4gmT+twVhyTgwR0uKkgIG3CYAyX746G+ynpZ1VDJU7+7B+j1fRcIvpw/BLURRjw==", "888e23d8-0c27-4330-8769-ada1f8e69769" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "19fba86c-321e-48b2-a5c1-594fa6d2f4a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "deeea2d3-bbad-4f3a-a71e-125bcfe6c160");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "354e1a0a-b8e5-41b4-8628-a05ca05e53b3", "AQAAAAEAACcQAAAAELchkJs2PPRfbi5YGvmfxxWX/jujvqMTXI8yiW1tJJOxf6rFLXVR3HuK681bAyel1g==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d0e88d4-8f7a-4414-bd63-fdd34e09ca3f", "AQAAAAEAACcQAAAAEHIzUKxQutGFm0LlBT8T5lKaBoFSJjYdk2gfjDo6phGFXc6Fp/CIAaA6B0AlwDoZ7w==", null });
        }
    }
}
