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

		public static PlainClassSerializableBackingFields SimpleDeserialize(byte[] serializedData)
		{
			var serializer = new BinaryFormatter();

			using(var stream = new MemoryStream(serializedData))
			{
				object result = serializer.Deserialize(stream);
				if (result is PlainClassSerializableBackingFields)
				{
					return (PlainClassSerializableBackingFields) result;
				}

				return null;
			}
		}
    }
}