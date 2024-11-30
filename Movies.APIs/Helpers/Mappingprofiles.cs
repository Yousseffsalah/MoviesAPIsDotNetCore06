using AutoMapper;
using Movies.DAL.Data.Entites;
using Movies.PL.APIs.Dtos;

namespace Movies.PL.APIs.Helpers
{
    public class Mappingprofiles:Profile
    {
        public Mappingprofiles()
        {
            CreateMap<Movie, MovieWithImageDto>().ReverseMap();

            CreateMap<MovieDetailsDto,Movie >().ReverseMap()
                .ForMember(D => D.GenreName
                , O => O.MapFrom(S =>S.Genre.Name))
                .ForMember(D => D.PosterUrl, O => O.MapFrom<PosterUrlResolver>()).ReverseMap();

            CreateMap<MovieUpdateDto, Movie>();

        }

    }
}
