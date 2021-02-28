﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.Backend.Migrations
{
    public partial class ChangeAddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                UPDATE dbo.Customers
                SET AddressId = 5
                WHERE Id = 10");
            migrationBuilder.Sql($@"
                UPDATE dbo.Customers
                SET AddressId = 10
                WHERE Id = 20");
            migrationBuilder.Sql($@"
                UPDATE dbo.Customers
                SET AddressId = 20
                WHERE Id = 7");
            migrationBuilder.Sql($@"
                UPDATE dbo.Customers
                SET AddressId = 7
                WHERE Id = 1");
            migrationBuilder.Sql($@"
                UPDATE dbo.Customers
                SET AddressId = 1
                WHERE Id = 10");
            migrationBuilder.Sql($@"
                UPDATE dbo.Customers
                SET AddressId = 10
                WHERE Id = 3");
            migrationBuilder.Sql($@"
                UPDATE dbo.Customers
                SET AddressId = 3
                WHERE Id = 4");
            migrationBuilder.Sql($@"
                UPDATE dbo.Customers
                SET AddressId = 4
                WHERE Id = 2");
            migrationBuilder.Sql($@"
                UPDATE dbo.Customers
                SET AddressId = 2
                WHERE Id = 23");

            migrationBuilder.Sql($@"
                UPDATE dbo.Products
                SET Price = 1.2
                WHERE Id = 1");
            migrationBuilder.Sql($@"
                UPDATE dbo.Products
                SET Price = 1.5
                WHERE Id = 5");
            migrationBuilder.Sql($@"
                UPDATE dbo.Products
                SET Price = 5.8
                WHERE Id = 4");
            migrationBuilder.Sql($@"
                UPDATE dbo.Products
                SET Price = 3.9
                WHERE Id = 3");
            migrationBuilder.Sql($@"
                UPDATE dbo.Products
                SET Price = 2.2
                WHERE Id = 15");
            migrationBuilder.Sql($@"
                UPDATE dbo.Products
                SET Price = 8.2
                WHERE Id = 9");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
