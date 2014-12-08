using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationBasicExamples
{
    public class BinaryFormatterExample
    {
		public static byte[] SimpleSerialize()
        {
            var serializer = new BinaryFormatter();

	        var objectToSerialize = PlainClassSerializableBackingFields.CreateExampleData();

            using(var stream = new MemoryStream())
            {
                serializer.Serialize(stream, objectToSerialize);

                byte[] buffer = stream.ToArray();

	            return buffer;
            }
        }
    }
}