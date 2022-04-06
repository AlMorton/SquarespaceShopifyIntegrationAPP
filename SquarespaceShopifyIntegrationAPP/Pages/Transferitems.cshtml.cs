using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SquarespaceShopifyIntegrationAPP.Pages
{
    public class TransferitemsModel : PageModel
    {
        public IEnumerable<string> ArtistPictureLinks { get; private set; }
        public void OnGet(string url)
        {
            ArtistPictureLinks = new List<string>();

            url = Uri.UnescapeDataString(url);

            var web = new HtmlWeb();
            var doc = web.Load(url);

            ArtistPictureLinks = doc.DocumentNode.SelectNodes("//a")
            .Where(a => a.Attributes.Any(attr => a.HasClass("grid-item")
            ))
            .SelectMany(a => a.ChildNodes.SelectMany(c => c.ChildNodes.Where(a => a.HasClass("grid-image-inner-wrapper"))
            .SelectMany(a => a.ChildNodes.Where(a => a.Name == "img").Select(imgNode =>
            {
                var src = imgNode.GetAttributeValue("data-src", "");
                imgNode.Attributes.Add("src", src);
                return imgNode;
            }))))
            .Select(pl => pl.ParentNode.ParentNode.ParentNode.OuterHtml);
        }
    }
}
