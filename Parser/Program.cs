using Data;
using Data.IRepository;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Parser
{
    internal static class Program
    {
        public static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<Parser>();
            services.AddDbContext<MyDbContext>(options => options.UseMySQL("server = localhost; user = root; password = ; database = help_game", c => c.MigrationsAssembly("SolomonkHTMLParser")));
            services.AddScoped<IMonstersRepository, MonstersRepository>();
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var temporisTool = serviceProvider.GetRequiredService<Parser>();
                Application.Run(temporisTool);
            }
        }
    }
}