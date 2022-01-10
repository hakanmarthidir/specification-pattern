using specification_pattern.Domain.Specs;
using System.Linq.Expressions;

namespace specification_pattern.Infrastructure.Persistence
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAllBySpecAsync(ISpec<T> spec, CancellationToken cancellationToken = default);
    }
}
