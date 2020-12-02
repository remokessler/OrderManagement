using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Backend.DataModels
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Firstname { get; set; }
    }
}
