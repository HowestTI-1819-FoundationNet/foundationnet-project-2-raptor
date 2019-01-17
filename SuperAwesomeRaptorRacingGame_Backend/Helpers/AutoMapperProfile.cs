using AutoMapper;
using SuperAwesomeRaptorRacingGame_Backend.Dtos;
using SuperAwesomeRaptorRacingGame_Backend.Entities;

namespace SuperAwesomeRaptorRacingGame_Backend.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Score, ScoreDto>();
            CreateMap<ScoreDto, Score>();
        }
    }
}
