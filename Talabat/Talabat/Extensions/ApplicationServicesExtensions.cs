using BLL.Interface;
using BLL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Talabat.Errors;
using Talabat.API.Helpers;
using Talabat.BLL.Interfaces;

using Talabat.BLL.Repository;
using Talabat.BLL.Services;
using Talabat.Helpers;
using Talabat.BLL.Repositories;

namespace Talabat.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddSingleton<IResponseCacheService, ResponseCacheService>();
         
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<commentsrepos, commentsrepos>();
            services.AddScoped<AlbumsRepo, AlbumsRepo>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddAutoMapper(typeof(MappingProfile));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState.Where(M => M.Value.Errors.Count > 0)
                                            .SelectMany(M => M.Value.Errors)
                                            .Select(E => E.ErrorMessage).ToArray();
                    var errorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}
