using System.ComponentModel.DataAnnotations;

namespace Movies.PL.APIs.Dtos
{
    public  class MovieDetailsDto :MovieBaseDto
    {
        public string GenreName { get; set; }

        public string PosterUrl { get; set; }

    }
}
