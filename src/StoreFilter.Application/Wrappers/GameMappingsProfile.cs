using AutoMapper;
using StoreFilter.Application.DTO.Game.Response;
using StoreFilter.Domain.Entities;

namespace StoreFilter.Application.Wrappers;

public class GameMappingsProfile : Profile
{
    public GameMappingsProfile()
    {
        CreateMap<Game, GameTypeResponse>();
    }
}
