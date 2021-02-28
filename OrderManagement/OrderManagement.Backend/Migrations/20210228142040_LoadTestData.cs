using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.Backend.Migrations
{
    public partial class LoadTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductGroups_ParentId",
                table: "Products");

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
                    { 4, "Kuechenartikel", 1 },
                    { 2, "Milch Produkte", 1 },
                    { 3, "Fruechte / Gemuese", 1 },
                    { 5, "Fleisch", 1 }
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
                    { 14, 14, new DateTime(2019, 12, 30, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 13, 13, new DateTime(2019, 10, 5, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 11, 11, new DateTime(2019, 5, 13, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 10, 10, new DateTime(2020, 11, 30, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 9, 9, new DateTime(2020, 8, 25, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 22, 22, new DateTime(2018, 2, 16, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 12, 12, new DateTime(2019, 5, 14, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 29, 7, new DateTime(2017, 12, 26, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 23, 1, new DateTime(2018, 1, 11, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 8, 8, new DateTime(2020, 2, 20, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 24, 2, new DateTime(2018, 5, 13, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2020, 9, 12, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 25, 3, new DateTime(2018, 6, 12, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2020, 2, 10, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2020, 11, 5, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2020, 5, 10, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 27, 5, new DateTime(2017, 12, 26, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 6, 6, new DateTime(2020, 6, 10, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 28, 6, new DateTime(2021, 12, 29, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 7, 7, new DateTime(2020, 3, 15, 9, 10, 55, 0, DateTimeKind.Unspecified) },
                    { 26, 4, new DateTime(2018, 4, 27, 9, 10, 55, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "ParentId", "Price" },
                values: new object[,]
                {
                    { 7, "Landjaeger", 4, 1.20m },
                    { 5, "Speck", 4, 2.65m },
                    { 8, "Löffel", 3, 6.50m },
                    { 4, "Pfanne", 3, 10.95m },
                    { 10, "Gurke", 2, 1.20m },
                    { 14, "Zwiebel", 2, 0.20m },
                    { 9, "Kartoffel", 2, 7.65m },
                    { 3, "Salat", 2, 3.6m },
                    { 12, "Schinken", 4, 15.20m },
                    { 16, "Banane", 2, 1.60m },
                    { 13, "Salami", 4, 8.90m }
                });

            migrationBuilder.InsertData(
                table: "OrderPositions",
                columns: new[] { "Id", "Count", "OrderId", "Position", "ProductId" },
                values: new object[,]
                {
                    { 1, 5, 1, 1, 1 },
                    { 14, 26, 8, 1, 1 },
                    { 32, 88, 22, 1, 1 },
                    { 15, 361, 9, 1, 1 },
                    { 16, 20, 10, 1, 1 },
                    { 17, 515, 11, 1, 1 },
                    { 18, 2, 12, 1, 1 },
                    { 19, 1, 13, 1, 1 },
                    { 20, 8, 13, 2, 1 },
                    { 43, 1, 29, 1, 1 },
                    { 21, 30, 13, 3, 1 },
                    { 23, 2, 14, 1, 1 },
                    { 24, 7, 15, 1, 1 },
                    { 25, 8, 16, 1, 1 },
                    { 26, 5, 17, 1, 1 },
                    { 27, 9, 18, 1, 1 },
                    { 28, 3, 18, 2, 1 },
                    { 29, 10, 19, 1, 1 },
                    { 30, 20, 20, 1, 1 },
                    { 22, 40, 13, 4, 1 },
                    { 31, 15, 21, 1, 1 },
                    { 13, 7, 7, 2, 1 },
                    { 42, 2, 28, 1, 1 },
                    { 33, 20, 23, 1, 1 },
                    { 3, 2, 2, 1, 1 },
                    { 34, 30, 24, 1, 1 },
                    { 4, 1, 3, 1, 1 },
                    { 5, 8, 3, 2, 1 },
                    { 6, 12, 3, 3, 1 },
                    { 7, 15, 3, 4, 1 },
                    { 35, 80, 25, 1, 1 },
                    { 12, 5, 7, 1, 1 },
                    { 36, 90, 25, 2, 1 },
                    { 38, 42, 25, 4, 1 },
                    { 39, 15, 25, 5, 1 },
                    { 8, 9, 4, 1, 1 },
                    { 9, 8, 4, 2, 1 },
                    { 40, 35, 26, 1, 1 },
                    { 10, 4, 5, 1, 1 },
                    { 41, 45, 27, 1, 1 },
                    { 11, 3, 6, 1, 1 },
                    { 37, 100, 25, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderPositions",
                columns: new[] { "Id", "Count", "OrderId", "Position", "ProductId" },
                values: new object[] { 2, 3, 1, 2, 3 });

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
                name: "FK_Products_ProductGroups_ParentId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "OrderPositions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductGroups",
                keyColumn: "Id",
                keyValue: 1);

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
