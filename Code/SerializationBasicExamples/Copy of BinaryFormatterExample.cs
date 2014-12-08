using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Newtonsoft.Json;

namespace SerializationBasicExamples
{
    public class JsonNetExample
    {
		public static void SimpleSerialize()
        {
	        var objectToSerialize = PlainClassSerializableBackingFields.CreateExampleData();

			var settings = new JsonSerializerSettings()
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
				PreserveReferencesHandling = PreserveReferencesHandling.Objects,
			};

			string result = JsonConvert.SerializeObject(objectToSerialize, Formatting.None, settings);

        }
    }
}