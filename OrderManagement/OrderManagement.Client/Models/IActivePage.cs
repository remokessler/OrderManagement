using OrderManagement.Backend.Repositories;
using System;

namespace OrderManagement.Client.Models
{
    internal interface IActivePage
    {
        public Type Type { get; }
    }
}
