using BLL.Interface;

using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.BLL.Specifications;

namespace BLL.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericRepo(StoreContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
             => await _context.Set<T>().ToListAsync();

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
            => await ApplySpecifications(spec).ToListAsync();


        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        


        public async Task<int> GetCountAsync(ISpecification<T> spec)
            => await ApplySpecifications(spec).CountAsync();

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
            => await ApplySpecifications(spec).FirstOrDefaultAsync();

        private IQueryable<T> ApplySpecifications(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), spec);
        }


        //public async Task<Comment> GetById(int id)
        //=> await _context.Set<Comment>().FirstOrDefaultAsync(x => x.ProductID == id);


        public async Task Add(T Entity)
        {
            await _context.Set<T>().AddAsync(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T Entity)
        {
            _context.Set<T>().Remove(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T Entity)
        {
            _context.Set<T>().Update(Entity);
            await _context.SaveChangesAsync();
        }
    }
}
