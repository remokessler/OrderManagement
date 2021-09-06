using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using OrderManagement.Backend.DataModels;

namespace OrderManagement.Backend.Serializer.DTOs
{
    public class CustomerDTO
    {
        public string customerNr { get; set; }
        public string name { get; set; }
        public Address address { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public string password { get; set; }
    }
}
