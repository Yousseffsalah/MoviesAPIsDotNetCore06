using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DAL.Data.Entites
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public double Rate { get; set; }

        public string StoryLine { get; set; }

        public string PosterUrl { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }



    }
}
