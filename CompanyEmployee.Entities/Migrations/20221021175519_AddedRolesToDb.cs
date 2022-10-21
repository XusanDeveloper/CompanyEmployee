using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyEmployee.Entities.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "72583617-27a5-47e9-934d-6dec219abcab", "7dba1da3-f85a-4013-87b3-35f297ea3322", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f6397750-e535-4e31-9ca7-7310051a0ddc", "d898380d-43f5-46fe-bc18-e19e1f2f60fe", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72583617-27a5-47e9-934d-6dec219abcab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6397750-e535-4e31-9ca7-7310051a0ddc");
        }
    }
}
