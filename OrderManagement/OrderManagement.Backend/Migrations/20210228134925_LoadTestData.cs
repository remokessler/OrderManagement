using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.Backend.Migrations
{
    public partial class LoadTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Adresses_AdressId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGroups_ParentId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Adresses");

            migrationBuilder.RenameTable(
                name: "Adresses",
                newName: "Addresses");

            migrationBuilder.RenameColumn(
                name: "AdressId",
                table: "Customers",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_AdressId",
                table: "Customers",
                newName: "IX_Customers_AddressId");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "ProductGroups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Addresses_AddressId",
                table: "Customers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductGroups_ParentId",
                table: "Products",
                column: "ParentId",
                principalTable: "ProductGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_AddressId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGroups_ParentId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Adresses");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Customers",
                newName: "AdressId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                newName: "IX_Customers_AdressId");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "ProductGroups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "From",
                table: "Adresses",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adresses",
                table: "Adresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Adresses_AdressId",
                table: "Customers",
                column: "AdressId",
                principalTable: "Adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductGroups_ParentId",
                table: "Products",
                column: "ParentId",
                principalTable: "ProductGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
