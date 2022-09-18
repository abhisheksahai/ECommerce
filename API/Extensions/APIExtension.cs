using API.MiddleWare;
using API.Settings;
using DataAccess.Data;
using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

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
            builder.Services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(ApiHelper.GetECommerceConnectionString() ?? throw new InvalidOperationException("Invalid default connetion string"), b => b.MigrationsAssembly("DataAccess")));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            ServiceProvider serviceProvider = builder.Services.BuildServiceProvider();
            ECommerceDbContext modelContext = serviceProvider.GetService<ECommerceDbContext>();
            modelContext.Database.Migrate();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("PolicyClientApp", builder =>
                {
                    builder.WithOrigins("http://localhost:3000/")
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .WithHeaders(HeaderNames.ContentType);
                });
            });

        }

        /// <summary>
        /// Configure the HTTP request pipeline
        /// </summary>
        /// <param name="app"></param>
        public static void AddMiddleWare(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleWare>();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("PolicyClientApp");
            //app.UseCors(opt => opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
