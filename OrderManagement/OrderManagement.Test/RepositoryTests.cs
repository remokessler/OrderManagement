using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using OrderManagement.Backend;
using System;

namespace OrderManagement.Test
{
    public class Tests
    {
        private RepositoryCollection _repositoryCollection;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<OrderManagementDbContext>().UseInMemoryDatabase(databaseName: "Test");
            _repositoryCollection = new RepositoryCollection(new OrderManagementDbContext(options.Options));
        }

        [Test]
        public void Get()
        {
            // Datä usehole
            var address = _repositoryCollection.AddressRepository.Add(
                new Backend.DataModels.Address()
                {
                    City = "Appizell",
                    Country = "Ebefalls Appizell",
                    PostCode = 1231,
                    Street = "Strössli zur Berghütte hindire"
                }
            );
            var customer = _repositoryCollection.CustomerRepository.Add(
                new Backend.DataModels.Customer()
                {
                    Firstname = "Hans",
                    Name = "Müller",
                    AddressId = address.Id
                }
            );
            // änderä
            customer.Name = "Jetzig nüm Hans";
            // änderige speichere
            var customer2 = _repositoryCollection.CustomerRepository.Update(customer);
            Assert.AreEqual(customer2.Name, customer.Name);

            // löschä
            _repositoryCollection.CustomerRepository.Delete(customer.Id);
            
        }
    }
}