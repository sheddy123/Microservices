namespace PlatformService.Extensions.Program;

public static class MiddlewareInitializer
{
    public static WebApplication ConfigureMiddleWare(this WebApplication application)
    {

        // Configure the HTTP request pipeline.
        if (application.Environment.IsDevelopment())
        {
            ConfigureSwagger(application);
        }
        application.UseHttpsRedirection();

        return application;
    }

    private static void ConfigureSwagger(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}