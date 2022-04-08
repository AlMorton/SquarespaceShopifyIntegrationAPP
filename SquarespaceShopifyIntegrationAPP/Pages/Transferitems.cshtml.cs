using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SquarespaceShopifyIntegrationAPP.BackgroundWorker;
using System.Text.Json;

namespace SquarespaceShopifyIntegrationAPP.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class TransferitemsModel : PageModel
    {
        private readonly IQueueTask queueTask;
        public List<CollectionItem> ArtistPictureLinks { get; set; }

        public TransferitemsModel(IQueueTask queueTask) 
        {
            this.queueTask = queueTask;
            ArtistPictureLinks = new List<CollectionItem>();
        }

        public void OnGet(string url)
        {
            Uri uri = new Uri(Uri.UnescapeDataString(url));
            var web = new HtmlWeb();
            var doc = web.Load(uri);

            ArtistPictureLinks = doc.DocumentNode.SelectNodes("//a")
                .Where(a => a.Attributes.Any(attr => a.HasClass("grid-item")))
                .Where(n => n.ChildNodes.Any(a => a.HasClass("grid-image") && a.ChildNodes.Any(a => a.HasClass("grid-image-inner-wrapper") && a.ChildNodes.Any(a => a.Name == "img"))))
                .Select(n =>
                {

                    var imageUrl = n.ChildNodes.First(a => a.HasClass("grid-image")).ChildNodes.First(a => a.HasClass("grid-image-inner-wrapper"))
                     .ChildNodes.First(a => a.Name == "img").GetAttributeValue("data-src", "");
                    var src = n.GetAttributeValue("href", "");
                    var name = n.ChildNodes.First(a => a.ChildNodes.Any(a => a.HasClass("portfolio-title"))).ChildNodes.First(n => n.Name == "h3").InnerText;

                    return new CollectionItem
                    {
                        HostUrl = uri.Host,
                        ImgSrc = imageUrl,
                        ItemUrl = src,
                        Name = name
                    };
                }).ToList();
        }

        public async Task<IActionResult> OnPost([FromBody] List<CollectionItem> items)
        {
            foreach (var item in items)
            {
                await this.queueTask.QueueEvent(new TransferEvent(item.GetAsJson()));
            }

            return RedirectToPage("/TransferStatus");
        }
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

        public string GetAsJson() => $"https://{HostUrl}{ItemUrl}?format=json-pretty";
    }
}
