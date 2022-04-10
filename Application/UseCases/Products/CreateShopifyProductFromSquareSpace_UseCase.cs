using Application.Interfaces;
using System.Text.Json;
using static Application.UseCases.Products.Product;


namespace Application.UseCases.Products
{
    public class CreateShopifyProductFromSquareSpace_UseCase
    {
        private readonly ISquareSpaceScrapper _squareSpaceScrapper;
        private readonly IShopifyClient _shopifyClient;

        public CreateShopifyProductFromSquareSpace_UseCase(ISquareSpaceScrapper squareSpaceScrapper, IShopifyClient shopifyClient)
        {
            _squareSpaceScrapper = squareSpaceScrapper;
            _shopifyClient = shopifyClient;
        }

        public async Task<long> HandleAsync(CollectionItem item)
        {
            var itemDetails = _squareSpaceScrapper.GetItemDetails(item.GetAbsoluteURL());

            var product = new Product
            {
                body_html = itemDetails.Description,
                images = itemDetails.ImageUrls.Select(u => new Image
                {
                    src = u,
                }).ToList(),
                image = itemDetails.ImageUrls.Take(1).Select(u => new Image
                {
                    src = u,
                }).First(),
                product_type = "Picture",
                title = itemDetails.Title,
                vendor = "Test",
                variants = new List<Variant>
                        {
                            new Variant
                            {
                                option1 = "",
                                price = itemDetails.Price.Substring(1),
                                sku = ""
                            }
                        }
            };

            var productEntity = await _shopifyClient.CreateProduct(product);

            return productEntity.Id;
        }
    }    
    public class ProductEntity
    {
        public long Id { get; set; }
    }

    public class Product_Root<TProduct>
    {
        public TProduct product { get; set; }
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

    public class CreateCollectionWIthProductsDTO
    {
        public string CollectionName { get; set; }
        public List<CollectionItem> Items { get; set; }
    }
}
