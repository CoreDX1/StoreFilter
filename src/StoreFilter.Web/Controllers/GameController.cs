using Microsoft.AspNetCore.Mvc;
using StoreFilter.Application.Interfaces;

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
    [Route("list")]
    public async Task<IActionResult> GetGames()
    {
        var response = await _app.GameListAsync();
        return Ok(response);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetGameById(Guid id)
    {
        var response = await _app.GameDetailAsync(id);
        return Ok(response);
    }
}
