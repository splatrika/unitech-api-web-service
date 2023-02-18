using System;
using EasyUnitech.NetApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EasyUnitech.NetApi.WebService.Filters;

public class UnitechAuthorizationFilter : IAuthorizationFilter
{
    private IKeysAccessor _keysAccessor;

    public UnitechAuthorizationFilter(IKeysAccessor keysAccessor)
    {
        _keysAccessor = keysAccessor;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (_keysAccessor.Get() == null)
        {
            context.Result = new UnauthorizedResult();
        }
    }
}

