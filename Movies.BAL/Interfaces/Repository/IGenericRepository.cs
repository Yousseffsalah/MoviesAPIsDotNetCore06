using Movies.DAL.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BAL.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public void Add(T entity);

        public void Remove(T entity);

        public Task<IReadOnlyList<T>> GetAllAsync();

        public Task<IReadOnlyList<T>> GetAllWithSpecsAsync(ISpecifications<T> spec);

        public Task<T> GetAsync(int id);

        public Task<T> GetWithSpecAsync(ISpecifications<T> spec);

        public void Update(T model);

        public Task<int> GetCountAsync(ISpecifications<T> spec);

    }
}
