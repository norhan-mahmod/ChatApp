using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chatify.Core.Specifications
{
    public class BaseSpecificationWithProjection<T,TResult> 
        : BaseSpecification<T> , ISpecification<T>, ISpecificationWithProjection<T,TResult> where T : class
    {
        public BaseSpecificationWithProjection() { }
        public BaseSpecificationWithProjection(Expression<Func<T,bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, TResult>>? Select { get; private set; }
        public bool IsDistinctEnabled { get; private set; }

        protected void ApplyDistinct()
            => IsDistinctEnabled = true;
        protected void AddSelect(Expression<Func<T, TResult>> select)
            => Select = select;
    }
}
