using System;

namespace OrderManagement.Backend.DataModels
{
    public class BillStatistic : IHasId
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Street { get; set; }
        public int PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime Date { get; set; }
        public string Id { get; set; }
        public decimal AmountNet { get; set; }
        public decimal AmountGross { get; set; }
    }
}