using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Backend.DataModels
{
    public class Customer : IHasId
    {
        [RegularExpression(@"^CU(\d)*5$")]
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        // Regex from: http://emailregex.com/ as approximation to the standard
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01 -\x08\x0b\x0c\x0e -\x1f\x21\x23 -\x5b\x5d -\x7f] |\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])")]
        public string Mail { get; set; }
        // all in example
        [RegularExpression(@"^(http(s|):\/\/)?(w{3})?(\w*\.)+\w{2,}[\w\/\?\=\&\%]*$")]
        public string Webpage { get; set; }
        // min. 8 characters, small&large letter, number
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")]
        public string Password { get; set; }
        [Required]
        public string Firstname { get; set; }
        [ForeignKey(nameof(Address))]
        public string AddressId { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Order> Orders { get; set; }

        public override string ToString() => $"{Firstname} {Name}";
    }
}
