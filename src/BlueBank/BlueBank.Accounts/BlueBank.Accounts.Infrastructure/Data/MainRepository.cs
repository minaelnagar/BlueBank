using Ardalis.Specification.EntityFrameworkCore;
using BlueBank.SharedKernel.Interfaces;

namespace BlueBank.Accounts.Infrastructure.Data
{
    public class MainRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public MainRepository(AccountsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
