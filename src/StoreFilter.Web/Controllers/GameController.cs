using Microsoft.AspNetCore.Mvc;
using StoreFilter.Application.DTO.Game.Request;
using StoreFilter.Application.Interfaces;
using StoreFilter.Domain.Entities;

namespace StoreFilter.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameApplication _app;

    public GameController(IGameApplication app)
    {
        _app = app;
    }

    [HttpGet]
    [ProducesResponseType(statusCode: 200, Type = typeof(IEnumerable<Game>))]
    [Consumes("application/json")]
    public async Task<ActionResult<IEnumerable<Game>>> ListAllGameAsync()
    {
        var game = await _app.GameListAsync();
        return StatusCode(200, game);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(Game))]
    public async Task<ActionResult<Game>> GetGameDetailByIdAsync(Guid id)
    {
        var game = await _app.GameDetailAsync(id);
        return StatusCode(statusCode: 200, value: game);
    }

    [HttpPost]
    [Route("filter")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(Game))]
    public async Task<ActionResult<Game>> PostGameFilterAsync(
        [FromBody] GameTypeFilterRequestDto filter
    )
    {
        var game = await _app.GameFilterAsync(filter);
        return StatusCode(200, game);
    }

}
