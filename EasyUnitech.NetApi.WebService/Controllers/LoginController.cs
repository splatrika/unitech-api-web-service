using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyUnitech.NetApi.Interfaces;
using EasyUnitech.NetApi.Models;
using EasyUnitech.NetApi.WebService.Model;
using Microsoft.AspNetCore.Mvc;

namespace EasyUnitech.NetApi.WebService.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<ActionResult<Keys>> LoginAsync([FromBody] LoginRequest request)
        {
            Keys? keys = null;
            if (await _loginService.TryLoginAsync(request.Login, request.Password, k => keys = k))
            {
                return Ok(keys);
            }
            return Unauthorized();
        }

        [HttpPost("validate")]
        public async Task<ValidateKeysResponse> ValidateAsync([FromBody] KeysRequest request)
        {
            return new()
            {
                Valid = await _loginService.ValidateAsync(request.ToKeys())
            };
        }
    }
}

