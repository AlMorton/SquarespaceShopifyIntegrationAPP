using Application.Interfaces;
using Application.UseCases;
using Application.UseCases.Products;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace Infrastructure.Webscrappers
{
    public class SquareSpaceScrapper : ISquareSpaceScrapper
    {
        public List<CollectionItem> GetArtistCollectionItems(string url)
        {
            Uri uri = new Uri(Uri.UnescapeDataString(url));
            var web = new HtmlWeb();
            var doc = web.Load(uri);

            var collection = doc.DocumentNode.SelectNodes("//a")
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

            return collection;
        }

        public ItemDTO GetItemDetails(string url)
        {
            var uri = new Uri(url);
            var web = new HtmlWeb();
            HtmlDocument doc = web.Load(uri);

            var images = doc.DocumentNode.SelectNodes("//img[@class='thumb-image']").Select(a => a.GetAttributeValue("data-src", "")).ToArray();

            var descriptionNode = doc.DocumentNode.SelectNodes("//div[@class='sqs-block-content']").First(a => a.ChildNodes.Any(a => a.Name.Contains("h")));

            var priveRegEx = new Regex(@"\¥\d.+\d.+\d");

            var price = priveRegEx.Match(descriptionNode.InnerText);

            var item = new ItemDTO
            {
                Description = descriptionNode.InnerHtml,
                Price = price.Value,
                ImageUrls = images,
                Title = descriptionNode.ChildNodes.First(a => a.Name.Contains("h")).InnerText
            };

            return item;
        }
    }

}
