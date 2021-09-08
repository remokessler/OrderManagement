using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.VisualBasic;
using OrderManagement.Backend.DataModels;
using OrderManagement.Backend.Repositories;
using OrderManagement.Backend.Helpers;
using OrderManagement.Backend.Serializer.DTOs;

namespace OrderManagement.Backend.Serializer
{
    public class Json<T>
    {
        private readonly IRepository<T> _repository;
        private readonly Mapper _mapper;


        public Json(IRepository<T> repository, bool write)
        {
            _repository = repository;

            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CustomerMapper());
            }));

            if (write == true)
            {
                writeJson();
            }
            else
            {
                readJson();
            }
        }

        private void readJson()
        {

        }

        private void writeJson()
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };

            if (typeof(T) == typeof(Customer))
            {
                var entities = _repository.Get().Select(entity => _mapper.Map<CustomerDTO>(entity)).ToList();
                var json = JsonSerializer.Serialize(entities, options);
                File.WriteAllText(Directory.GetCurrentDirectory() + "../../../../../Customer.json", json);
            }
        }
    }
}
