﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chatify.Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : class
    {
        public BaseSpecification() { }
        public BaseSpecification(Expression<Func<T, bool>> criteria )
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>>? Criteria { get; protected set; }

        public List<Expression<Func<T, object>>> Includes => new();
        public List<string> IncludeStrings => new();

        public Expression<Func<T, object>>? OrderBy { get; private set; }

        public Expression<Func<T, object>>? OrderByDescending { get; private set; }

        public int Skip { get; private set; }

        public int Take { get; private set; }

        public bool IsPaginationEnabled { get; private set; }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
            => Includes.Add(includeExpression);

        protected void AddInclude(string includeString)
            => IncludeStrings.Add(includeString);

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
            => OrderBy = orderByExpression;

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescending)
            => OrderByDescending = orderByDescending;

        protected void ApplyPagination(int skip , int take)
        {
            IsPaginationEnabled = true;
            Skip = skip;
            Take = take;
        }
    }
}
