using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolAPI.Project.Infrastructure.Persistence;

namespace SchoolAPI.Project.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("connString");
        services.AddDbContext<SchoolDBContext>(options => options.UseSqlServer(connectionString));

        return services;
    }
}
