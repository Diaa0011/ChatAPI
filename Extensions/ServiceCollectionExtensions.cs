using ChatApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Extensions;

public class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppService( IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        //adding controllers
        services.AddControllers();
        //adding services
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
}