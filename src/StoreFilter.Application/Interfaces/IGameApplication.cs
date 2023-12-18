using StoreFilter.Application.Commons.Base;
using StoreFilter.Application.DTO.Game.Response;

namespace StoreFilter.Application.Interfaces;

public interface IGameApplication
{
    public Task<BaseResponse<IEnumerable<GameTypeResponse>>> GameListAsync();
}
