﻿using ProjectWebsite.Models;
using System.Text.Json;

namespace ProjectWebsite.Services
{
    public class JsonService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        public JsonService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "product.json"); }
        }

        public void SaveJsonItems(List<Product> products)
        {
            using (FileStream jsonFileWriter = File.Create(JsonFileName))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<Product[]>(jsonWriter, products.ToArray());
            }
        }

        public IEnumerable<Product> GetJsonItems()
        {
            using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd());
            }
        }
    }
}
}