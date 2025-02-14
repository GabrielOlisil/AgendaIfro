using AgendaApp.Services;

namespace AgendaApp.Configuration;

public static class Extensions
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IntervaloService>();
        services.AddScoped<CategoriaService>();
        services.AddScoped<AgendaService>();
    }
}