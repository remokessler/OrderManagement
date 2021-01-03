using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrderManagement.Backend.DataModels
{
    public class Product : IProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey(nameof(Parent))]
        public int ParentId { get; set; }
        public IEnumerable<OrderPosition> OrderPositions { get; set; }
        public ProductGroup Parent { get; set; }
    }
}
