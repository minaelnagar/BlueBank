using Ardalis.Specification;

namespace BlueBank.SharedKernel.Data.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}
