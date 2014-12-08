#region Namespaces

using System;
using System.Collections.Generic;
using System.Text;
using SerializationBasicExamples.DataClasses;

#endregion Namespaces

namespace SerializationBasicExamples
{
    class Program
    {
        static void Main(string[] args)
        {
	        #region Simple Serialize

	        byte[] bfResult = BinaryFormatterExample.SimpleSerialize();
	        string xmlResult = XmlSerializerExample.SimpleSerialize();
	        byte[] cfResult = CompactFormatterExample.SimpleSerialize();
	        string jsonResult = JsonNetExample.SimpleSerialize();

	        #endregion Simple Serialize

	        #region Simple Deserialize

	        var bfDeserialized = BinaryFormatterExample.SimpleDeserialize(bfResult);
	        var xmlDeserialized = XmlSerializerExample.SimpleDeserialize(xmlResult);
	        var cfDeserialized = CompactFormatterExample.SimpleDeserialize(cfResult);
	        var jsonDeserialized = JsonNetExample.SimpleDeserialize(jsonResult);

	        #endregion Simple Deserialize

	        #region Xml Serialization with Extra Types

			//xmlResult = XmlSerializerExample.SerializeWithExtraTypes();
			//XmlSerializerExample.SimpleDeserializeWithExtraTypes(xmlResult);
			//Console.WriteLine(xmlResult);

	        #endregion Xml Serialization with Extra Types

	        bfResult = BinaryFormatterExample.CustomSerialize();
	        var plainClassSerializableBackingFieldsCustom = BinaryFormatterExample.CustomDeserialize(bfResult);

	        xmlResult = XmlSerializerExample.CustomSerialize();
	        var classSerializableBackingFieldsCustom = XmlSerializerExample.CustomDeserialize(xmlResult);

	        Console.ReadLine();
        }
    }
}
