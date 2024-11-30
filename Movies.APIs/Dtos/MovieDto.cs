using Movies.DAL.Data.Entites;
using System.ComponentModel.DataAnnotations;

namespace Movies.PL.APIs.Dtos
{
    public class MovieWithImageDto:MovieBaseDto
    {
        public IFormFile Poster { get; set; }
  
    }
}
