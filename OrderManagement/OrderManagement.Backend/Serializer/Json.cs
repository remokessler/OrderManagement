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
using OrderManagement.Backend.Serializer.Converter;
using OrderManagement.Backend.Serializer.DTOs;

namespace OrderManagement.Backend.Serializer
{
    public class Json<T>
    {
        private readonly string json;

        public Json(IRepository<T> repository)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CustomerMapper());
            }));

            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                Converters = { new CustomerConverter() }
            };

            if (typeof(T) == typeof(Customer))
            {
                var entities = repository.Get().Select(entity => mapper.Map<CustomerDTO>(entity)).ToList();
                json = JsonSerializer.Serialize(entities, options);
            }

        }
    }
}
