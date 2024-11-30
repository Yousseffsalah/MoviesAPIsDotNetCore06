using Movies.BAL.Interfaces.Repository;
using Movies.DAL.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BAL.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Genre> GenresRepository { get; set; }
        public IGenericRepository<Movie> MoviesRepository { get; set; }

        public Task<int> CompleteAsync();
    }
}
