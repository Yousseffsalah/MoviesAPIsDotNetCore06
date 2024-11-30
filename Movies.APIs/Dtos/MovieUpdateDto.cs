namespace Movies.PL.APIs.Dtos
{
    public class MovieUpdateDto:MovieBaseDto
    {
        public IFormFile? Poster { get; set; }
    }
}
