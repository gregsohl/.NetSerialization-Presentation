using System;
using System.Runtime.Serialization;

namespace SerializationBasicExamples
{
	public enum TestEnum
	{
		SomeValue0 = 0,
		SomeValue1 = 1,
		SomeValue2 = 2,
	}

	public class PlainClassUnattributed
	{
		public int Field1 { get; set; }

		public string Field2 { get; set; }

		public TestEnum TestEnumField { get; set; }

		public static PlainClassUnattributed CreateExampleData()
		{
			return new PlainClassUnattributed()
			{
				Field1 = 42,
				Field2 = "Some string",
				TestEnumField = TestEnum.SomeValue1
			};
		}
	}

	[Serializable]
    [CompactFormatter.Attributes.Serializable]
	public class PlainClassSerializable
	{
		public int Property1 { get; set; }

		public string Property2 { get; set; }

		public TestEnum PropertyEnum1 { get; set; }

		public static PlainClassSerializable CreateExampleData()
		{
			return new PlainClassSerializable()
			{
				Property1 = 42,
				Property2 = "Some string",
				PropertyEnum1 = TestEnum.SomeValue1
			};
		}
	}

	[Serializable]
	[CompactFormatter.Attributes.Serializable]
	public class PlainClassSerializableBackingFields
	{
		public int Property1
		{
			get { return m_Field1; }
			set { m_Field1 = value; }
		}

		public string Property2
		{
			get { return m_Field2; }
			set { m_Field2 = value; }
		}
		
		public TestEnum PropertyEnum1
		{
			get { return m_TestEnumField; }
			set { m_TestEnumField = value; }
		}

		public static PlainClassSerializableBackingFields CreateExampleData()
		{
			return new PlainClassSerializableBackingFields()
			{
				Property1 = 42,
				Property2 = "Some string",
				PropertyEnum1 = TestEnum.SomeValue1
			};
		}

		private int m_Field1;
		private string m_Field2;
		private TestEnum m_TestEnumField;

	}
}
