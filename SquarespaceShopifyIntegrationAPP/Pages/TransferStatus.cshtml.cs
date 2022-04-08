using Application.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SquarespaceShopifyIntegrationAPP.BackgroundWorker;

namespace SquarespaceShopifyIntegrationAPP.Pages
{
    public class TransferStatusModel : PageModel
    {
        private readonly ITaskViewer _taskViewer;

        public TransferStatusModel(ITaskViewer taskViewer)
        {
            _taskViewer = taskViewer;
        }

        public List<TransferEvent> Events { get; private set; }

        public void OnGet()
        {
            Events = _taskViewer.EventsBeingProccessed;
        }
    }
}
