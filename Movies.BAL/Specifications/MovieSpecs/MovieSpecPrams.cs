using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BAL.Specifications.MovieSpecs
{
    public class MovieSpecPrams
    {
        private int pageSize =5;
        private int defualtPageSize;
        private string? serach;

        public int? GenreId { get; set; }

        public string? Sort { get; set; }

        public int PageIndex { get; set; } = 1;
        public int PageSize { get => pageSize; set => pageSize = value > 10 ? defualtPageSize : value; } 

        public string? Serach { get => serach; set => serach = value?.ToLower(); }

    }
}
