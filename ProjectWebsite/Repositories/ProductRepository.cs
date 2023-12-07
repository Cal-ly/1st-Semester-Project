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
            if (nextID <= NextID) 
            { 
                nextID = NextID + 1; 
            }
            NextID = nextID;
            return nextID;
        }

        public Product GetProduct(int productID)
        {
            Console.WriteLine(productID);
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
            //Foreach loop der looper alle produkter (p) i ProductList igennem.
            foreach (Product p in ProductList)
            {
                //If statement der tjekker om p er identisk med det produkt vi forsøger at opdatere. 
                if (p.ID == product.ID)
                {
                    //Når den finder det produkt (p) i ProductList der er identisk med et produkt vi vil opdatere,
                    //sætter den produktets oplysninger til de oplysninger vi har skrevet i UpdateProduct formen på UpdateProduct siden. 
                    p.Name = product.Name;
                    p.Description = p.Description;
                    p.Content = p.Content;
                    p.Type = p.Type;
                    p.Price = product.Price;
                    p.Size = product.Size;

                    //Til sidst gemmer vi de opdaterede oplysninger i vores Json-fil,
                    //ved hjælp af vores SaveJsonItems funktion i vores JsonProductService.
                    JsonProductService.SaveJsonItems(ProductList);
                }
            }
        }
    }
}
