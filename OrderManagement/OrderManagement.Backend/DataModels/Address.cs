using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrderManagement.Backend.DataModels
{
    public class Address : IHasId
    {
        [Key]
        [JsonIgnore]
        public string Id { get; set; }
        [Required]
        [JsonPropertyName("street")]
        public string Street { get; set; }
        [Required]
        [JsonIgnore]
        public string City { get; set; }
        [Required]
        [JsonPropertyName("postalCode")]
        public int PostCode { get; set; }
        [Required]
        [JsonIgnore]
        public string Country { get; set; }

        public override string ToString() =>  $"{Street}, {PostCode} {City}";
    }
}
