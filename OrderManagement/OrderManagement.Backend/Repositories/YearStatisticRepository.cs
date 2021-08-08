using OrderManagement.Backend.DataModels;
using OrderManagement.Backend.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Backend.Repositories
{
    public class YearStatisticRepository : BaseRepository, IRepository<YearStatistic>
    {
        public YearStatisticRepository(OrderManagementDbContext dbContext) : base(dbContext) { }

        public YearStatistic Add(YearStatistic obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<YearStatistic> Get()
        {
            var query = @"
            ;with step1 as (
	            select
		            year(date) as 'Year',
		            month(date)/4 + 1 as 'Quarter',
		            Sum(Products.Price * OrderPositions.Count) as 'TotalSales',
		            Sum(Orders.Id) as 'SumOrders',
		            Avg(OrderPositions.Count) over (partition by OrderPositions.Id) as 'AvgCountProductsPerOrder',
		            Avg(Products.Price * OrderPositions.Count) over (partition by Orders.CustomerId) as 'AvgSalesPerCustomer'
	            from Orders
		            inner join OrderPositions on Orders.Id = OrderPositions.OrderId
		            inner join Products on OrderPositions.ProductId = Products.Id
	            where year(getdate()) - 3 < year(date)
	            group by year(date), month(date)/4 + 1, OrderPositions.Id, OrderPositions.Count, Orders.CustomerId, Products.Price
	            ),
            step2 as (
	            select 
		            Year,
		            Quarter,
		            Sum(TotalSales) as TotalSales,
		            Avg(AvgCountProductsPerOrder) as 'AvgCountProductsPerOrder',
		            Avg(AvgSalesPerCustomer) as 'AvgSalesPerCustomer',
		            (select count(id) from Orders where year(Orders.Date) = Year and (month(Orders.Date)/4 + 1) = Quarter) as 'CountOrders',
		            (select count(id) from Products where year(Products.valid_from) = Year and (month(Products.valid_from)/4 + 1) = Quarter) as 'CountProducts'
	            from step1
	            group by year, quarter
	            )
            select * from step2
            order by Year asc, quarter asc;";

            var yearStatistics = RawSqlHelper.ExecuteQuery(query,
                y => new YearStatistic()
                {
                    Year = y[0].ToString(),
                    Quarter = y[1].ToString(),
                    TotalSales = Convert.ToDecimal(y[2]),
                    AvgCountProductsPerOrder = Convert.ToDecimal(y[3]),
                    AvgSalesPerCustomer = Convert.ToDecimal(y[4]),
                    CountOrders = Convert.ToInt32(y[5]),
                    CountProducts = Convert.ToInt32(y[6]),
                },
                DbContext);
            return yearStatistics;
        }


        public IEnumerable<YearStatistic> Get(Func<YearStatistic, bool> where)
        {
            throw new NotImplementedException();
        }

        public YearStatistic Get(string id)
        {
            throw new NotImplementedException();
        }

        public YearStatistic Update(YearStatistic newObject)
        {
            throw new NotImplementedException();
        }
    }
}
