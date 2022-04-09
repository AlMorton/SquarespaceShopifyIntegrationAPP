
using Application.Events;
using Application.UseCases;
using Application.UseCases.Products;
using Infrastructure.APIClients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SquarespaceShopifyIntegrationAPP.BackgroundWorker;

namespace SquarespaceShopifyIntegrationAPP.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class TransferitemsModel : PageModel
    {
        private readonly IQueueTask _queueTask;
        private readonly ISqaureSpaceClient _squareSpaceClient;
        public List<CollectionItem> ArtistPictureLinks { get; set; }
        public bool Success = false;
        public string ErrorMessage { get; set; }

        public TransferitemsModel(IQueueTask queueTask, ISqaureSpaceClient sqaureSpaceClient)
        {
            _queueTask = queueTask;
            _squareSpaceClient = sqaureSpaceClient;
            ArtistPictureLinks = new List<CollectionItem>();
        }

        public async Task OnGetAsync(string url)
        {
            try
            {
                ArtistPictureLinks = await _squareSpaceClient.GetCollectionItemsAsync(url);
                Success = true;


            }
            catch (Exception ex)
            {
                ErrorMessage = "Something went wrong: Unable to process Sqaure Space page";
            }
        }

        public async Task<IActionResult> OnPost([FromBody] JsonModel model)
        {           

            foreach (var item in model.Items)
            {
                await _queueTask.QueueEvent(model.ToTransFerEvent());
            }

            return RedirectToPage("/TransferStatus");
        }

        public class JsonModel
        {
            public string CollectionName { get; set; }
            public List<CollectionItem> Items { get; set; }

            public TransferEvent ToTransFerEvent() => new TransferEvent
            {
                CollectionDTO = new CreateCollectionWIthProductsDTO
                {
                    CollectionName = this.CollectionName,
                    Items = this.Items
                }
            };

        }
            
    }


}
