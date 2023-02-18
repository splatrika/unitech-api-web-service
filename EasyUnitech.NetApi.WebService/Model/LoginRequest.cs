using System;
namespace EasyUnitech.NetApi.WebService.Model;

public class LoginRequest
{
	public required string Login { get; init; }

    public required string Password { get; init; }
}

