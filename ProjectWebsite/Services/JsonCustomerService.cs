using ProjectWebsite.Models;
using System.Text.Json;

namespace ProjectWebsite.Services
{
    //Denne klasse er en service, der håndterer JSON-filen med kunder.
    public class JsonCustomerService
    {
        //Denne property indeholder stien til JSON-filen.
        public IWebHostEnvironment WebHostEnvironment { get; }
        //Denne constructor sætter WebHostEnvironment til at være den indkommende IWebHostEnvironment.
        public JsonCustomerService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        //Denne property indeholder stien til JSON-filen.
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "customer.json"); }
        }
        //Denne metode gemmer listen af kunder i JSON-filen.
        public void SaveJsonItems(List<Customer> customers)
        {
            //Sorterer listen af kunder efter ID, så den er i den rigtige rækkefølge.
            customers.Sort((x, y) => x.ID.CompareTo(y.ID));
            //Åbner JSON-filen.
            using (FileStream jsonFileWriter = File.Open(JsonFileName, FileMode.Create))
            {
                //Sætter jsonWriter til at være en ny Utf8JsonWriter, der skriver til jsonFileWriter.
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    //Sætter SkipValidation til false, så der kastes en exception, hvis der er en property, der ikke kan serialiseres.
                    SkipValidation = false,
                    //Sætter Indented til true, så JSON-filen bliver gemt med indryk.
                    Indented = true
                });
                //Skriver listen af kunder til JSON-filen.
                JsonSerializer.Serialize<Customer[]>(jsonWriter, customers.ToArray());
            }
        }
        //Denne metode henter listen af kunder fra JSON-filen.
        public IEnumerable<Customer> GetJsonItems()
        {
            //Åbner JSON-filen.
            using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
            {
                //Returnerer listen af kunder, der er deserialiseret fra JSON-filen.
                return JsonSerializer.Deserialize<Customer[]>(jsonFileReader.ReadToEnd());
            }
        }
    }
}