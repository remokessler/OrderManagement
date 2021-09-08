using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using AutoMapper;
using OrderManagement.Backend.DataModels;
using OrderManagement.Backend.Helpers;
using OrderManagement.Backend.Repositories;
using OrderManagement.Backend.Serializer.DTOs;

namespace OrderManagement.Backend.Serializer
{
    public class Xml<T>
    {
        private readonly string xml;

        public Xml(IRepository<T> repository)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CustomerMapper());
            }));

            if (typeof(T) == typeof(Customer))
            {
                var entities = repository.Get().Select(entity => mapper.Map<CustomerDTO>(entity)).ToList();
                var writer = new StringWriter();
                var serializer = new XmlSerializer(typeof(List<CustomerDTO>));
                serializer.Serialize(writer, entities);
                xml = writer.ToString();
                File.WriteAllText("Customer.xml", xml);
            }

        }
    }
}
