using AutoMapper;
using Store.Infrastructure.Persistences.Interfaces;
using StoreFilter.Application.Commons.Base;
using StoreFilter.Application.DTO.Game.Request;
using StoreFilter.Application.DTO.Game.Response;
using StoreFilter.Application.Interfaces;
using StoreFilter.Domain.Entities;
using StoreFilter.Infrastructure.Commons.Game.Request;

namespace StoreFilter.Application.Services;

public class GameApplication : IGameApplication
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GameApplication(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<IEnumerable<GameTypeResponse>>> GameListAsync()
    {
        var response = new BaseResponse<IEnumerable<GameTypeResponse>>();
        var games = await _unitOfWork.Game.GetGames();

        if (games == Enumerable.Empty<Game>())
        {
            response.IsSuccess = false;
            response.Message = "No games found";
        }
        else
        {
            response.IsSuccess = true;
            response.Message = "Games found";
            response.Data = _mapper.Map<IEnumerable<GameTypeResponse>>(games);
        }
        return response;
    }

    public async Task<BaseResponse<GameTypeResponse>> GameDetailAsync(Guid id)
    {
        var response = new BaseResponse<GameTypeResponse>();
        var game = await _unitOfWork.Game.GetGame(id);
        if (game == null)
        {
            response.IsSuccess = false;
            response.Message = "Game not found";
        }
        else
        {
            response.IsSuccess = true;
            response.Message = "Game found";
            response.Data = _mapper.Map<GameTypeResponse>(game);
        }
        return response;
    }

    public async Task<BaseResponse<IEnumerable<GameTypeResponse>>> GameFilterAsync(GameTypeFilterRequestDto filter)
    {
        var response = new BaseResponse<IEnumerable<GameTypeResponse>>();
        var filterGame = _mapper.Map<GameFilterProductsDto>(filter);
        var games = await _unitOfWork.Game.PostFilterGames(filterGame);


        if (games == Enumerable.Empty<Game>())
        {
            response.IsSuccess = false;
            response.Message = "No se encontraron juegos";
        }
        else
        {
            response.IsSuccess = true;
            response.Message = "It's work";
            response.Data = _mapper.Map<IEnumerable<GameTypeResponse>>(games);
        }

        return response;
    }
}
