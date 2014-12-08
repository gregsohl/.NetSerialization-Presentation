﻿using System.IO;

namespace SerializationBasicExamples
{
    public class CompactFormatterExample
    {
		public static void SimpleSerialize()
        {
            var serializer = new CompactFormatterEx();

	        var objectToSerialize = PlainClassSerializableBackingFields.CreateExampleData();

            using(var stream = new MemoryStream())
            {
                serializer.Serialize(stream, objectToSerialize);

                byte[] buffer = stream.ToArray();
            }
        }
    }
}