using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using OrderManagement.Backend.DataModels;

namespace OrderManagement.Backend.Serializer.Converter
{
    public class CustomerConverter : JsonConverter<Customer>
    {
        public override Customer Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Customer value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteEndObject();
        }
    }
}
