using System;
using EasyUnitech.NetApi.Models;

namespace EasyUnitech.NetApi.WebService.Model;

public class KeysRequest
{
	public string SessCommon { get; init; }

	public string CSRF { get; init; }

	public Keys ToKeys()
	{
		return new(CSRF, SessCommon);
	}
}

