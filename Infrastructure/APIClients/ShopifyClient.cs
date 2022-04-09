using Application.Interfaces;
using Application.UseCases;
using Application.UseCases.Products;
using Infrastructure.APIClients.SquareSpaceJSONModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Application.UseCases.Products.Product_Root;

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

        public async Task<ProductEntity> CreateProduct(Product product)
        {            
            var jsonBody = JsonSerializer.Serialize(new Product_Root { product = product });

            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            content.Headers.Add("X-Shopify-Access-Token", _apiKey);

            var response = await _httpClient.PostAsync($"{_shopUrl}/admin/api/2021-10/products.json", content);

            if(response.StatusCode != System.Net.HttpStatusCode.Created) throw new Exception(response.StatusCode.ToString());

            var json = await response.Content.ReadAsStringAsync();

            var entity = JsonSerializer.Deserialize<ProductEntityRoot>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true                
            });
                
            return entity.Product;
        }

        public async Task<bool> CreateCollection(CustomCollection customCollection)
        {
            var jsonBody = JsonSerializer.Serialize(new Root_Collection { custom_collection = customCollection });

            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            content.Headers.Add("X-Shopify-Access-Token", _apiKey);

            var response = await _httpClient.PostAsync($"{_shopUrl}/admin/api/2021-10/custom_collections.json", content);

            return response.IsSuccessStatusCode;
        }
    }

    public class CustomCollection
    {
        public string title { get; set; }
    }

    public class CustomCollectionEntity
    {
        public long Id { get; set; }
    }

    public class Root_Collection
    {
        public CustomCollection custom_collection { get; set; }
    }    
}
