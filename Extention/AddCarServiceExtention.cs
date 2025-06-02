using CarAPI.Data.AppDContext;
using CarAPI.DTO;
using CarAPI.Service;
using System.Text.Json;

namespace CarAPI.Extention
{
    public static class AddCarServiceExtention
    {
        public static IServiceCollection AddCarService(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Car Management",
                });
               
                o.UseOneOfForPolymorphism();

                o.SelectDiscriminatorNameUsing(type => type.Name switch
                {
                    nameof(CarDTO) => "Manufacturer",
                    _ => null
                });
                
            });


            services.AddScoped<ICarService, CarService>();
            return services;
        }
    }
}
