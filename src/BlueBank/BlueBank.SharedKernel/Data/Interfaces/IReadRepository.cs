using Ardalis.Specification;

namespace BlueBank.SharedKernel.Data.Interfaces
{
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}
