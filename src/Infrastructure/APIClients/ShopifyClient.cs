using Application.Interfaces;
using Application.UseCases;
using Application.UseCases.Products;
using Infrastructure.APIClients.ShopifyJSONModels;
using Infrastructure.APIClients.SquareSpaceJSONModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.APIClients
{

    public class ShopifyClient : IShopifyProductClient, IShopifyCollectionClient
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

            var content = CreateContent(new Product_Root<Product> { product = product });

            var response = await _httpClient.PostAsync($"{_shopUrl}/admin/api/2021-10/products.json", content);

            var entity = await CreateEntityFromResponse<Product_Root<ProductEntity>>(response);

            return entity.product;
        }

        public async Task<CustomCollectionEntity> CreateCollection(CustomCollectionPost customCollection)
        {
            var content = CreateContent(new Root_CustomCollection<CustomCollectionPost> { custom_collection = customCollection });

            var response = await _httpClient.PostAsync($"{_shopUrl}/admin/api/2021-10/custom_collections.json", content);

            var entity = await CreateEntityFromResponse<Root_CustomCollection<CustomCollectionEntity>>(response);

            return entity.custom_collection;
        }

        public async Task<CollectEntity> LinkProductToCollection(CollectLinkPost collectLink)
        {
            var content = CreateContent(new Root_Collect<CollectLinkPost> { collect = collectLink });

            var response = await _httpClient.PostAsync($"{_shopUrl}/admin/api/2022-04/collects.json", content);

            var entity = await CreateEntityFromResponse<Root_Collect<CollectEntity>>(response);

            return entity.collect;
        }

        private StringContent CreateContent<T>(T data)
        {
            var jsonBody = JsonSerializer.Serialize(data);

            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            content.Headers.Add("X-Shopify-Access-Token", _apiKey);

            return content;
        }
        private static async Task<TResponseEntity> CreateEntityFromResponse<TResponseEntity>(HttpResponseMessage response)
        {
            if (response.StatusCode != System.Net.HttpStatusCode.Created) throw new Exception(response.StatusCode.ToString());

            var json = await response.Content.ReadAsStringAsync();

            var entity = JsonSerializer.Deserialize<TResponseEntity>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });

            return entity;
        }
    }

}
