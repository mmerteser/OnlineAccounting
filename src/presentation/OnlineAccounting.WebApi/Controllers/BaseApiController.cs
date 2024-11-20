using Microsoft.AspNetCore.Mvc;

namespace OnlineAccounting.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
}