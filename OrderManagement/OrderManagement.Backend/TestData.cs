using Microsoft.EntityFrameworkCore;
using OrderManagement.Backend.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using OrderManagement.Backend.Serializer;

namespace OrderManagement.Backend
{
    public class TestData
    {
        public TestData(ModelBuilder modelbuilder)
        {
            var address = new List<Address>();
            var customer = new List<Customer>();
            var order = new List<Order>();
            var product = new List<Product>();
            var orderpos = new List<OrderPosition>();
            var productgrp = new List<ProductGroup>();

            #region Addresses
            address.Add(new Address() { Id = "1", Street = "Gossauerstrasse 15", PostCode = 9200, City = "Gossau", Country = "Switzerland" });
            address.Add(new Address() { Id = "2", Street = "Ronis 2", PostCode = 9050, City = "Appenzell", Country = "Switzerland" });
            address.Add(new Address() { Id = "3", Street = "Lehnmattstrasse 21", PostCode = 9050, City = "Appenzell", Country = "Switzerland" });
            address.Add(new Address() { Id = "4", Street = "Rebhofweg 10", PostCode = 9500, City = "Wil", Country = "Switzerland" });
            address.Add(new Address() { Id = "5", Street = "Polieregasse 2", PostCode = 3400, City = "Burgdorf", Country = "Switzerland" });
            address.Add(new Address() { Id = "6", Street = "Zelgstrasse 2", PostCode = 3715, City = "Adelboden", Country = "Switzerland" });
            address.Add(new Address() { Id = "7", Street = "Via Lucomagno 115", PostCode = 6710, City = "Biasca", Country = "Switzerland" });
            address.Add(new Address() { Id = "8", Street = "Chasatschas 111", PostCode = 7536, City = "Muenstertal", Country = "Switzerland" });
            address.Add(new Address() { Id = "9", Street = "Walenseestrasse 34", PostCode = 8880, City = "Walenstadt", Country = "Switzerland" });
            address.Add(new Address() { Id = "10", Street = "Sonnenstrasse 35", PostCode = 8280, City = "Kreuzlingen", Country = "Switzerland" });
            address.Add(new Address() { Id = "11", Street = "Bahnhofstrasse 16", PostCode = 8555, City = "Muellheim", Country = "Switzerland" });
            address.Add(new Address() { Id = "12", Street = "Kurzenerchingerstrasse 5", PostCode = 8500, City = "Frauenfeld", Country = "Switzerland" });
            address.Add(new Address() { Id = "13", Street = "Wartstrasse 16", PostCode = 8400, City = "Winterthur", Country = "Switzerland" });
            address.Add(new Address() { Id = "14", Street = "Kanzleistrasse 4", PostCode = 8309, City = "Nuerensdorf", Country = "Switzerland" });
            address.Add(new Address() { Id = "15", Street = "Flughafenstrasse 25", PostCode = 8302, City = "Kloten", Country = "Switzerland" });
            address.Add(new Address() { Id = "16", Street = "Oetwilerstrasse 13", PostCode = 8953, City = "Dietikon", Country = "Switzerland" });
            address.Add(new Address() { Id = "17", Street = "Muehlegasse 32", PostCode = 4563, City = "Gerlafingen", Country = "Switzerland" });
            address.Add(new Address() { Id = "18", Street = "Altstadt 27", PostCode = 3235, City = "Erlach", Country = "Switzerland" });
            address.Add(new Address() { Id = "19", Street = "Grasweg 2", PostCode = 97074, City = "Wuerzburg", Country = "Germany" });
            address.Add(new Address() { Id = "20", Street = "August-Bebel-Strasse 108", PostCode = 33602, City = "Bielefeld", Country = "Germany" });
            address.Add(new Address() { Id = "21", Street = "Strada Vasile Lascar 15", PostCode = 030167, City = "Bucharest", Country = "Romania" });
            #endregion
            foreach(Address add in address)
            {
                modelbuilder.Entity<Address>().HasData(add);
            }

            #region Customers
            customer.Add(new Customer() { Id = "1", AddressId = "1", Firstname = "Alfred", Name = "Koller", Password = "test1234"});
            customer.Add(new Customer() { Id = "2", AddressId = "2", Firstname = "Karl", Name = "Meier" });
            customer.Add(new Customer() { Id = "3", AddressId = "3", Firstname = "Marco", Name = "Ebneter" });
            customer.Add(new Customer() { Id = "4", AddressId = "4", Firstname = "Mike", Name = "Faessler" });
            customer.Add(new Customer() { Id = "5", AddressId = "5", Firstname = "Remo", Name = "Kessler" });
            customer.Add(new Customer() { Id = "6", AddressId = "6", Firstname = "Tim", Name = "Manser" });
            customer.Add(new Customer() { Id = "7", AddressId = "7", Firstname = "Martin", Name = "Streule" });
            customer.Add(new Customer() { Id = "8", AddressId = "8", Firstname = "Michael", Name = "Messmer" });
            customer.Add(new Customer() { Id = "9", AddressId = "9", Firstname = "Berta", Name = "Keiser" });
            customer.Add(new Customer() { Id = "10", AddressId = "10", Firstname = "Tobias", Name = "Wirth" });
            customer.Add(new Customer() { Id = "11", AddressId = "11", Firstname = "Roland", Name = "Zumstein" });
            customer.Add(new Customer() { Id = "12", AddressId = "12", Firstname = "Konrad", Name = "Mazenauer" });
            customer.Add(new Customer() { Id = "13", AddressId = "13", Firstname = "Patrick", Name = "Stadler" });
            customer.Add(new Customer() { Id = "14", AddressId = "14", Firstname = "Natascha", Name = "Luechinger" });
            customer.Add(new Customer() { Id = "15", AddressId = "15", Firstname = "Stefanie", Name = "Staub" });
            customer.Add(new Customer() { Id = "16", AddressId = "16", Firstname = "Emanuel", Name = "Steingruber" });
            customer.Add(new Customer() { Id = "17", AddressId = "17", Firstname = "Nicole", Name = "Fritsche" });
            customer.Add(new Customer() { Id = "18", AddressId = "18", Firstname = "Karin", Name = "Geher" });
            customer.Add(new Customer() { Id = "19", AddressId = "19", Firstname = "Ruedi", Name = "Wuerth" });
            customer.Add(new Customer() { Id = "20", AddressId = "20", Firstname = "Tamara", Name = "Ebneter" });
            customer.Add(new Customer() { Id = "21", AddressId = "21", Firstname = "Antonia", Name = "Faessler" });
            customer.Add(new Customer() { Id = "22", AddressId = "8", Firstname = "Alejandro", Name = "Faessler" });
            customer.Add(new Customer() { Id = "23", AddressId = "10", Firstname = "Pascal", Name = "Koller" });
            #endregion
            foreach (Customer cus in customer)
            {
                modelbuilder.Entity<Customer>().HasData(cus);
            }

            #region Products
            order.Add(new Order { Id = "1", Date = new DateTime(2020, 12, 10, 09, 10, 55), CustomerId = "1" });
            order.Add(new Order { Id = "2", Date = new DateTime(2020, 11, 05, 09, 10, 55), CustomerId = "2" });
            order.Add(new Order { Id = "3", Date = new DateTime(2020, 09, 12, 09, 10, 55), CustomerId = "3" });
            order.Add(new Order { Id = "4", Date = new DateTime(2020, 02, 10, 09, 10, 55), CustomerId = "4" });
            order.Add(new Order { Id = "5", Date = new DateTime(2020, 05, 10, 09, 10, 55), CustomerId = "5" });
            order.Add(new Order { Id = "6", Date = new DateTime(2020, 06, 10, 09, 10, 55), CustomerId = "6" });
            order.Add(new Order { Id = "7", Date = new DateTime(2020, 03, 15, 09, 10, 55), CustomerId = "7" });
            order.Add(new Order { Id = "8", Date = new DateTime(2020, 02, 20, 09, 10, 55), CustomerId = "8" });
            order.Add(new Order { Id = "9", Date = new DateTime(2020, 08, 25, 09, 10, 55), CustomerId = "9" });
            order.Add(new Order { Id = "10", Date = new DateTime(2020, 11, 30, 09, 10, 55), CustomerId = "10" });
            order.Add(new Order { Id = "11", Date = new DateTime(2019, 05, 13, 09, 10, 55), CustomerId = "11" });
            order.Add(new Order { Id = "12", Date = new DateTime(2019, 05, 14, 09, 10, 55), CustomerId = "12" });
            order.Add(new Order { Id = "13", Date = new DateTime(2019, 10, 05, 09, 10, 55), CustomerId = "13" });
            order.Add(new Order { Id = "14", Date = new DateTime(2019, 12, 30, 09, 10, 55), CustomerId = "14" });
            order.Add(new Order { Id = "15", Date = new DateTime(2019, 02, 23, 09, 10, 55), CustomerId = "15" });
            order.Add(new Order { Id = "16", Date = new DateTime(2019, 01, 12, 09, 10, 55), CustomerId = "16" });
            order.Add(new Order { Id = "17", Date = new DateTime(2019, 06, 28, 09, 10, 55), CustomerId = "17" });
            order.Add(new Order { Id = "18", Date = new DateTime(2019, 08, 17, 09, 10, 55), CustomerId = "18" });
            order.Add(new Order { Id = "19", Date = new DateTime(2018, 12, 18, 09, 10, 55), CustomerId = "19" });
            order.Add(new Order { Id = "20", Date = new DateTime(2018, 11, 09, 09, 10, 55), CustomerId = "20" });
            order.Add(new Order { Id = "21", Date = new DateTime(2018, 08, 03, 09, 10, 55), CustomerId = "21" });
            order.Add(new Order { Id = "22", Date = new DateTime(2018, 02, 16, 09, 10, 55), CustomerId = "22" });
            order.Add(new Order { Id = "23", Date = new DateTime(2018, 01, 11, 09, 10, 55), CustomerId = "1" });
            order.Add(new Order { Id = "24", Date = new DateTime(2018, 05, 13, 09, 10, 55), CustomerId = "2" });
            order.Add(new Order { Id = "25", Date = new DateTime(2018, 06, 12, 09, 10, 55), CustomerId = "3" });
            order.Add(new Order { Id = "26", Date = new DateTime(2018, 04, 27, 09, 10, 55), CustomerId = "4" });
            order.Add(new Order { Id = "27", Date = new DateTime(2017, 12, 26, 09, 10, 55), CustomerId = "5" });
            order.Add(new Order { Id = "28", Date = new DateTime(2021, 12, 29, 09, 10, 55), CustomerId = "6" });
            order.Add(new Order { Id = "29", Date = new DateTime(2017, 12, 26, 09, 10, 55), CustomerId = "7" });
            #endregion
            foreach (Order ord in order)
            {
                modelbuilder.Entity<Order>().HasData(ord);
            }

            #region Products
            product.Add(new Product { Id = "1", Name = "Milch", Price = 1.25M, ParentId = "1" });
            product.Add(new Product { Id = "2", Name = "Butter", Price = 2.3M, ParentId = "1" });
            product.Add(new Product { Id = "3", Name = "Salat", Price = 3.6M, ParentId = "2" });
            product.Add(new Product { Id = "4", Name = "Pfanne", Price = 10.95M, ParentId = "3" });
            product.Add(new Product { Id = "5", Name = "Speck", Price = 2.65M, ParentId = "4" });
            product.Add(new Product { Id = "6", Name = "Kaese", Price = 2.50M, ParentId = "1" });
            product.Add(new Product { Id = "7", Name = "Landjaeger", Price = 1.20M, ParentId = "4" });
            product.Add(new Product { Id = "8", Name = "Löffel", Price = 6.50M, ParentId = "3" });
            product.Add(new Product { Id = "9", Name = "Kartoffel", Price = 7.65M, ParentId = "2" });
            product.Add(new Product { Id = "10", Name = "Gurke", Price = 1.20M, ParentId = "2" });
            product.Add(new Product { Id = "11", Name = "Mascarpone", Price = 1.30M, ParentId = "1" });
            product.Add(new Product { Id = "12", Name = "Schinken", Price = 15.20M, ParentId = "4" });
            product.Add(new Product { Id = "13", Name = "Salami", Price = 8.90M, ParentId = "4" });
            product.Add(new Product { Id = "14", Name = "Zwiebel", Price = 0.20M, ParentId = "2" });
            product.Add(new Product { Id = "15", Name = "Majonaise", Price = 3.35M, ParentId = "1" });
            product.Add(new Product { Id = "16", Name = "Banane", Price = 1.60M, ParentId = "2"});
            #endregion
            foreach (Product pro in product)
            {
                modelbuilder.Entity<Product>().HasData(pro);
            }

            #region OrderPositions
            orderpos.Add(new OrderPosition { Id = "1", Position = 1, Count = 5, ProductId = "1", OrderId = "1" });
            orderpos.Add(new OrderPosition { Id = "2", Position = 2, Count = 3, ProductId = "3", OrderId = "1" });
            orderpos.Add(new OrderPosition { Id = "3", Position = 1, Count = 2, ProductId = "1", OrderId = "2" });
            orderpos.Add(new OrderPosition { Id = "4", Position = 1, Count = 1, ProductId = "1", OrderId = "3" });
            orderpos.Add(new OrderPosition { Id = "5", Position = 2, Count = 8, ProductId = "1", OrderId = "3" });
            orderpos.Add(new OrderPosition { Id = "6", Position = 3, Count = 12, ProductId = "1", OrderId = "3" });
            orderpos.Add(new OrderPosition { Id = "7", Position = 4, Count = 15, ProductId = "1", OrderId = "3" });
            orderpos.Add(new OrderPosition { Id = "8", Position = 1, Count = 9, ProductId = "1", OrderId = "4" });
            orderpos.Add(new OrderPosition { Id = "9", Position = 2, Count = 8, ProductId = "1", OrderId = "4" });
            orderpos.Add(new OrderPosition { Id = "10", Position = 1, Count = 4, ProductId = "1", OrderId = "5" });
            orderpos.Add(new OrderPosition { Id = "11", Position = 1, Count = 3, ProductId = "1", OrderId = "6" });
            orderpos.Add(new OrderPosition { Id = "12", Position = 1, Count = 5, ProductId = "1", OrderId = "7" });
            orderpos.Add(new OrderPosition { Id = "13", Position = 2, Count = 7, ProductId = "1", OrderId = "7" });
            orderpos.Add(new OrderPosition { Id = "14", Position = 1, Count = 26, ProductId = "1", OrderId = "8" });
            orderpos.Add(new OrderPosition { Id = "15", Position = 1, Count = 361, ProductId = "1", OrderId = "9" });
            orderpos.Add(new OrderPosition { Id = "16", Position = 1, Count = 20, ProductId = "1", OrderId = "10" });
            orderpos.Add(new OrderPosition { Id = "17", Position = 1, Count = 515, ProductId = "1", OrderId = "11" });
            orderpos.Add(new OrderPosition { Id = "18", Position = 1, Count = 2, ProductId = "1", OrderId = "12" });
            orderpos.Add(new OrderPosition { Id = "19", Position = 1, Count = 1, ProductId = "1", OrderId = "13" });
            orderpos.Add(new OrderPosition { Id = "20", Position = 2, Count = 8, ProductId = "1", OrderId = "13" });
            orderpos.Add(new OrderPosition { Id = "21", Position = 3, Count = 30, ProductId = "1", OrderId = "13" });
            orderpos.Add(new OrderPosition { Id = "22", Position = 4, Count = 40, ProductId = "1", OrderId = "13" });
            orderpos.Add(new OrderPosition { Id = "23", Position = 1, Count = 2, ProductId = "1", OrderId = "14" });
            orderpos.Add(new OrderPosition { Id = "24", Position = 1, Count = 7, ProductId = "1", OrderId = "15" });
            orderpos.Add(new OrderPosition { Id = "25", Position = 1, Count = 8, ProductId = "1", OrderId = "16" });
            orderpos.Add(new OrderPosition { Id = "26", Position = 1, Count = 5, ProductId = "1", OrderId = "17" });
            orderpos.Add(new OrderPosition { Id = "27", Position = 1, Count = 9, ProductId = "1", OrderId = "18" });
            orderpos.Add(new OrderPosition { Id = "28", Position = 2, Count = 3, ProductId = "1", OrderId = "18" });
            orderpos.Add(new OrderPosition { Id = "29", Position = 1, Count = 10, ProductId = "1", OrderId = "19" });
            orderpos.Add(new OrderPosition { Id = "30", Position = 1, Count = 20, ProductId = "1", OrderId = "20" });
            orderpos.Add(new OrderPosition { Id = "31", Position = 1, Count = 15, ProductId = "1", OrderId = "21" });
            orderpos.Add(new OrderPosition { Id = "32", Position = 1, Count = 88, ProductId = "1", OrderId = "22" });
            orderpos.Add(new OrderPosition { Id = "33", Position = 1, Count = 20, ProductId = "1", OrderId = "23" });
            orderpos.Add(new OrderPosition { Id = "34", Position = 1, Count = 30, ProductId = "1", OrderId = "24" });
            orderpos.Add(new OrderPosition { Id = "35", Position = 1, Count = 80, ProductId = "1", OrderId = "25" });
            orderpos.Add(new OrderPosition { Id = "36", Position = 2, Count = 90, ProductId = "1", OrderId = "25" });
            orderpos.Add(new OrderPosition { Id = "37", Position = 3, Count = 100, ProductId = "1", OrderId = "25" });
            orderpos.Add(new OrderPosition { Id = "38", Position = 4, Count = 42, ProductId = "1", OrderId = "25" });
            orderpos.Add(new OrderPosition { Id = "39", Position = 5, Count = 15, ProductId = "1", OrderId = "25" });
            orderpos.Add(new OrderPosition { Id = "40", Position = 1, Count = 35, ProductId = "1", OrderId = "26" });
            orderpos.Add(new OrderPosition { Id = "41", Position = 1, Count = 45, ProductId = "1", OrderId = "27" });
            orderpos.Add(new OrderPosition { Id = "42", Position = 1, Count = 2, ProductId = "1", OrderId = "28" });
            orderpos.Add(new OrderPosition { Id = "43", Position = 1, Count = 1, ProductId = "1", OrderId = "29" });
            #endregion
            foreach (OrderPosition orp in orderpos)
            {
                modelbuilder.Entity<OrderPosition>().HasData(orp);
            }

            #region ProductGroups
            productgrp.Add(new ProductGroup { Id = "1", Name = "Products", ParentId = null });
            productgrp.Add(new ProductGroup { Id = "2", Name = "Milch Produkte", ParentId = "1" });
            productgrp.Add(new ProductGroup { Id = "3", Name = "Fruechte / Gemuese", ParentId = "1" });
            productgrp.Add(new ProductGroup { Id = "4", Name = "Kuechenartikel", ParentId = "1" });
            productgrp.Add(new ProductGroup { Id = "5", Name = "Käse", ParentId = "2" });
            productgrp.Add(new ProductGroup { Id = "6", Name = "Appenzeller", ParentId = "5" });
            productgrp.Add(new ProductGroup { Id = "7", Name = "Schoggi-Milch", ParentId = "2" });
            productgrp.Add(new ProductGroup { Id = "8", Name = "Messer", ParentId = "4" });
            productgrp.Add(new ProductGroup { Id = "9", Name = "Erdbeeren", ParentId = "5" });
            #endregion
            foreach (ProductGroup prg in productgrp)
            {
                modelbuilder.Entity<ProductGroup>().HasData(prg);
            }
        }
    }
}
