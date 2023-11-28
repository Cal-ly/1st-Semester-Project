using ProjectWebsite.Models;
using ProjectWebsite.Services;
namespace ProjectWebsite.Services

{
    public class ProductService
    {
        private static List<Product> Products = new List<Product>();
        private JsonProductService JsonProductService { get; set; }
        public ProductService(JsonProductService jsonProductService)
        {
            JsonProductService = jsonProductService;
            Products = JsonProductService.GetJsonItems().ToList();
        }

        public IEnumerable<Product> PriceFilter(int maxPrice, int minPrice = 0)
        {
            List<Product> filterList = new List<Product>();
            foreach (Product product in Products)
            {
                if ((minPrice == 0 && product.Price <= maxPrice) || 
                    (maxPrice == 0 && product.Price >= minPrice) || 
                    (product.Price >= minPrice && product.Price <= maxPrice))
                {
                    filterList.Add(product);
                }
            }

            return filterList;
        }

        public IEnumerable<Product> NameSearch(string str)
        {
            List<Product> nameSearch = new List<Product>();
            foreach (Product product in Products)
            {
                if (product.Type.ToLower().Contains(str.ToLower()))
                {
                    nameSearch.Add(product);
                }
            }

            return nameSearch;
        }
    }
}
