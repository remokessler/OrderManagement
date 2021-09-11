using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.Internal;
using OrderManagement.Backend.DataModels;
using OrderManagement.Backend.Helpers;
using OrderManagement.Backend.Repositories;
using OrderManagement.Backend.Serializer.DTOs;

namespace OrderManagement.Backend.Serializer
{
    public class Xml<T>
    {
        private readonly IRepository<T> _repository;
        private readonly Mapper _mapper;

        public Xml(IRepository<T> repository, bool write)
        {
            _repository = repository;

            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CustomerMapper());
            }));

            if (write)
            {
                writeXml();
            }
            else
            {
                readXml();
            }
        }

        private void readXml()
        {
            var xml = File.ReadAllText(Directory.GetCurrentDirectory() + "../../../../../Customer.xml");
            var root = new XmlRootAttribute("Kunden");
            var serializer = new XmlSerializer(typeof(List<CustomerDTO>), root);
            var reader = new StringReader(xml);
            var obj = (List<CustomerDTO>) serializer.Deserialize(reader);
            var lst = obj.Select(entity => _mapper.Map<T>(entity));
            foreach (var entity in lst)
            {
                _repository.Update(entity);
            }
        }

        private void writeXml()
        {
            var entities = _repository.Get().Select(entity => _mapper.Map<CustomerDTO>(entity)).ToList();
            var writer = new StringWriter();
            var root = new XmlRootAttribute("Kunden");
            var serializer = new XmlSerializer(typeof(List<CustomerDTO>), root);
            serializer.Serialize(writer, entities);
            var xml = writer.ToString();
            File.WriteAllText(Directory.GetCurrentDirectory() + "../../../../../Customer.xml", xml);
        }
    }
}
