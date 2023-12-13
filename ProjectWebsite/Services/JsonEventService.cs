using ProjectWebsite.Models;
using System.Collections.Generic;
using System.Text.Json;

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
        public void SaveJsonItems(List<Event> events)
        {
            events.Sort((x, y) => x.ID.CompareTo(y.ID));
            using (FileStream jsonFileWriter = File.Open(JsonFileName, FileMode.Create))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<Event[]>(jsonWriter, events.ToArray());
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