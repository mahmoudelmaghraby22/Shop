using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Core.Enities;
using Core.interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using SpecificationEvaluator;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _Context;
        public GenericRepository(StoreContext Context)
        {
            _Context = Context;
        }
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _Context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _Context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecifications(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecifications(spec).CountAsync();
        }

        private IQueryable<T> ApplySpecifications(ISpecification<T> spec)
        {
            var query = SpecificationEvaluator<T>
                .GetQuery(_Context.Set<T>().AsQueryable(), spec);
                var sqlQuery = query.ToString();
            return query;
        }
    }
}