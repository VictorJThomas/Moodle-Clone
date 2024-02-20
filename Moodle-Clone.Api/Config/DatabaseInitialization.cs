using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moodle_Clone.Infraestructure.Context;

namespace Moodle_Clone.Api.Config
{
    public class DatabaseInitialization
    {
        public static void Migrations(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            serviceScope.ServiceProvider.GetService<DatabaseContext>().Database.Migrate();
        }
    }
}
