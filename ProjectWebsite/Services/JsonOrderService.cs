﻿using ProjectWebsite.Models;
using System.Text.Json;

namespace ProjectWebsite.Services
{
    public class JsonOrderService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        public JsonOrderService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "order.json"); }
        }
        public void SaveJsonItems(List<Order> orders)
        {
            orders.Sort((x, y) => x.ID.CompareTo(y.ID));
            using (FileStream jsonFileWriter = File.Open(JsonFileName, FileMode.Create))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<Order[]>(jsonWriter, orders.ToArray());
            }
        }
        public IEnumerable<Order> GetJsonItems()
        {
            using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Order[]>(jsonFileReader.ReadToEnd());
            }
        }
    }
}