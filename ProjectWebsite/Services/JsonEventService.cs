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

		public void SaveJsonItems(List<Event> events)
		{
			string tempFileName = JsonFileName + ".tmp";
			using (FileStream jsonFileWriter = File.Open(tempFileName, FileMode.OpenOrCreate))
			{
				Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
				{
					SkipValidation = false,
					Indented = true
				});
				JsonSerializer.Serialize<Event[]>(jsonWriter, events.ToArray());
			}
			if (File.Exists(JsonFileName))
			{
				// Load existing events
				var existingEvents = GetJsonItems();
				// Merge existing events with new events
				var mergedEvents = existingEvents.Union(events);
				// Write merged events to file
				File.WriteAllText(JsonFileName, JsonSerializer.Serialize(mergedEvents));
			}
			else
			{
				File.Move(tempFileName, JsonFileName);
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
