using System.ComponentModel.DataAnnotations;

namespace Movies.PL.APIs.Dtos
{
    public  abstract class MovieBaseDto
    {
        public string Title { get; set; }

        public int Year { get; set; }

        [Range(1, 10)]
        public double Rate { get; set; }

        [MaxLength(2500)]
        public string StoryLine { get; set; }

        public int GenreId { get; set; }

    }
}
