using ProjectWebsite.Models;
using ProjectWebsite.Services;

namespace ProjectWebsite.Repositories
{
    public class ProductRepository
    {
        public static int NextID = 1;
        public List<Product> ProductList { get; set; }
        private JsonProductService JsonProductService { get; set; }
        public ProductRepository(JsonProductService jsonProductService)
        {
            JsonProductService = jsonProductService;
            ProductList = jsonProductService.GetJsonItems().ToList();
        }

        public int GetNextID()
        {
            int nextID = ProductList.Max(c => c.ID) + 1;
            if (nextID <= NextID) { nextID = NextID + 1; }
            NextID = nextID;
            return nextID;
        }

        public Product GetProduct(int productID)
        {
            //go through entire ProductList
            foreach (Product product in ProductList)
			{
				//look for ID match (ID is unique)
				if (product.ID == productID)
				{
					//return reference to product object
					return product;
				}
			}
			//return null if no match was found
			return null;
        }

        public void CreateProduct(Product productID)
        {
            if (productID == null)
            {
                throw new ArgumentNullException(nameof(productID));
            }
            ProductList.Add(productID);
            JsonProductService.SaveJsonItems(ProductList);
        }

        public bool DeleteProduct(int productID)
        {
            //get reference to that object
            Product productToBeDeleted = GetProduct(productID);
            //temp is null if ID match doesn't exist in the ProductList
            if (productToBeDeleted != null)
            {
                //remove it, should run smoothly
                ProductList.Remove(productToBeDeleted);
                Console.WriteLine(ProductList);
                JsonProductService.SaveJsonItems(ProductList);
                return true;
            }
            return false;
        }

        public void UpdateProduct(Product product)
        {
            foreach (Product p in ProductList)
            {
                if (p.ID == product.ID)
                {
                    p.Name = product.Name;
                    p.Description = p.Description;
                    p.Content = p.Content;
                    p.Type = p.Type;
                    p.Price = product.Price;
                    p.Size = product.Size;

                    JsonProductService.SaveJsonItems(ProductList);
                }
            }
        }

    }
}
