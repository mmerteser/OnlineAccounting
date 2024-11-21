using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OnlineAccounting.Application.Authentication;
using OnlineAccounting.Application.Authentication.Models;

namespace OnlineAccounting.WebApi.Controllers;

public sealed class AuthController(IAuthenticationService authenticationService) : BaseApiController
{
    [HttpPost("[action]")]
    public async Task<IResult> Login([FromBody] LoginInput loginRequest)
    {
        var result = await authenticationService.Login(loginRequest);
        
        return Results.Ok(result);
    }
}