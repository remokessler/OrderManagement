using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Backend.DataModels
{
    public class Address : IHasId
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int PostCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public DateTimeOffset From { get; set; }
        public IEnumerable<Customer> Customers { get; set; }

        public override string ToString() =>  $"{Street}, {PostCode} {City}";
    }
}
