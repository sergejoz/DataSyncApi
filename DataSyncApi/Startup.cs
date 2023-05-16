using DataSyncApi.Data;
using DataSyncApi.Interfaces;
using DataSyncApi.Repositories;
using DataSyncApi.Services;
using Microsoft.EntityFrameworkCore;

namespace DataSyncApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Конфигурация сервисов
            services.AddControllers();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });


            // Добавление зависимостей
            services.AddScoped<IDatasetRepository, DatasetRepository>();
            services.AddScoped<DataLoader>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
