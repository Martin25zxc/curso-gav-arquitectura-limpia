using ArquitecturaLimpiaOdont.Application.Contracts.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ArquitecturaLimpiaOdont.Identity.Services;

public class UsersService : IUsersService
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public UsersService(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public string ObtenerUsuarioId()
    {
        return httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
    }
}