using Application.UseCases;
using Application.UseCases.Products;
using Infrastructure.APIClients.SquareSpaceJSONModels;
using System.Text.Json;

namespace Infrastructure.APIClients
{
    public class SqaureSpaceClient : ISqaureSpaceClient
    {
        private readonly HttpClient _httpClient;

        public SqaureSpaceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CollectionItem>> GetCollectionItemsAsync(string url)
        {
            Uri uri = new Uri(Uri.UnescapeDataString(url));
            
            _httpClient.DefaultRequestHeaders.Add("user-agent", "whatever-dude");

            var response = await _httpClient.GetAsync(uri.ToString() + "?format=json-pretty");

            var jsonBody = await response.Content.ReadAsStringAsync();
            var root = JsonSerializer.Deserialize<RootJustItemsAndCollection>(jsonBody);

            return root.items.Select(i => new CollectionItem
            {
                Name = i.title,
                ItemUrl = i.fullUrl,
                ImgSrc = i.assetUrl,
                HostUrl = uri.Host

            }).ToList();
        }

    }
}
