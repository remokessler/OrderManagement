using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.Backend.Migrations
{
    public partial class AddFunctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"create function GetAmountNet
                (
                    @OrderId int
                )
                returns float
                as 
                begin
	                return (select Sum((Count * Price)) as 'AmountNet' from OrderPositions 
		                inner join Products on OrderPositions.ProductId = Products.Id
		                where OrderPositions.OrderId = @OrderId)
                end;
                go");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop function GetAmountNet;
                                    go");
        }
    }
}
