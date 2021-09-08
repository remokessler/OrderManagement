using AutoMapper.QueryableExtensions;
using OrderManagement.Backend.DataModels;
using OrderManagement.Backend.Repositories;
using OrderManagement.Backend.Serializer;
using OrderManagement.Backend.Serializer.DTOs;

namespace OrderManagement.Backend
{
    public class RepositoryCollection
    {
        private static RepositoryCollection _instance { get;set; }
        public static RepositoryCollection Instance => _instance ??= new RepositoryCollection();

        public IRepository<Customer> CustomerRepository { get; private set; }
        public IRepository<Address> AddressRepository { get; private set; }
        public IRepository<Order> OrderRepository { get; private set; }
        public IRepository<OrderPosition> OrderPositionRepository { get; private set; }
        public IRepository<Product> ProductRepository { get; private set; }
        public IRepository<ProductGroup> ProductGroupRepository { get; private set; }
        public IRepository<ProductGroup> ProductTreeRepository { get; private set; }
        public IRepository<BillStatistic> BillStatisticRepository { get; private set; }
        public IRepository<YearStatistic> YearStatisticRepository { get; private set; }

        private OrderManagementDbContext _dbContext { get; set; }

        public RepositoryCollection(OrderManagementDbContext dbContext = null)
        {
            // AKA: Bascily StartUp

            _dbContext = new OrderManagementDbContextFactory().CreateDbContext(null);
            if (dbContext != null)
                _dbContext = dbContext;

            CustomerRepository = new CustomerRepository(_dbContext);
            AddressRepository = new AddressRepository(_dbContext);
            OrderRepository = new OrderRepository(_dbContext);
            OrderPositionRepository = new OrderPositionRepository(_dbContext);
            ProductRepository = new ProductRepository(_dbContext);
            ProductGroupRepository = new ProductGroupRepository(_dbContext);
            ProductTreeRepository = new ProductTreeRepository(_dbContext);
            BillStatisticRepository = new BillStatisticsRepository(_dbContext);
            YearStatisticRepository = new YearStatisticRepository(_dbContext);
            var serial = new Json<Customer>(CustomerRepository);
            var serial2 = new Xml<Customer>(CustomerRepository);
        }
    }
}
