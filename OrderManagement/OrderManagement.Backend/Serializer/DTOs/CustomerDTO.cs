using System.Xml.Serialization;
using Newtonsoft.Json;
using OrderManagement.Backend.DataModels;

namespace OrderManagement.Backend.Serializer.DTOs
{
    [XmlType(TypeName = "Kunde")]
    public class CustomerDTO
    {
        [XmlAttribute("CustomerNr")]
        public string customerNr { get; set; }
        public string name { get; set; }
        public Address address { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public byte[] password { get; set; }
    }
}
