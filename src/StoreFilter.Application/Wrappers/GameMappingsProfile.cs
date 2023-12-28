using AutoMapper;
using StoreFilter.Application.DTO.Game.Response;
using StoreFilter.Application.DTO.Game.Request;
using StoreFilter.Infrastructure.Commons.Game.Request;
using StoreFilter.Domain.Entities;

namespace StoreFilter.Application.Wrappers;

public class GameMappingsProfile : Profile
{
    public GameMappingsProfile()
    {
        CreateMap<Game, GameTypeResponse>();
        CreateMap<GameTypeFilterRequestDto, GameFilterProductsDto>();
    }
}
