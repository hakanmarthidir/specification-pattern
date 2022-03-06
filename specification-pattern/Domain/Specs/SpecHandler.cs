using Microsoft.EntityFrameworkCore;

namespace specification_pattern.Domain.Specs
{
    public class SpecHandler<T> where T : class, new()
    {
        public static IQueryable<T> GetQuery(IQueryable<T> query, ISpec<T> spec)
        {
            if (spec == null) return query;           

            var handlerQuery = query;
            if (spec.Filter != null)
            {
                handlerQuery = handlerQuery.Where(spec.Filter);
            }

            handlerQuery = spec.Includes.Aggregate(handlerQuery, (current, include) => current.Include(include));
            handlerQuery = spec.IncludeStrings.Aggregate(handlerQuery, (current, include) => current.Include(include));

            if (spec.SortBy != null)
            {
                handlerQuery = handlerQuery.OrderBy(spec.SortBy);
            }

            if (spec.SortByDescending != null)
            {
                handlerQuery = handlerQuery.OrderByDescending(spec.SortByDescending);
            }

            if (spec.GroupBy != null)
            {
                handlerQuery = handlerQuery.GroupBy(spec.GroupBy).SelectMany(x => x);
            }

            if (spec.IsPagingEnabled)
            {
                handlerQuery = handlerQuery.Skip(spec.Page * spec.PageSize).Take(spec.PageSize);
            }

            return handlerQuery;
        }
    }
}
