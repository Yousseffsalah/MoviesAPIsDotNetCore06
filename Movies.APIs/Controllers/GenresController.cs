using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.BAL.Interfaces.UnitOfWork;
using Movies.DAL.Data.Entites;
using Movies.PL.APIs.Dtos;
using Movies.PL.APIs.Errors;

namespace Movies.PL.APIs.Controllers
{

    public class GenresController : ApiBaseController
    {

        public GenresController(IUnitOfWork unitOfWork, IMapper mapper):base(unitOfWork,mapper) 
        {
           
        }


        [HttpGet] // GET : /api/Genres
        public async Task<ActionResult<IReadOnlyList<Genre>>> GetAllAsync()
        {
            var listOfGenres = await _unitOfWork.GenresRepository.GetAllAsync();
            return Ok(listOfGenres);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDto>> GetByIDAsync(int id)
        {
            var genre = await _unitOfWork.GenresRepository.GetAsync(id);
            if (genre is null) return NotFound(new ApiResponse(40, "There is no genre with this id"));

            var maapedGenre = new GenreDto()
            {
                Name = genre.Name
            };

            return Ok(maapedGenre);
        }

        [HttpPost]
        public async Task<ActionResult<Genre>> AddGenreAsync(GenreDto model)
        {
            var genre = new Genre()
            {
                Name = model.Name
            };
            _unitOfWork.GenresRepository.Add(genre);
           await _unitOfWork.CompleteAsync();

            return Ok(genre);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Genre>> UpdateGenreAsync(int id, [FromBody] GenreDto model)
        {
            var genre = await _unitOfWork.GenresRepository.GetAsync(id);
            if (genre is null)
                return BadRequest(new ApiResponse(400));

            genre.Name = model.Name;
            _unitOfWork.GenresRepository.Update(genre);
            await _unitOfWork.CompleteAsync();

            return Ok(genre);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Genre>> DeleteAsync(int id)
        {

            var genre = await _unitOfWork.GenresRepository.GetAsync(id);
            if (genre is null) return NotFound( new ApiResponse(404));
            _unitOfWork.GenresRepository.Remove(genre);
            await _unitOfWork.CompleteAsync();
            return Ok(genre);
        }

    }
}
