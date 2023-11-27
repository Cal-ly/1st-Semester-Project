using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectWebsite.Pages.Customer
{
    public class DeleteCustomerModel : PageModel
    {
		private PizzaMenuService PizzaService; //Implement interface instead of class?

		[BindProperty]
		public Models.Pizza Pizza { get; set; }
		public List<Models.Pizza>? PizzaMenu { get; private set; }

		public DeletePizzaModel(PizzaMenuService service)
		{
			PizzaService = service;
		}


		public IActionResult OnGet(int number)
		{
			Pizza = PizzaService.GetObject(number);
			if (Pizza == null)
				return RedirectToPage("/Error"); //Define NotFound page
			return Page();
		}

		public IActionResult OnPost()
		{
			Models.Pizza deletedPizza = PizzaService.DeleteObject(Pizza.Number);
			if (deletedPizza == null)
				return RedirectToPage("/Error"); //Define NotFound page

			return RedirectToPage("GetAllItems");
		}
	}
}
