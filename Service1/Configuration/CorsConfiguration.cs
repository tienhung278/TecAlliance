using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Service1.Configuration;

public static class CorsConfiguration
{
    public static Action<CorsOptions> Configure => options =>
    {
        options.AddDefaultPolicy(policyBuilder =>
        {
            policyBuilder.AllowAnyMethod();
            policyBuilder.AllowAnyHeader();
            policyBuilder.AllowAnyOrigin();
        });
    };
}