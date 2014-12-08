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
			BinaryFormatterExample.SimpleSerialize();
			XmlSerializerExample.SimpleSerialize();
			CompactFormatterExample.SimpleSerialize();
			ProtocolBuffersExample.SimpleSerialize();
			
        }
    }
}
