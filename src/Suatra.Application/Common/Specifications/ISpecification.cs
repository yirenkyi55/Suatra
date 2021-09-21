﻿using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Suatra.Application.Common.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }

        List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Includes { get; }

        Expression<Func<T, object>> OrderBy { get; }

        Expression<Func<T, object>> OrderByDescending { get; }
        
        Expression<Func<T, object>> GroupBy { get; }

        int Take { get; }

        int Skip { get; }

        bool HasPagingEnabled { get; }
    }
}
