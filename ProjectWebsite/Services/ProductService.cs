using ProjectWebsite.Models;
using ProjectWebsite.Services;
namespace ProjectWebsite.Services

{
    public class ProductService
    {
        private ProductRepository ProductRepository { get; set; }
        public ProductService(ProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        #region Repository method calls
        public Product GetProduct(int productID) { return ProductRepository.GetProduct(productID); }
        public Product CreateProduct(string name, string description, string content, string type, double price)
        {
            return ProductRepository.CreateProduct(name, description, content, type, price);
        }
        public bool DeleteProduct(int productID) { return ProductRepository.DeleteProduct(productID); }
        public List<Product> ProductList { get { return ProductRepository.ProductList; } }
        #endregion

        public IEnumerable<Product> PriceFilter(int maxPrice, int minPrice = 0)
        {
            List<Product> filterList = new();
            foreach (Product product in ProductList)
                if (product.Price >= minPrice && product.Price <= maxPrice)
                    filterList.Add(product);
            return filterList;
        }

        public IEnumerable<Product> NameSearch(string str) //filter
        {
            List<Product> nameSearch = new();
            foreach (Product product in ProductList)
                if (product.Type.ToLower().Contains(str.ToLower()))
                    nameSearch.Add(product);
            return nameSearch;
        }
    }
}
