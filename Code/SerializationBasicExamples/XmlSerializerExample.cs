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

	    public static string SerializeWithExtraTypes()
	    {
			var serializer = new XmlSerializer(typeof(MyChildClass));

			var output = new StringBuilder();

			var objectToSerialize = MyChildClass.CreateExampleData();
		    var someExtraData = new SomeExtraData() {Property1 = 5};
		    objectToSerialize.Data = someExtraData;

		    using (var textWriter = new StringWriter(output))
			{
				serializer.Serialize(textWriter, objectToSerialize);
			}

			return output.ToString();
		}

	    public static MyChildClass SimpleDeserializeWithExtraTypes(string serializedData)
	    {
			var serializer = new XmlSerializer(typeof(MyChildClass));

			using (var textReader = new StringReader(serializedData))
			{
				object result = serializer.Deserialize(textReader);
				return (MyChildClass)result;
			}
		}
    }
}