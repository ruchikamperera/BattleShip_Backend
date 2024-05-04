using AutoMapper;
using BattleShips.Dtos;
using BattleShips.Models;

namespace BattleShips.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ship, ShipDto>().ReverseMap();
            CreateMap<Grid, GridDto>().ReverseMap();
            CreateMap<GridLocation, GridLocationDto>().ReverseMap();
        }
    }
}
