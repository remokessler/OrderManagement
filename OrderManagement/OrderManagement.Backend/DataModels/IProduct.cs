using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Backend.DataModels
{
    public interface IProduct
    {
        public ProductGroup Parent { get; set; }
    }
}
