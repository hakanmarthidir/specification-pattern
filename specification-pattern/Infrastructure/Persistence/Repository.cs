using Microsoft.EntityFrameworkCore;
using specification_pattern.Domain;
using specification_pattern.Domain.Specs;
using System.Linq.Expressions;

namespace specification_pattern.Infrastructure.Persistence
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public Repository(SpecificationDbContext specificationDbContext)
        {
            this._dbContext = specificationDbContext;
            this._dbSet = this._dbContext.Set<T>();

        }
        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.AsQueryable().Where(filter).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAllBySpecAsync(ISpec<T> spec, CancellationToken cancellationToken = default)
        {
            var query = this.SetSpec(spec);
            return await query.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.AsQueryable().SingleAsync(x=> x.Id == id).ConfigureAwait(false);
        }

        private IQueryable<T> SetSpec(ISpec<T> specification)
        {
            return SpecHandler<T>.GetQuery(_dbSet.AsQueryable(), specification);
        }
    }
}
