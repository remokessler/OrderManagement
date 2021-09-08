using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace OrderManagement.Backend.DataModels
{
    public class Address : IHasId
    {
        [Key]
        [JsonIgnore]
        [XmlIgnore]
        public string Id { get; set; }
        [Required]
        [JsonPropertyName("street")]
        [XmlElement("street")]
        public string Street { get; set; }
        [Required]
        [JsonIgnore]
        [XmlIgnore]
        public string City { get; set; }
        [Required]
        [JsonPropertyName("postalCode")]
        [XmlElement("postalCode")]
        public int PostCode { get; set; }
        [Required]
        [JsonIgnore]
        [XmlIgnore]
        public string Country { get; set; }

        public override string ToString() =>  $"{Street}, {PostCode} {City}";
    }
}
