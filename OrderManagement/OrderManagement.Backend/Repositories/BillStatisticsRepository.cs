using OrderManagement.Backend.DataModels;
using OrderManagement.Backend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Backend.Repositories
{
    public class BillStatisticsRepository : BaseRepository, IRepository<BillStatistic>
    {
        public BillStatisticsRepository(OrderManagementDbContext dbContext) : base(dbContext) { }

        public BillStatistic Add(BillStatistic obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BillStatistic> Get()
        {
            var getAllCustomers = @"
    select OrdersWithCustomer.CustomerId as 'OrderId', OrdersWithCustomer.Date, Name, Street, PostCode, City, Country, dbo.GetAmountNet(OrdersWithCustomer.Id) as 'AmountNet', OrdersWithCustomer.Id from
	    (select Orders.*, Name, Street, PostCode, City, Country from 
		    Orders
		    inner join
		    (select Customers.Id, (Name + ' ' + Firstname) as Name, Street, PostCode, City, Country from Customers full
			    outer join Addresses on Customers.AddressId = Addresses.Id
		    ) as FullCustomer
		    on
		    FullCustomer.Id = Orders.CustomerId
	    ) as OrdersWithCustomer;";

            var customers = RawSqlHelper.ExecuteQuery(
                getAllCustomers,
                bs => new BillStatistic()
                {
                    CustomerId = (int)bs[0],
                    Date = (DateTime)bs[1],
                    CustomerName = (string)bs[2],
                    Street = (string)bs[3],
                    PostCode = (int)bs[4],
                    City = (string)bs[5],
                    Country = (string)bs[6],
                    AmountNet = Convert.ToDecimal(bs[7]),
                    AmountGross = (Convert.ToDecimal(bs[7])) * 1.08M, // + mwst
                    Id = (string)bs[8]
                },
                DbContext);
            return customers;
        }

        public IEnumerable<BillStatistic> Get(Func<BillStatistic, bool> where)
        {
            // Could be optimized. But it work.
            return Get().Where(where);
        }

        public BillStatistic Get(string id)
        {
            throw new NotImplementedException();
        }

        public BillStatistic Update(BillStatistic newObject)
        {
            throw new NotImplementedException();
        }
    }
}
