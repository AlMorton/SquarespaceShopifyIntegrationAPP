using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SquarespaceShopifyIntegrationAPP.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;        

        [BindProperty]
        public string ArtistPageURL { get; set; }
       

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("Transferitems", new { url = ArtistPageURL });
        }
    }
}