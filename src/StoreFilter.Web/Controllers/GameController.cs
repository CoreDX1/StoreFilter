using Microsoft.AspNetCore.Mvc;

namespace StoreFilter.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    [HttpGet]
    [Route("message")]
    public string Message()
    {
        return "Hello World";
    }
}
