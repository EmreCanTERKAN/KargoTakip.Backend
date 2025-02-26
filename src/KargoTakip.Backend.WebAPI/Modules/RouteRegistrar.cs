namespace KargoTakip.Backend.WebAPI.Modules;

public static class RouteRegistrar
{
    public static void RegisterRoutes(this IEndpointRouteBuilder app)
    {
        app.RegisterKargoRoutes();
        app.RegisterAuthRoutes();
    }
}
