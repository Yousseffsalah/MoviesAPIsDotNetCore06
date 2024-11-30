using Microsoft.EntityFrameworkCore;
using Movies.DAL.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        //DB Sets
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Movie> Movies { get; set; }


    }
}
