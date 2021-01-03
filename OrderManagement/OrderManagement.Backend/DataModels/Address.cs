﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrderManagement.Backend.DataModels
{
    public class Address
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
    }
}