using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.Backend.Migrations
{
    public partial class LoadTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "From", "PostCode", "Street" },
                values: new object[] { 1, "Gossau", "Switzerland", new DateTimeOffset(new DateTime(2021, 2, 20, 11, 24, 46, 750, DateTimeKind.Unspecified).AddTicks(2664), new TimeSpan(0, 1, 0, 0, 0)), 9200, "Gossauerstrasse 15" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "From", "PostCode", "Street" },
                values: new object[] { 2, "Gossau", "Switzerland", new DateTimeOffset(new DateTime(2021, 2, 20, 11, 24, 46, 750, DateTimeKind.Unspecified).AddTicks(2664), new TimeSpan(0, 1, 0, 0, 0)), 9200, "Gossauerstrasse 15" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "From", "PostCode", "Street" },
                values: new object[] { 3, "Gossau", "Switzerland", new DateTimeOffset(new DateTime(2021, 2, 20, 11, 24, 46, 750, DateTimeKind.Unspecified).AddTicks(2664), new TimeSpan(0, 1, 0, 0, 0)), 9200, "Gossauerstrasse 15" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "From", "PostCode", "Street" },
                values: new object[] { 4, "Gossau", "Switzerland", new DateTimeOffset(new DateTime(2021, 2, 20, 11, 24, 46, 750, DateTimeKind.Unspecified).AddTicks(2664), new TimeSpan(0, 1, 0, 0, 0)), 9200, "Gossauerstrasse 15" });
            // Customers
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "Firstname", "Name" },
                values: new object[] { 1, 1, "Max", "Mueller" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "Firstname", "Name" },
                values: new object[] { 2, 2, "Moritz", "Meier" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "Firstname", "Name" },
                values: new object[] { 3, 3, "Tim", "Tanner" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "Firstname", "Name" },
                values: new object[] { 4, 3, "Struppi", "Steiner" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "Firstname", "Name" },
                values: new object[] { 5, 4, "Idefix", "Inauen" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
