﻿using System;
using System.Xml.Serialization;

namespace SerializationBasicExamples
{
	[Serializable]
	public class SomeExtraData
	{
		public int Property1 { get; set; }
	}

	[Serializable]
    [CompactFormatter.Attributes.Serializable]
	//[XmlInclude(typeof(SomeExtraData))]
	public class MyChildClass
	{
		public static MyChildClass CreateExampleData()
		{
			return new MyChildClass();
		}

		public object Data { get; set; }
	}
}
