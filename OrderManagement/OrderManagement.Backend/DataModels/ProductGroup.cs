﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrderManagement.Backend.DataModels
{
    public class ProductGroup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey(nameof(Parent))]
        public int ParentId { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductGroup> Children { get; set; }
        public ProductGroup Parent { get; set; }
    }
}