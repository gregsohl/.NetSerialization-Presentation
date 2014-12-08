using System.IO;
using ProtoBuf;

namespace SerializationBasicExamples
{
    public class ProtocolBuffersExample
    {
        public static void SimpleSerialize()
        {
	        var objectToSerialize = PlainClassSerializableBackingFields.CreateExampleData();

            using(var stream = new MemoryStream())
            {
				Serializer.Serialize(stream, objectToSerialize);

				byte[] buffer = stream.ToArray();
            }
        }
    }
}