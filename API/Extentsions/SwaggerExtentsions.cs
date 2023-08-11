using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
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