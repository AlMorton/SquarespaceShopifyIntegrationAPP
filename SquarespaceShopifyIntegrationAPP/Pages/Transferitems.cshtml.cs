
using Application.Events;
using Application.Interfaces;
using Application.UseCases;
using Infrastructure.Webscrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SquarespaceShopifyIntegrationAPP.BackgroundWorker;
using System.Text.Json;

namespace SquarespaceShopifyIntegrationAPP.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class TransferitemsModel : PageModel
    {
        private readonly IQueueTask _queueTask;
        private readonly ISquareSpaceScrapper _squareSpaceScrapper;
        public List<CollectionItem> ArtistPictureLinks { get; set; }

        public TransferitemsModel(IQueueTask queueTask, ISquareSpaceScrapper squareSpaceScrapper) 
        {
            _queueTask = queueTask;
            _squareSpaceScrapper = squareSpaceScrapper; 
            ArtistPictureLinks = new List<CollectionItem>();
        }

        public void OnGet(string url)
        {
            ArtistPictureLinks = _squareSpaceScrapper.GetArtistCollectionItems(url);
        }

        public async Task<IActionResult> OnPost([FromBody] List<CollectionItem> items)
        {
            foreach (var item in items)
            {
                await _queueTask.QueueEvent(new TransferEvent(item.GetAbsoluteURL()));
            }

            return RedirectToPage("/TransferStatus");
        }
    }

    
}
