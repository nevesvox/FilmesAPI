using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class customidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999998,
                column: "ConcurrencyStamp",
                value: "69c66c91-427b-40c8-8f01-a2fd84b39a0d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "f9c78680-72e3-4b09-84bc-771a91e6765a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bed68b0d-acaf-410a-a7be-2b69292c5516", "AQAAAAEAACcQAAAAECjwV0RGlNUxaJdlIgZMOSEd8d9WtJVqOkPYppj70UgT4dKPsSgmZfg/XjkeJgkULA==", "bbf60fc6-61a5-4a06-b13f-f0b48ce18f0b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999998,
                column: "ConcurrencyStamp",
                value: "eec161ce-60c1-4849-a431-7bd981230182");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "5998c193-3702-4986-9371-2158d728aeb6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa9ad7ea-f25c-4ef5-80e1-db9374ed58a4", "AQAAAAEAACcQAAAAEENMt7PZyuuZVATgGf804vsNm0F6M7phsx2V4u3ZGeI7ZP/4yYCmg4ON0pLvOXYEfQ==", "dd61a75d-3fa3-48cd-a255-649408d4d499" });
        }
    }
}
