using PlatformService.Data;
using PlatformService.Models;

namespace PlatformService.Extensions.Program;

public static class EndpointsInitializer
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {
       app.UseCors(Constants.Default.MyAllowSpecificOrigins);
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        PrepDb.PrepPopulation(app);
        return app;
    }
}