using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyUnitech.NetApi.Interfaces;
using EasyUnitech.NetApi.Models;
using EasyUnitech.NetApi.WebService.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EasyUnitech.NetApi.WebService.Controllers;

[Route("user")]
[TypeFilter(typeof(UnitechAuthorizationFilter))]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<User> GetAsync()
    {
        return await _userService.GetUserAsync();
    }
}

