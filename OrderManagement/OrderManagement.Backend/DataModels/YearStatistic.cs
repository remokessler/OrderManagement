using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Backend.DataModels
{
    public class YearStatistic
    {
        public string Year { get; set; }
        public string Quarter { get; set; }
        public int CountOrders { get; set; }
        public int CountProducts { get; set; }
        public decimal AvgCountProductsPerOrder { get; set; }
        public decimal AvgSalesPerCustomer { get; set; }
        public decimal TotalSales { get; set; }
    }
}
