using ProjectWebsite.Models;
using ProjectWebsite.Services;

namespace ProjectWebsite.Models
{
    public class ProductRepository
    {
        public List<Product> ProductList { get; set; }
        private static int nextID;
        private JsonProductService JsonProductService { get; set; }

        public ProductRepository(JsonProductService jsonProductService)
        {
            JsonProductService = jsonProductService;
            ProductList = jsonProductService.GetJsonItems().ToList();
        }

        public Product GetProduct(int productID)
        {
            //go through entire ProductList
            foreach (Product product in ProductList)
                //look for ID match (ID is unique)
                if (product.ID == productID)
                    //return reference to product object
                    return product;
            //return null if no match was found
            return null;
        }

        public Product CreateProduct(string name, string description, string content, double price)
        {
            //create new product object
            Product newProduct = new() { Name = name, Description = description, Content = content, Price = price };
            //add reference to that product object to ProductList
            ProductList.Add(newProduct);
            JsonProductService.SaveJsonItems(ProductList);
            //return reference to newProduct
            return newProduct;
        }

        public bool DeleteProduct(int productID)
        {
            //get reference to that object
            Product productToBeDeleted = GetProduct(productID);
            //temp is null if ID match doesn't exist in the ProductList
            if(productToBeDeleted != null)
            {
                //remove it, should run smoothly
                ProductList.Remove(productToBeDeleted);
                ProductList.Remove(temp);
                JsonProductService.SaveJsonItems(ProductList);
                return true;
            }
            return false;
        }
    }
}
