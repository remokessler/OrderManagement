using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Backend.DataModels
{
    public class OrderPosition : IHasId
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Position { get; set; }
        public int Count { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public override string ToString() => $"{OrderId}; {Position}; {Count} x {Product.Name}";
    }
}
