using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatify.Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Chatify.Repository.Specifications
{
    public static class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery , ISpecification<T> spec)
        {
            var query = inputQuery;

            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria);

            if(spec.OrderBy is not null)
                query = query.OrderBy(spec.OrderBy);

            if(spec.OrderByDescending is not null)
                query = query.OrderByDescending(spec.OrderByDescending);

            if (spec.IsPaginationEnabled)
                query = query.Skip(spec.Skip).Take(spec.Take);

            if (spec.Includes.Any())
                query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            
            return query;
        }

        public static IQueryable<TResult> GetQuery<TResult>(IQueryable<T> inputQuery , ISpecificationWithProjection<T,TResult> spec)
        {
            var query = GetQuery(inputQuery,(ISpecification<T>) spec);

            IQueryable<TResult> newQuery = (IQueryable<TResult>)query.Select(spec.Select);

            if (spec.IsDistinctEnabled)
                newQuery = newQuery.Distinct();
            return newQuery;
        }

    }
}
