using ProjectWebsite.Models;
using System.Text.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ProjectWebsite.Services
{
	public class JsonEventService
	{
		public IWebHostEnvironment WebHostEnvironment { get; }
		public JsonEventService(IWebHostEnvironment webHostEnvironment)
		{
			WebHostEnvironment = webHostEnvironment;
		}
		private string JsonFileName
		{
			get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "event.json"); }
		}

        public void SaveJsonItems(List<Event> items)
        {
            using (FileStream jsonFileWriter = File.Create(JsonFileName))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<Event[]>(jsonWriter, items.ToArray());
            }
        }

        public IEnumerable<Event> GetJsonItems()
        {
            using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Event[]>(jsonFileReader.ReadToEnd());
            }
        }
    }
}
