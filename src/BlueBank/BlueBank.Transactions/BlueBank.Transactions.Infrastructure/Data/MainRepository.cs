using Ardalis.Specification.EntityFrameworkCore;
using BlueBank.SharedKernel.Data.Interfaces;

namespace BlueBank.Transactions.Infrastructure.Data
{
    public class MainRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public MainRepository(TransactionsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
