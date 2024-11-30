using Movies.BAL.Interfaces;
using Movies.DAL.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BAL.Specifications.MovieSpecs
{
    public class MoviesSpecsForCount:BaseSpecifications<Movie>,ISpecifications<Movie>
    {
        public MoviesSpecsForCount(MovieSpecPrams specPrams)
                 : base
                   (P =>
                                  (!specPrams.GenreId.HasValue || P.GenreId == specPrams.GenreId) &&
                                   (string.IsNullOrEmpty(specPrams.Serach) || P.Title.ToLower().Contains(specPrams.Serach))

                 )

        {


          

        }
    }
}
