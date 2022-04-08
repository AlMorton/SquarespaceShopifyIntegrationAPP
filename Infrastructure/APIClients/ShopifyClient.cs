using Application.Interfaces;
using Application.UseCases;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Application.UseCases.Root;

namespace Infrastructure.APIClients
{

    public class ShopifyClient : IShopifyClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _shopUrl;

        public ShopifyClient(HttpClient httpClient, IOptions<ShopifyConfig> shopifyConfig)
        {
            _httpClient = httpClient;
            _apiKey = shopifyConfig.Value.ApiKey;
            _shopUrl = shopifyConfig.Value.ShopUrl;
        }

        public async Task<bool> CreateProduct(Product product)
        {            
            var jsonBody = JsonSerializer.Serialize(new Root { product = product });

            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            content.Headers.Add("X-Shopify-Access-Token", _apiKey);

            var response = await _httpClient.PostAsync($"{_shopUrl}/admin/api/2021-10/products.json", content);

            return response.IsSuccessStatusCode;
        }
    }


}
