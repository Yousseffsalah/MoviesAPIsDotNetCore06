using AutoMapper;
using Movies.DAL.Data.Entites;
using Movies.PL.APIs.Dtos;

namespace Movies.PL.APIs.Helpers
{
    internal class PosterUrlResolver : IValueResolver<  Movie, MovieDetailsDto, String>
    {
        private readonly IConfiguration _configuration;

        public PosterUrlResolver(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string Resolve(Movie source, MovieDetailsDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PosterUrl))
                return $"{_configuration["BaseUrl"]}/{source.PosterUrl}";

            return string.Empty;
        }
    }
}