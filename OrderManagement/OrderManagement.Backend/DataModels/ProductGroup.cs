using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OrderManagement.Backend.DataModels
{
    public class ProductGroup : IHasId
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey(nameof(Parent))]
        public string? ParentId { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductGroup> Children { get; set; }
        public ProductGroup Parent { get; set; }

        public override string ToString() => $"{Id}; {Name};";
    }
}
