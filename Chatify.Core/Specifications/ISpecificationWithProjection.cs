using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chatify.Core.Specifications
{
    public interface ISpecificationWithProjection<T,TResult> : ISpecification<T> where T : class
    {
        // Select
        Expression<Func<T, TResult>>? Select { get; }
        // Distincit
        bool IsDistinctEnabled { get; }
    }
}
