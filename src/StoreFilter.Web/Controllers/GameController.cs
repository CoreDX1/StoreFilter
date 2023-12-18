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
    [Route("message")]
    public string Message()
    {
        return "Hello World";
    }

    [HttpGet]
    [Route("games")]
    public async Task<IActionResult> GetGames()
    {
        var response = await _app.GameListAsync();
        return Ok(response);
    }
}
