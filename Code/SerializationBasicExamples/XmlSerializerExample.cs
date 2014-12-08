using System.IO;
using System.Xml.Serialization;

namespace SerializationBasicExamples
{
    public class XmlSerializerExample
    {
		public static void SimpleSerialize()
        {
            var serializer = new XmlSerializer(typeof(PlainClassSerializable));

			var objectToSerialize = PlainClassSerializable.CreateExampleData();

            using(var stream = new MemoryStream())
            {
                serializer.Serialize(stream, objectToSerialize);

                byte[] buffer = stream.ToArray();
            }
        }
    }
}