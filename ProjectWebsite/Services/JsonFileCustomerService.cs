using ProjectWebsite.Models;
using System.Text.Json;

namespace ProjectWebsite.Services
{
    public class JsonFileCustomerService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        public JsonFileCustomerService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "customer.json"); }
        }

        public void SaveJsonItems(List<Customer> products)
        {
            using (FileStream jsonFileWriter = File.Create(JsonFileName))
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
