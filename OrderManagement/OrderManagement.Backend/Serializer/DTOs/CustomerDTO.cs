using System.Xml.Serialization;
using OrderManagement.Backend.DataModels;

namespace OrderManagement.Backend.Serializer.DTOs
{
    [XmlRoot("Kunden", Namespace = "")]
    public class CustomerDTO
    {
        public string customerNr { get; set; }
        public string name { get; set; }
        public Address address { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public byte[] password { get; set; }
    }
}
