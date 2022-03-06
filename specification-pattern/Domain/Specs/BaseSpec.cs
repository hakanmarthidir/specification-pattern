using System.Linq.Expressions;

namespace specification_pattern.Domain.Specs
{
    public class BaseSpec<T> : ISpec<T>
    {
        public BaseSpec()
        {
        }
        public BaseSpec(Expression<Func<T, bool>> filter)
        {
            Filter = filter;
        }
        public Expression<Func<T, bool>> Filter { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> SortBy { get; private set; }
        public Expression<Func<T, object>> SortByDescending { get; private set; }
        public Expression<Func<T, object>> GroupBy { get; private set; }
        public List<string> IncludeStrings { get; } = new List<string>();
        public int PageSize { get; private set; } = 20;
        public int Page { get; private set; } = 0;
        public bool IsPagingEnabled { get; private set; } = false;


        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

        protected void AddSortByExpression(Expression<Func<T, object>> sortExpression)
        {
            SortBy = sortExpression;
        }
        protected void AddSortByDescendingExpression(Expression<Func<T, object>> sortByDescExpression)
        {
            SortByDescending = sortByDescExpression;
        }

        protected virtual void AddGroupBy(Expression<Func<T, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
        }

        protected void AddPaging(int page, int pageSize)
        {
            this.Page = page;
            this.PageSize = pageSize;
            this.IsPagingEnabled = true;
        }
    }
}
