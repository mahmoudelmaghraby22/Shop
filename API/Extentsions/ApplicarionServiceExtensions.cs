using System;
using System.Linq;
using API.Data;
using API.Errors;
using API.Helpers;
using API.Middleware;
using AutoMapper;
using Core.interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace API.Extentions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService
                (this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>),
                typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();

            services.Configure<ApiBehaviorOptions>(options => 
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage);

                    var errorResponce= new ApiValidationErrorResponce
                    {
                        Errors = errors
                    };

                     return new BadRequestObjectResult(errorResponce);
                };               
            });

            return services;
        }
    }
}