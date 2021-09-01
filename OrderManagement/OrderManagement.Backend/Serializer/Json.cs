using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Backend.Repositories;
using Newtonsoft.Json;

namespace OrderManagement.Backend.Serializer
{
    public class Json : BaseRepository
    {
        public Json(OrderManagementDbContext dbContext) : base(dbContext)
        {
            var serializer = JsonSerializer.Create();
            serializer.Serialize(dbContext.Customers);
        }
    }
}
