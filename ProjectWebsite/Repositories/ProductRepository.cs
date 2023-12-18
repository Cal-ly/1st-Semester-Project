using ProjectWebsite.Models;
using ProjectWebsite.Services;

namespace ProjectWebsite.Repositories
{
    public class ProductRepository
    {
        private static int nextID = 1;

        public List<Product> ProductList { get; set; }

        private JsonProductService JsonProductService { get; set; }
        public ProductRepository(JsonProductService jsonProductService)
        {
            JsonProductService = jsonProductService;
            ProductList = jsonProductService.GetJsonItems().ToList();
        }

        public int GetNextID() //1. CARSTEN OVERTAGER
        {
            int nextID = ProductList.Where(p => p.Type != "Event").Max(c => c.ID) + 1;
            if (nextID <= ProductRepository.nextID)
            {
                nextID = ProductRepository.nextID + 1;
            }
            ProductRepository.nextID = nextID;
            return nextID; //2. TILBAGE TIL PRODUCT SERVICE
        }
        public void CreateProduct(Product product) //3. FORTÆL OM METODEN
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            ProductList.Add(product);
            JsonProductService.SaveJsonItems(ProductList); //4. VIDERE TIL JSON PRODUCT SERVICE //5. TILBAGE TIL PRODUCT REPOSITORY
        }

        public Product GetProduct(int productID)
        {
            foreach (Product product in ProductList)
            {
                if (product.ID == productID)
                {
                    return product;
                }
            }
            return null;
        }


        public bool DeleteProduct(int productID)
        {
            Product productToBeDeleted = GetProduct(productID);
            if (productToBeDeleted != null)
            {
                ProductList.Remove(productToBeDeleted);
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
