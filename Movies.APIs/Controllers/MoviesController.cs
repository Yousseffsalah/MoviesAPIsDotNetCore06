using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.BAL.Interfaces.UnitOfWork;
using Movies.BAL.Specifications.MovieSpecs;
using Movies.DAL.Data.Entites;
using Movies.PL.APIs.Dtos;
using Movies.PL.APIs.Errors;
using Movies.PL.APIs.Helpers;

namespace Movies.PL.APIs.Controllers
{

    public class MoviesController : ApiBaseController
    {


        public MoviesController(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )  :base(unitOfWork,mapper)
        {

        }

        [HttpGet]
        public async Task<ActionResult<MovieDetailsDto>> GetAllAsync([FromQuery] MovieSpecPrams specPrams )
        {
            var MovieSpec = new MovieWithGenreSpecifiations(specPrams);
            var listOfMovies = await _unitOfWork.MoviesRepository.GetAllWithSpecsAsync(MovieSpec);

            var mappedListOfMovies = _mapper.Map<IReadOnlyList<Movie>, IReadOnlyList<MovieDetailsDto>>(listOfMovies);

            var specForCount = new MoviesSpecsForCount(specPrams);
            var count = await _unitOfWork.MoviesRepository.GetCountAsync(specForCount);

            return Ok(new Pagination<MovieDetailsDto>(specPrams.PageIndex,specPrams.PageSize,count, mappedListOfMovies));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDetailsDto>> GetByIdAsync(int id)
        {
            var movie = await _unitOfWork.MoviesRepository.GetAsync(id);
            if (movie is null) return NotFound(new ApiResponse(404));

            return Ok(_mapper.Map<Movie, MovieDetailsDto>(movie));

            
        }

        [HttpPost]
        public async Task<ActionResult<MovieWithImageDto>> CreateMovieAsync([FromForm] MovieWithImageDto model)
        {


            var mappedMovie = _mapper.Map<MovieWithImageDto, Movie>(model);

            var filePath = await DocumentsSeetings.UploadFileTo(model.Poster, "Images");

            mappedMovie.PosterUrl = filePath;

            _unitOfWork.MoviesRepository.Add(mappedMovie);

                await _unitOfWork.CompleteAsync();
            
            return Ok(model);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteAsync (int id)
        {
            var movie = await _unitOfWork.MoviesRepository.GetAsync(id);
            if (movie is null) return NotFound( new ApiResponse(404));

            _unitOfWork.MoviesRepository.Remove(movie);
            await    _unitOfWork.CompleteAsync();
            return Ok(true);

        }


        [HttpPut ("{id}")]
        public async Task<ActionResult<MovieDetailsDto>> UpdateMovieAsync(int id, [FromForm] MovieUpdateDto model)
        {
            //cheak if there is movie with this id 
            var movie = await _unitOfWork.MoviesRepository.GetAsync(id);
            if (movie is null) return BadRequest(new ApiResponse(400,"There is no movie with this id!"));

            //cheak if there is genre with this id 
            var genre = await _unitOfWork.GenresRepository.GetAsync(model.GenreId);
            if (genre is null) return BadRequest(new ApiResponse(400, "There is no genre with this id!"));

            var mappedMovie = new Movie();
            if(model.Poster is null)
                 mappedMovie = _mapper.Map<MovieUpdateDto, Movie>(model);
            
            else if(model.Poster is not null)
            {
                //delete the old poster
               await DocumentsSeetings.DeleteFile(movie.PosterUrl, "wwwroot/Images");

                //uplaod the new poster to images folder 
                //save the new posterurl 
             var posterUrl= await DocumentsSeetings.UploadFileTo(model.Poster, "Images");

                //map the dto to movie 
                 mappedMovie = _mapper.Map<MovieUpdateDto, Movie>(model);
                //add new poster url to the mappedMovie
                mappedMovie.PosterUrl = posterUrl;
            }

                //update movies with new movie deails
                _unitOfWork.MoviesRepository.Update(mappedMovie);
                await _unitOfWork.CompleteAsync();
                return Ok(mappedMovie);
            
        }
        
    }
}
