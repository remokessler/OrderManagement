using System.Linq;
using System.Text.Json;
using AutoMapper;
using Newtonsoft.Json;
using OrderManagement.Backend.Repositories;
using OrderManagement.Backend.Helpers;
using OrderManagement.Backend.Serializer.DTOs;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace OrderManagement.Backend.Serializer
{
    public class Json<T>
    {
        private string json { get; set; }

        public Json(IRepository<T> repository)
        {
            var mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CustomerMapper());
            }));

            var serializer = JsonSerializer.Create();
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };

            var entities = repository.Get().Select(entity => mapper.Map<CustomerDTO>(entity)).ToList();

            var json = JsonConvert.SerializeObject(entities);
            //if (list.GetType() == typeof(Customer))
            //{
            //    foreach(var entity in dbContext.Customers)
            //    {
            //        //json += serializer.Serialize(entity, options);
            //        json += JsonConvert.SerializeObject(entity);
            //    }
            //}

        }
    }
}
