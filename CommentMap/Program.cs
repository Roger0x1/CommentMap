using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using CommentMap.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;


/*    This section of code has been modified to ensure that the database exists,
 *    otherwise it creates a database.  Good for initial installs, or if you want to 
 *    start fresh, not so good if you have a ton of data and sql screws up.
 *    Be aware.
 */
namespace CommentMap
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<RepositoryContext>();

                    // this call ensures the DB exists, or it creates a new one.  
                    // Make sure your DB connection is set correctly before running the program.
                     context.Database.EnsureCreated();
                    // context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
