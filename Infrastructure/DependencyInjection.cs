using Infrastructure.APIClients;
using Infrastructure.Webscrappers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Http;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddScoped<ISquareSpaceScrapper, SquareSpaceScrapper>();            

            services.AddHttpClient<IShopifyProductClient, ShopifyClient>();

            services.AddHttpClient<IShopifyCollectionClient, ShopifyClient>();

            services.AddHttpClient<ISqaureSpaceClient, SqaureSpaceClient>();

            return services;
        }
    }
}
