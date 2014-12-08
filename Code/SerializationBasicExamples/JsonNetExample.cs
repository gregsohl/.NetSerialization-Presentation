using Newtonsoft.Json;

namespace SerializationBasicExamples
{
    public class JsonNetExample
    {
		public static string SimpleSerialize()
        {
	        var objectToSerialize = PlainClassSerializableBackingFields.CreateExampleData();

			var settings = new JsonSerializerSettings()
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
				PreserveReferencesHandling = PreserveReferencesHandling.Objects,
			};

			string result = JsonConvert.SerializeObject(objectToSerialize, Formatting.None, settings);

			return result;
        }
    }
}