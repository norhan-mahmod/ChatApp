using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatify.Core.Specifications;

namespace Chatify.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        void Update(T entity);
        void Delete(int id);

        // Specification
        Task<IReadOnlyList<T>> GetListWithSpecificationAsync(ISpecification<T> spec);
        Task<T> GetEntityWithSpecificationAsync(ISpecification<T> spec);

        // Specification With Projection
        Task<IReadOnlyList<TResult>> GetListWithProjectionSpecificationAsync<TResult>(ISpecificationWithProjection<T, TResult> spec);
    }
}
