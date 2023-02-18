using EasyUnitech.NetApi.Interfaces;
using EasyUnitech.NetApi.Models;

namespace EasyUnitech.NetApi.WebService;

public class KeysAccessor : IKeysAccessor
{
    private IHttpContextAccessor _httpContextAccessor;

    public KeysAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Keys? Get()
    {
        var context = _httpContextAccessor.HttpContext;
        if (context is null) return null;
        var values = context.Request.Headers.Authorization
            .FirstOrDefault()?
            .Split("/"); ;
        if (values == null || values?.Length != 2) return null;
        return new(values.First(), values.Last());
    }
}

