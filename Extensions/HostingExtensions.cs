using ChatApp.Data;
using ChatApp.Hubs;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Extensions;

public static class HostingExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add DbContext
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        // Add Services
        services.AddSingleton<ChatService>();
        services.AddSignalR();

        // Add Controllers
        services.AddControllers(); 

        // Add Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    public static WebApplication UseAppPipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.UseWebSockets();

        app.MapHub<ChatHub>("/chatHub");


        return app;
    }
}
