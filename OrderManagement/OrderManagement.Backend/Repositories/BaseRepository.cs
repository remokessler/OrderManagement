namespace OrderManagement.Backend.Repositories
{
    public class BaseRepository
    {
        protected OrderManagementDbContext DbContext { get; set; }
        public BaseRepository(OrderManagementDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}