using API.Settings;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class APIExtension
    {
        /// <summary>
        /// Add services to the container.
        /// </summary>
        /// <param name="builder"></param>
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors();

            builder.Logging.ClearProviders();

            ApiHelper.ApiConfiguration = builder.Configuration.GetSection(ApiConfiguration.Key).Get<ApiConfiguration>();
            builder.Services.AddDbContext<ECommerceDbContext >(options => options.UseSqlServer(ApiHelper.GetDefaultConnection() ?? throw new InvalidOperationException("Invalid connetion string"),b=>b.MigrationsAssembly("API")));

            ServiceProvider serviceProvider = builder.Services.BuildServiceProvider();
            ECommerceDbContext  modelContext = serviceProvider.GetService<ECommerceDbContext >();
            modelContext.Database.Migrate();
            DbInitializer.Initialize(modelContext);
        }

        /// <summary>
        /// Configure the HTTP request pipeline
        /// </summary>
        /// <param name="app"></param>
        public static void AddMiddleWare(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(opt => opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
