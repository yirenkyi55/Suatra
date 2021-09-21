using System;
using Suatra.Application.Common.Specifications;
using Suatra.Domain.Common;
using System.Linq;

namespace Suatra.Infrastructure.Persistence.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var queryable = inputQuery;

            if (specification.Criteria != null)
            {
                queryable = queryable.Where(specification.Criteria);
            }

            if (specification.OrderBy != null)
            {
                queryable = queryable.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDescending != null)
            {
                queryable = queryable.OrderByDescending(specification.OrderByDescending);
            }

            if (specification.HasPagingEnabled)
            {
                queryable = queryable.Skip(specification.Skip).Take(specification.Take);
            }

            queryable = specification.Includes.Aggregate(queryable, (current, include) => include(current));

            if (specification.GroupBy != null)
            {
                queryable = queryable.GroupBy(specification.GroupBy).SelectMany(x => x);
            }
            
            //Includes.Add(q => q.Include(e => e.User).ThenInclude(e => e.UserRoles).ThenInclude(e => e.Role));
            return queryable;
        }
    }
}
