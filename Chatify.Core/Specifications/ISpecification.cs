using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chatify.Core.Specifications
{
    public interface ISpecification<T> where T : class
    {
        // Filtering Criteria
        Expression<Func<T, bool>>? Criteria { get; }

        // Relative Entities To Include
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }

        // OrderBy , OrderByDescending
        Expression<Func<T , object>>? OrderBy { get; }
        Expression<Func<T, object>>? OrderByDescending { get; }

        // Pagination
        int Skip { get; }
        int Take { get; }
        bool IsPaginationEnabled { get; }
    }
}
