
using BLL.Interface;
using BLL.Repository;
using DAL.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using Talabat.Extensions;
using Talabat.Middlewares;
using Talabat.DAL.Entities.Identity;
using Talabat.DAL.Identity;
using Talabat.Helpers;

namespace Talabat
{
    public class Program
    {
        public static async Task  Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
          
           builder.Services.AddSingleton<IConnectionMultiplexer>(S =>
            {
                var connection = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(connection);
            });
           builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });
            builder.Services.AddApplicationServices();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.AddSwaggerDocumentation();
            var app = builder.Build();
          using  var host= app.Services.CreateScope();
            var services = host.ServiceProvider;
            var LoggerFactory= services.GetRequiredService<ILoggerFactory>();
            try
            {
      var context=services.GetRequiredService<StoreContext>();
               await context.Database.MigrateAsync();
              await  StoreContextSeed.SeedAsync(context, LoggerFactory);

                var identityContext = services.GetRequiredService<AppIdentityDbContext>();
                await identityContext.Database.MigrateAsync();
                var userManger = services.GetRequiredService<UserManager<AppUser>>();
                await AppIdentityDbContextSeed.SeedUsersAsync(userManger);
            }
            catch (Exception ex)
            {
                var logger=LoggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an error occured while migraton");
            }
            // Configure the HTTP request pipeline.
            app.UseMiddleware<ExceptionMiddleware>();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
          
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseAuthentication(); 
            app.UseAuthorization();
            
            



            app.MapControllers();

            app.Run();
        }
    }
}