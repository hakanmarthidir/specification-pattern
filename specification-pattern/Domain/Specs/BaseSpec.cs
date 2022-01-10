﻿using System.Linq.Expressions;

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


        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        protected void AddSortByExpression(Expression<Func<T, object>> sortExpression)
        {
            SortBy = sortExpression;
        }
        protected void AddSortByDescendingExpression(Expression<Func<T, object>> sortByDescExpression)
        {
            SortByDescending = sortByDescExpression;
        }
    }
}