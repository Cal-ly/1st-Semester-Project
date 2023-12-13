using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public ProductService ProductService { get; set; }
        public EventService EventService { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ProductService productService, EventService eventService)
        {
            _logger = logger;
            ProductService = productService;
            EventService = eventService;
        }

        public void OnGet()
        {
        }
    }
}