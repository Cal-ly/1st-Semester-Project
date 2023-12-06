using ProjectWebsite.Models;
using System.Text.Json;

namespace ProjectWebsite.Services
{
    public class JsonCustomerService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        public JsonCustomerService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "customer.json"); }
        }

        public void SaveJsonItems(List<Customer> products)
        {
            using (FileStream jsonFileWriter = File.Open(JsonFileName, FileMode.Create))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<Customer[]>(jsonWriter, products.ToArray());
            }
        }

        public IEnumerable<Customer> GetJsonItems()
        {
            using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Customer[]>(jsonFileReader.ReadToEnd());
            }
        }
    }
}