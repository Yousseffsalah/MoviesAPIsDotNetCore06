using Movies.BAL.Interfaces;
using Movies.DAL.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BAL.Specifications.MovieSpecs
{
    public class MovieWithGenreSpecifiations : BaseSpecifications<Movie>, ISpecifications<Movie>
    {

        public MovieWithGenreSpecifiations(MovieSpecPrams specPrams)
          : base
            (P =>
                           (!specPrams.GenreId.HasValue || P.GenreId == specPrams.GenreId) &&
                            (string.IsNullOrEmpty(specPrams.Serach) || P.Title.ToLower().Contains (specPrams.Serach))

          )

        {

            Includes.Add(M => M.Genre);

            if(!string.IsNullOrEmpty(specPrams.Sort))
            switch (specPrams.Sort)
            {
                case "rateAsc":
                    AddOrderBy(M => M.Rate);
                    break;
                case "rateDes":
                    AddOrderByDesc(M => M.Rate);
                    break;
                default:
                    AddOrderBy(M => M.Rate);
                    break;
            }
            else
                //defualt sort 
                AddOrderBy(M => M.Rate);
            //enable pagination
            AddPagination((specPrams.PageIndex - 1) * specPrams.PageSize, specPrams.PageSize);

        }
    }
}
