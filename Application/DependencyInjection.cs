using Application.UseCases;
using Application.UseCases.Products;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<CreateShopifyProductFromSquareSpace_UseCase>();

            return services;
        }
    }
}
