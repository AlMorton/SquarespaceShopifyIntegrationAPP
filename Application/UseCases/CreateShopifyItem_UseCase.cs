using Application.Events;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Application.UseCases.Root;
using static Application.UseCases.Root.Product;

namespace Application.UseCases
{
    public class CreateShopifyItem_UseCase
    {
        private readonly ISquareSpaceScrapper _squareSpaceScrapper;
        private readonly IShopifyClient _shopifyClient;

        public CreateShopifyItem_UseCase(ISquareSpaceScrapper squareSpaceScrapper, IShopifyClient shopifyClient)
        {
            _squareSpaceScrapper = squareSpaceScrapper;
            _shopifyClient = shopifyClient;
        }

        public async Task HandleAsync(TransferEvent @event)
        {
            var item = _squareSpaceScrapper.GetItemDetails(@event.ItemURL);

            var product = new Product
            {
                body_html = item.Description,
                images = item.ImageUrls.Select(u => new Image
                {
                    src = u,
                }).ToList(),
                image = item.ImageUrls.Take(1).Select(u => new Image
                {
                    src = u,
                }).First(),
                product_type = "Picture",
                title = item.Title,
                vendor = "Test",
                variants = new List<Variant>
                        {
                            new Variant
                            {
                                option1 = "",
                                price = item.Price.Substring(1),
                                sku = ""
                            }
                        }
            };

            await _shopifyClient.CreateProduct(product);
        }
    }

    public class Root
    {
        public Product product { get; set; }

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

            public class Image
            {
                public string src { get; set; }
            }

            public class Variant
            {
                public string option1 { get; set; }
                public string price { get; set; }
                public string sku { get; set; }
            }
        }
    }

    public class ItemDTO
    {
        public string[] ImageUrls { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; } = "";
    }


    public class CollectionItem
    {
        public string HostUrl { get; set; }
        public string ItemUrl { get; set; }
        public string ImgSrc { get; set; }
        public string Name { get; set; }
        public bool Transfer { get; set; } = false;

        public string JsonMePlease() => JsonSerializer.Serialize(this);

        public string GetImageWithSize(int size)
        {
            return ImgSrc + $"?format={size}w";
        }

        public string GetAbsoluteURL() => $"https://{HostUrl}{ItemUrl}";
    }
}
