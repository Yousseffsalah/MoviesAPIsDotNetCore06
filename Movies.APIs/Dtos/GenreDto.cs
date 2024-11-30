

using System.ComponentModel.DataAnnotations;

namespace Movies.PL.APIs.Dtos
{
    public class GenreDto
    {
        [Required]
        public string Name { get; set; }
    }
}
