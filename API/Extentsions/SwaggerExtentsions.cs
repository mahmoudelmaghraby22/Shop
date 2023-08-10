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
    public static class SwaggerExtentsions
    {
        public static IServiceCollection AddSwaggerService
                (this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo  
                    {Title = "Market Api", Version = "v1"});
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentations
            (this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Market api v1"));

            return app;
        }
    }
}