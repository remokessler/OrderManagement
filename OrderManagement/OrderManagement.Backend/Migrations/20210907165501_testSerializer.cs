using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.Backend.Migrations
{
    public partial class testSerializer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "1",
                column: "Password",
                value: "test1234");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "1",
                column: "Password",
                value: null);
        }
    }
}
