using System.Linq.Expressions;

namespace specification_pattern.Domain.Specs
{
    public interface ISpec<T>
    {
        Expression<Func<T, bool>> Filter { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> SortBy { get; }
        Expression<Func<T, object>> SortByDescending { get; }
    }

}
