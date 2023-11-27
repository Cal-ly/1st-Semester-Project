using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectWebsite.Pages.Product
{
    public class GetAllProductsModel : PageModel
    {
        public List<Models.Product> Products { get; private set; } = new List<Models.Product>();

        public void OnGet()
        {
            Products = _itemService.GetItems();
        }
    }
}
