using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SchoolAPI.Project.Infrastructure.Persistence;

public static class DBInitializer
{
    public static void InitialiseDatabase(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<SchoolDBContext>();
        context.Database.Migrate();
    }
}