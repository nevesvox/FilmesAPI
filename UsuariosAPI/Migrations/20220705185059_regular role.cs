using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class regularrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "5998c193-3702-4986-9371-2158d728aeb6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 999998, "eec161ce-60c1-4849-a431-7bd981230182", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa9ad7ea-f25c-4ef5-80e1-db9374ed58a4", "AQAAAAEAACcQAAAAEENMt7PZyuuZVATgGf804vsNm0F6M7phsx2V4u3ZGeI7ZP/4yYCmg4ON0pLvOXYEfQ==", "dd61a75d-3fa3-48cd-a255-649408d4d499" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "dd352e5a-5929-4412-b509-e327d74761cb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b921c65-1514-484c-8b1d-59e4c981954e", "AQAAAAEAACcQAAAAEF8YcrVYD54TazK9+rkicBrqWugnUt8zL0Uttx0ED1w11px9Z4xjnT/XB2TxJQzXJQ==", "4eba67eb-6a48-4600-822e-af936452e46f" });
        }
    }
}
