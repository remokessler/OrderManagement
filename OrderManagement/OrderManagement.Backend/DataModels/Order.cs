using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Backend.DataModels
{
    public class Order : IHasId
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [ForeignKey(nameof(Customer))]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<OrderPosition> Positions { get; set; }

        public override string ToString() => $"{Id}; {Customer?.Firstname} {Customer?.Name}; {Date}";
    }
}
