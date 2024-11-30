using Movies.BAL.Interfaces.Repository;
using Movies.BAL.Interfaces.UnitOfWork;
using Movies.DAL.Data;
using Movies.DAL.Data.Entites;


namespace Movies.BAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IGenericRepository<Genre> GenresRepository
        {
            get; set;
        }
        public IGenericRepository<Movie> MoviesRepository { get ; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
            GenresRepository = new GenericRepository<Genre>(context);
            MoviesRepository = new GenericRepository<Movie>(context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
