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
            var settings = new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = false };

			var objectToSerialize = PlainClassSerializable.CreateExampleData();

			//using(var stream = new MemoryStream())
			//{
			//	serializer.Serialize(stream, objectToSerialize);

			//	byte[] buffer = stream.ToArray();
			//}

            using (var xmlWriter = XmlWriter.Create(output, settings))
            {
                serializer.Serialize(xmlWriter, objectToSerialize);
            }

            return output.ToString();
        }
    }
}