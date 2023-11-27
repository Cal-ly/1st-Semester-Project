using ProjectWebsite.Models;

namespace ProjectWebsite.Services
{
    public class ProductRepository
    {
        public List<Product> ProductList { get; set; }
        private static int nextID;

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
            Product newProduct = new() { Name = name, Description = description, Content = content, Price = price };
            ProductList.Add(newProduct);
            return newProduct;
        }

        public bool DeleteProduct(int productID)
        {
            foreach(Product product in ProductList) 
                if(product.ID == productID)
                {
                    ProductList.Remove(product);
                    return true;
                }
            return false;
        }
    }
}
