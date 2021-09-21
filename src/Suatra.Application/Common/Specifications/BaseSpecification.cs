using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Suatra.Application.Common.Specifications
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {

        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Includes { get; private set; } = new List<Func<IQueryable<T>, IIncludableQueryable<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        
        public Expression<Func<T, object>> GroupBy { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool HasPagingEnabled { get; private set; }

        protected virtual void AddInclude(Func<IQueryable<T>, IIncludableQueryable<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected virtual void AddOrderByDescending(Expression<Func<T, object>> orderByDescending)
        {
            OrderByDescending = orderByDescending;
        }

        protected virtual void EnablePaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            HasPagingEnabled = true;
        }
        
        protected virtual void ApplyGroupBy(Expression<Func<T, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
        }
    }
}
