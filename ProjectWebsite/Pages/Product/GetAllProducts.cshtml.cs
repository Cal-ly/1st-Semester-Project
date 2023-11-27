using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectWebsite.Services;

namespace ProjectWebsite.Pages.Product
{
    public class GetAllProductsModel : PageModel
    {
        public List<Models.Product> Products { get; private set; } = new List<Models.Product>();
        private JsonService _jsonService;

        public GetAllProductsModel(JsonService jsonService)
        {
            _jsonService = jsonService;
        }

        public void OnGet()
        {
            Products = _jsonService.GetJsonItems().ToList();
        }
    }
}
