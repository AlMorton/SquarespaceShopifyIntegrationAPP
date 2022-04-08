using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
            bool success = false;
            try
            {
                var jsonBody = JsonSerializer.Serialize(new Root { product = product });

                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                content.Headers.Add("X-Shopify-Access-Token", _apiKey);                

                var response = await _httpClient.PostAsync($"{_shopUrl}/admin/api/2021-10/products.json", content);

                var message = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode) throw new Exception(message);

                success = response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {

                
            }

            return success;
        }
    }

    public class Image
    {
        public string src { get; set; }
    }

    public class Product
    {
        public string title { get; set; }
        public string body_html { get; set; }
        public string vendor { get; set; }
        public string product_type { get; set; }
        public List<string> tags { get; set; } = new List<string>();
        public List<Image> images { get; set; } = new List<Image>();
        public Image image { get; set; } = new Image();
        public List<Variant> variants { get; set; } = new List<Variant>();
    }

    public class Variant
    {
        public string option1 { get; set; }
        public string price { get; set; }
        public string sku { get; set; }
    }

    public class Root
    {
        public Product product { get; set; }
    }
}
