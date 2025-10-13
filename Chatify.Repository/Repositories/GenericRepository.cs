using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatify.Core.Repositories;
using Chatify.Core.Specifications;
using Chatify.Repository.Data;
using Chatify.Repository.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Chatify.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext context;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task Add(T entity)
            => await context.Set<T>().AddAsync(entity);

        public void Delete(int id)
            => context.Remove(id);

        public async Task<List<T>> GetAll()
            => await context.Set<T>().ToListAsync();

        public async Task<T> GetById(int id)
            => await context.Set<T>().FindAsync(id);

        public void Update(T entity)
            => context.Set<T>().Update(entity);

        // Specification
        public async Task<T> GetEntityWithSpecificationAsync(ISpecification<T> spec)
            => await ApplySpecification(spec).FirstOrDefaultAsync();

        public async Task<IReadOnlyList<T>> GetListWithSpecificationAsync(ISpecification<T> spec)
            => await ApplySpecification(spec).ToListAsync();

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
            => SpecificationEvaluator<T>.GetQuery(context.Set<T>(), spec);


        // Specification With Projection
        public async Task<IReadOnlyList<TResult>> GetListWithProjectionSpecificationAsync<TResult>(ISpecificationWithProjection<T, TResult> spec)
            => await ApplyProjectionSpecification(spec).ToListAsync();
        private IQueryable<TResult> ApplyProjectionSpecification<TResult>(ISpecificationWithProjection<T, TResult> spec)
            => SpecificationEvaluator<T>.GetQuery<TResult>(context.Set<T>(), spec);
    }
}
