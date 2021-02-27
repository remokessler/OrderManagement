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
            // Dat� usehole
            var address = _repositoryCollection.AddressRepository.Add(
                new Backend.DataModels.Address()
                {
                    City = "Appizell",
                    Country = "Ebefalls Appizell",
                    PostCode = 1231,
                    Street = "Str�ssli zur Bergh�tte hindire"
                }
            );
            var customer = _repositoryCollection.CustomerRepository.Add(
                new Backend.DataModels.Customer()
                {
                    Firstname = "Hans",
                    Name = "M�ller",
                    AddressId = address.Id
                }
            );
            // �nder�
            customer.Name = "Jetzig n�m Hans";
            // �nderige speichere
            var customer2 = _repositoryCollection.CustomerRepository.Update(customer);
            Assert.AreEqual(customer2.Name, customer.Name);

            // l�sch�
            _repositoryCollection.CustomerRepository.Delete(customer.Id);
            
        }
    }
}