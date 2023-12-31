using StoreFilter.Application.Commons.Base;
using StoreFilter.Application.DTO.Game.Request;
using StoreFilter.Application.DTO.Game.Response;

namespace StoreFilter.Application.Interfaces;

public interface IGameApplication
{
    public Task<BaseResponse<IEnumerable<GameTypeResponse>>> GameListAsync();

    public Task<BaseResponse<GameTypeResponse>> GameDetailAsync(Guid id);

    public Task<BaseResponse<IEnumerable<GameTypeResponse>>> GameFilterAsync(GameTypeFilterRequestDto filter);
}
