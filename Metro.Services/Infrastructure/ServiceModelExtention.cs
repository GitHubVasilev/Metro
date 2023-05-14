using Metro.Data.Entities;
using Metro.Data.Infrastructure;
using Metro.Services.Interfaces;
using Metro.Services.Models.DTO;
using Metro.Services.Models.Factories;
using Metro.Services.Services;
using Microsoft.Extensions.DependencyInjection;


namespace Metro.Services.Infrastructure
{
    public static class ServiceModulesExtention
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddUnitOfWork();
            services.AddScoped<IFactory<Station, StationDTO>, StationFastory>();
            services.AddScoped<IFactory<Branch, BranchDTO>, BranchFactory>();
            services.AddScoped<IFactory<Route, RouteDTO>, RouteFactory>();
            services.AddScoped<IRoutingService, RoutingService>();
            services.AddScoped<IStationsService, StationsService>();
            return services;
        }
    }
}
