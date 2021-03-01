using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.Backend.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });
            migrationBuilder.Sql($@"
                ALTER TABLE dbo.Addresses
                ADD
                    valid_from datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
                    valid_until datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT( DATETIME2, '9999-12-31 23:59:59' ) NOT NULL,
                    PERIOD FOR SYSTEM_TIME (valid_from, valid_until)
                ALTER TABLE dbo.Addresses
                    SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.dw_addresses_dmsnHistory));"
                );


            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductGroups_ProductGroups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.Sql($@"
                ALTER TABLE dbo.ProductGroups
                ADD
                    valid_from datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
                    valid_until datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT( DATETIME2, '9999-12-31 23:59:59' ) NOT NULL,
                    PERIOD FOR SYSTEM_TIME (valid_from, valid_until)
                ALTER TABLE dbo.ProductGroups
                    SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.dw_product_groups_dmsnHistory));"
            );


            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.Sql($@"
                ALTER TABLE dbo.Customers
                ADD
                    valid_from datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
                    valid_until datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT( DATETIME2, '9999-12-31 23:59:59' ) NOT NULL,
                    PERIOD FOR SYSTEM_TIME (valid_from, valid_until)
                ALTER TABLE dbo.Customers
                    SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.dw_customers_dmsnHistory));"
            );


            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProductGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.Sql($@"
                ALTER TABLE dbo.Products
                ADD
                    valid_from datetime2 GENERATED ALWAYS AS ROW START DEFAULT SYSUTCDATETIME() NOT NULL,
                    valid_until datetime2 GENERATED ALWAYS AS ROW END DEFAULT CONVERT( DATETIME2, '9999-12-31 23:59:59' ) NOT NULL,
                    PERIOD FOR SYSTEM_TIME (valid_from, valid_until)
                ALTER TABLE dbo.Products
                    SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.dw_products_dmsnHistory));"
           );


            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPositions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPositions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PostCode", "Street" },
                values: new object[,]
                {
                    { 1, "Gossau", "Switzerland", 9200, "Gossauerstrasse 15" },
                    { 20, "Bielefeld", "Germany", 33602, "August-Bebel-Strasse 108" },
                    { 19, "Wuerzburg", "Germany", 97074, "Grasweg 2" },
                    { 18, "Erlach", "Switzerland", 3235, "Altstadt 27" },
                    { 17, "Gerlafingen", "Switzerland", 4563, "Muehlegasse 32" },
                    { 16, "Dietikon", "Switzerland", 8953, "Oetwilerstrasse 13" },
                    { 15, "Kloten", "Switzerland", 8302, "Flughafenstrasse 25" },
                    { 14, "Nuerensdorf", "Switzerland", 8309, "Kanzleistrasse 4" },
                    { 13, "Winterthur", "Switzerland", 8400, "Wartstrasse 16" },
                    { 12, "Frauenfeld", "Switzerland", 8500, "Kurzenerchingerstrasse 5" },
                    { 11, "Muellheim", "Switzerland", 8555, "Bahnhofstrasse 16" },
                    { 10, "Kreuzlingen", "Switzerland", 8280, "Sonnenstrasse 35" },
                    { 9, "Walenstadt", "Switzerland", 8880, "Walenseestrasse 34" },
                    { 8, "Muenstertal", "Switzerland", 7536, "Chasatschas 111" },
                    { 7, "Biasca", "Switzerland", 6710, "Via Lucomagno 115" },
                    { 6, "Adelboden", "Switzerland", 3715, "Zelgstrasse 2" },
                    { 5, "Burgdorf", "Switzerland", 3400, "Polieregasse 2" },
                    { 4, "Wil", "Switzerland", 9500, "Rebhofweg 10" },
                    { 3, "Appenzell", "Switzerland", 9050, "Lehnmattstrasse 21" },
                    { 2, "Appenzell", "Switzerland", 9050, "Ronis 2" },
                    { 21, "Bucharest", "Romania", 30167, "Strada Vasile Lascar 15" }
                });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 1, "Products", null });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "Firstname", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Alfred", "Koller" },
                    { 21, 21, "Antonia", "Faessler" },
                    { 20, 20, "Tamara", "Ebneter" },
                    { 19, 19, "Ruedi", "Wuerth" },
                    { 18, 18, "Karin", "Geher" },
                    { 17, 17, "Nicole", "Fritsche" },
                    { 16, 16, "Emanuel", "Steingruber" },
                    { 15, 15, "Stefanie", "Staub" },
                    { 13, 13, "Patrick", "Stadler" },
                    { 12, 12, "Konrad", "Mazenauer" },
                    { 11, 11, "Roland", "Zumstein" },
                    { 14, 14, "Natascha", "Luechinger" },
                    { 10, 10, "Tobias", "Wirth" },
                    { 2, 2, "Karl", "Meier" },
                    { 23, 10, "Pascal", "Koller" },
                    { 4, 4, "Mike", "Faessler" },
                    { 5, 5, "Remo", "Kessler" },
                    { 6, 6, "Tim", "Manser" },
                    { 3, 3, "Marco", "Ebneter" },
                    { 8, 8, "Michael", "Messmer" },
                    { 22, 8, "Alejandro", "Faessler" },
                    { 9, 9, "Berta", "Keiser" },
                    { 7, 7, "Martin", "Streule" }
                });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 3, "Fruechte / Gemuese", 1 },
                    { 2, "Milch Produkte", 1 },
                    { 4, "Kuechenartikel", 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "ParentId", "Price" },
                values: new object[,]
                {
                    { 1, "Milch", 1, 1.25m },
                    { 2, "Butter", 1, 2.3m },
                    { 6, "Kaese", 1, 2.50m },
                    { 11, "Mascarpone", 1, 1.30m },
                    { 15, "Majonaise", 1, 3.35m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "Date" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 12, 10, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 21, 21, new DateTime(2018, 8, 3, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 20, 20, new DateTime(2018, 11, 9, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 19, 19, new DateTime(2018, 12, 18, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 18, 18, new DateTime(2019, 8, 17, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 17, 17, new DateTime(2019, 6, 28, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 16, 16, new DateTime(2019, 1, 12, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 15, 15, new DateTime(2019, 2, 23, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 13, 13, new DateTime(2019, 10, 5, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 12, 12, new DateTime(2019, 5, 14, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 11, 11, new DateTime(2019, 5, 13, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 10, 10, new DateTime(2020, 11, 30, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 9, 9, new DateTime(2020, 8, 25, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 22, 22, new DateTime(2018, 2, 16, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 14, 14, new DateTime(2019, 12, 30, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 29, 7, new DateTime(2017, 12, 26, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 8, 8, new DateTime(2020, 2, 20, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 23, 1, new DateTime(2018, 1, 11, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2020, 11, 5, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 24, 2, new DateTime(2018, 5, 13, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2020, 9, 12, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 25, 3, new DateTime(2018, 6, 12, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2020, 2, 10, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2020, 5, 10, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 27, 5, new DateTime(2017, 12, 26, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 6, 6, new DateTime(2020, 6, 10, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 28, 6, new DateTime(2021, 12, 29, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 7, 7, new DateTime(2020, 3, 15, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 26, 4, new DateTime(2018, 4, 27, 9, 10, 55, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 7, "Schoggi-Milch", 2 },
                    { 9, "Erdbeeren", 3 },
                    { 5, "Käse", 2 },
                    { 8, "Messer", 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "ParentId", "Price" },
                values: new object[,]
                {
                    { 16, "Banane", 2, 1.60m },
                    { 10, "Gurke", 2, 1.20m },
                    { 9, "Kartoffel", 2, 7.65m },
                    { 4, "Pfanne", 3, 10.95m },
                    { 8, "Löffel", 3, 6.50m },
                    { 13, "Salami", 4, 8.90m },
                    { 5, "Speck", 4, 2.65m },
                    { 7, "Landjaeger", 4, 1.20m },
                    { 12, "Schinken", 4, 15.20m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "ParentId", "Price" },
                values: new object[] { 14, "Zwiebel", 2, 0.20m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "ParentId", "Price" },
                values: new object[] { 3, "Salat", 2, 3.6m });

            migrationBuilder.InsertData(
                table: "OrderPositions",
                columns: new[] { "Id", "Count", "OrderId", "Position", "ProductId" },
                values: new object[,]
                {
                    { 1, 5, 1, 1, 1 },
                    { 32, 88, 22, 1, 1 },
                    { 15, 361, 9, 1, 1 },
                    { 16, 20, 10, 1, 1 },
                    { 17, 515, 11, 1, 1 },
                    { 18, 2, 12, 1, 1 },
                    { 19, 1, 13, 1, 1 },
                    { 20, 8, 13, 2, 1 },
                    { 21, 30, 13, 3, 1 },
                    { 14, 26, 8, 1, 1 },
                    { 22, 40, 13, 4, 1 },
                    { 24, 7, 15, 1, 1 },
                    { 25, 8, 16, 1, 1 },
                    { 26, 5, 17, 1, 1 },
                    { 27, 9, 18, 1, 1 },
                    { 28, 3, 18, 2, 1 },
                    { 29, 10, 19, 1, 1 },
                    { 30, 20, 20, 1, 1 },
                    { 31, 15, 21, 1, 1 },
                    { 23, 2, 14, 1, 1 },
                    { 43, 1, 29, 1, 1 },
                    { 13, 7, 7, 2, 1 },
                    { 12, 5, 7, 1, 1 },
                    { 33, 20, 23, 1, 1 },
                    { 3, 2, 2, 1, 1 },
                    { 34, 30, 24, 1, 1 },
                    { 4, 1, 3, 1, 1 },
                    { 5, 8, 3, 2, 1 },
                    { 6, 12, 3, 3, 1 },
                    { 7, 15, 3, 4, 1 },
                    { 35, 80, 25, 1, 1 },
                    { 36, 90, 25, 2, 1 },
                    { 37, 100, 25, 3, 1 },
                    { 38, 42, 25, 4, 1 },
                    { 39, 15, 25, 5, 1 },
                    { 8, 9, 4, 1, 1 },
                    { 9, 8, 4, 2, 1 },
                    { 40, 35, 26, 1, 1 },
                    { 10, 4, 5, 1, 1 },
                    { 41, 45, 27, 1, 1 },
                    { 11, 3, 6, 1, 1 },
                    { 42, 2, 28, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderPositions",
                columns: new[] { "Id", "Count", "OrderId", "Position", "ProductId" },
                values: new object[] { 2, 3, 1, 2, 3 });

            migrationBuilder.InsertData(
                table: "ProductGroups",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[] { 6, "Appenzeller", 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPositions_OrderId",
                table: "OrderPositions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPositions_ProductId",
                table: "OrderPositions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroups_ParentId",
                table: "ProductGroups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ParentId",
                table: "Products",
                column: "ParentId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPositions");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ProductGroups");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.Sql(@"drop function GetAmountNet;
                                    go");
        }
    }
}
