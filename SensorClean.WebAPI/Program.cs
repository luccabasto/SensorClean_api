using SensorClean.Application.Interface.School;
using Microsoft.OpenApi.Models;
using SensorClean.Application.Services.UseCases.School;
using SensorClean.Application.Interface.Repositories;
using SensorClean.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using AspNetCoreRateLimit;

namespace SensorClean.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Console.WriteLine("CONN STR: " + builder.Configuration.GetConnectionString("DefaultConnection"));


            builder.Services.AddControllers();
            builder.Services.AddMemoryCache();
            builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
            builder.Services.AddInMemoryRateLimiting();
            builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            builder.Services.AddOpenApi();

            /// Swagger Configuration
            builder.Services.AddSwaggerGen(c =>
            {
                var xmlFile = "SensorClean.WebAPI.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddSwaggerGen(
                c => c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SensorClean API",
                    Version = "v1",
                    Description = "API para solu��es clim�ticas."
                }
              )
           );

            builder.Services.AddDbContext<SensorCleanDbContext>(options =>
            options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

            /// Service 
            builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
            builder.Services.AddScoped<IGetAllSchools, GetAllSchools>();
            builder.Services.AddScoped<IGetSchoolById, GetSchoolById>();
            builder.Services.AddScoped<ICreateSchool, CreateSchool>();
            builder.Services.AddScoped<IUpdateSchool, UpdateSchool>();
            builder.Services.AddScoped<IRemoveSchool, RemoveSchool>();




            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tockify API V1");
            });

            app.MapGet("/", context =>
            {
                context.Response.Redirect("/swagger");
                return Task.CompletedTask;
            });

            app.UseIpRateLimiting();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}