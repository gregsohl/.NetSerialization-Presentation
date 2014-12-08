#region Namespaces

using System;
using System.Collections.Generic;
using System.Text;

#endregion Namespaces

namespace SerializationBasicExamples
{
    class Program
    {
        static void Main(string[] args)
        {
			byte[] bfResult = BinaryFormatterExample.SimpleSerialize();
			string xmlResult = XmlSerializerExample.SimpleSerialize();
			byte[] cfResult = CompactFormatterExample.SimpleSerialize();
			string jsonResult = JsonNetExample.SimpleSerialize();
        }
    }
}
