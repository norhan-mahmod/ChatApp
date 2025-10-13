using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chatify.Core.Repositories;
using Chatify.Repository.Data;

namespace Chatify.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable repositories;
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext context)
        {
            repositories = new Hashtable();
            this.context = context;
        }
        public IGenericRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T).Name;
            if (!repositories.ContainsKey(type))
            {
                var repository = new GenericRepository<T>(context);
                repositories.Add(type, repository);
            }
            return repositories[type] as IGenericRepository<T>;
        }

        public async Task<int> SaveAsync()
            => await context.SaveChangesAsync();
    }
}
