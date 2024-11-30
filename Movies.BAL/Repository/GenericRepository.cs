using Microsoft.EntityFrameworkCore;
using Movies.BAL.Interfaces;
using Movies.BAL.Interfaces.Repository;
using Movies.BAL.Specifications.Evaluator;
using Movies.DAL.Data;
using Movies.DAL.Data.Entites;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
          return await  _context.Set<T>().ToListAsync();
        }


        public async Task<T> GetAsync(int id)
        {
            return  await _context.Set<T>().FindAsync(id);
        }

       

        public void  Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }


        public async Task<IReadOnlyList<T>> GetAllWithSpecsAsync(ISpecifications<T> spec)
        {
            return await ApplaySpecifiactions(spec).ToListAsync();

            
        }
        public async Task<T> GetWithSpecAsync(ISpecifications<T> spec)
        {
            return await ApplaySpecifiactions(spec).FirstOrDefaultAsync();
        }

        public async Task<int> GetCountAsync(ISpecifications<T> spec)
        {
            return await ApplaySpecifiactions(spec).CountAsync();

        }
        private   IQueryable<T> ApplaySpecifiactions(ISpecifications<T> spec)
        {
            return SpecificationsEvaluator<T>.GetQuery(_context.Set<T>(), spec);
        }

    }
}
