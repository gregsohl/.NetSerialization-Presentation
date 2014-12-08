using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SerializationBasicExamples
{
    public class XmlSerializerExample
    {
		public static string SimpleSerialize()
        {
            var serializer = new XmlSerializer(typeof(PlainClassSerializable));

			var output = new StringBuilder();

			var objectToSerialize = PlainClassSerializable.CreateExampleData();

			//using(var stream = new MemoryStream())
			//{
			//	serializer.Serialize(stream, objectToSerialize);

			//	byte[] buffer = stream.ToArray();
			//}

            using (var textWriter = new StringWriter(output))
            {
                serializer.Serialize(textWriter, objectToSerialize);
            }

            return output.ToString();
        }

		public static PlainClassSerializable SimpleDeserialize(string serializedData)
		{
			var serializer = new XmlSerializer(typeof (PlainClassSerializable));

			using (var textReader = new StringReader(serializedData))
			{
				object result = serializer.Deserialize(textReader);
				return (PlainClassSerializable)result;
			}
		}
    }
}