using ProjectWebsite.Models;
using ProjectWebsite.Repositories;

namespace ProjectWebsite.Services
{
    public class ProductService
    {
        public List<Product> ProductList { get { return ProductRepository.ProductList; } }
        private ProductRepository ProductRepository { get; set; }
        public ProductService(ProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        #region Repository method calls
        public int GetNextID() { return ProductRepository.GetNextID(); }
        public Product GetProduct(int productID) { return ProductRepository.GetProduct(productID); }
        public void CreateProduct(Product product) { ProductRepository.CreateProduct(product); }
        public bool DeleteProduct(int productID) { return ProductRepository.DeleteProduct(productID); }
        public void UpdateProduct(Product productID) { ProductRepository.UpdateProduct(productID); }
        #endregion

        public IEnumerable<Product> PriceFilter(int maxPrice, int minPrice)
        {
            List<Product> filterList = new();
            foreach (Product product in ProductList)
                if (product.Price >= minPrice && product.Price <= maxPrice)
                    filterList.Add(product);
            return filterList;
        }

        public IEnumerable<Product> NameSearch(string inputString) //filter
        {
            List<Product> nameSearch = new();
            foreach (Product product in ProductList)
            {
                if (product.Type.ToLower().Contains(inputString.ToLower()))
                {
                    nameSearch.Add(product);
                }
            }
            return nameSearch;
        }
    }
}
