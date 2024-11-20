using Microsoft.AspNetCore.Http;
using OnlineAccounting.Application.Services.Tenant;

namespace OnlineAccounting.Persistence.Middlewares;

public class TenantMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, ITenantService tenantService)
    {
        var tenantIdentifier = context.Request.Headers["X-Tenant-ID"].FirstOrDefault()
                               ?? context.Request.Query["tenantId"].FirstOrDefault();

        if (!string.IsNullOrEmpty(tenantIdentifier))
        {
            var tenant = await tenantService.GetTenantByIdAsync(long.Parse(tenantIdentifier));
            if (tenant != null) context.Items["Tenant"] = tenant;
        }

        await next(context);
    }
}