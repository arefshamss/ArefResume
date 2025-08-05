using Aref.Application.Services.Implementations;
using Aref.Application.Services.Interfaces;

namespace Aref.Web.Extensions;

internal static class HttpClientFactories
{
    internal static IServiceCollection AddHttpClientFactories(this IServiceCollection services)
    {
        services.AddHttpClient<ICaptchaService, CaptchaService>(client =>
        {
            client.BaseAddress = new("https://www.google.com/recaptcha/api/");
        });
        return services;
    }
}

