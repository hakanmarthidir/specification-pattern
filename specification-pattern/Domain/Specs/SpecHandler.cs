using Microsoft.EntityFrameworkCore;

namespace specification_pattern.Domain.Specs
{
    public class SpecHandler<T> where T : class, new()
    {
        public static IQueryable<T> GetQuery(IQueryable<T> query, ISpec<T> spec)
        {
            var handlerQuery = query;
            if (spec.Filter != null)
            {
                handlerQuery = handlerQuery.Where(spec.Filter);
            }

            if (spec.SortBy != null)
            {
                handlerQuery = handlerQuery.OrderBy(spec.SortBy);
            }

            if (spec.SortByDescending != null)
            {
                handlerQuery = handlerQuery.OrderByDescending(spec.SortByDescending);
            }

            handlerQuery = spec.Includes.Aggregate(handlerQuery, (current, include) => current.Include(include));

            return handlerQuery;
        }
    }
}
