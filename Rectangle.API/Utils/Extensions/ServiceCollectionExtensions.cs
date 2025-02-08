using Rectangle.API.Domain.Contracts;
using Rectangle.API.Services;
using Rectangle.API.Utils.Contracts;
using Rectangle.API.Utils.Files;

namespace Rectangle.API.Utils.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRectangleServices(this IServiceCollection services)
        {
            services.AddScoped<IRectangleValidationService, RectangleValidationService>();
            services.AddScoped<IRectangleService, RectangleService>();
            services.AddScoped<IFileStorageUtil, FileStorageUtil>();
            return services;
        }
    }
}
