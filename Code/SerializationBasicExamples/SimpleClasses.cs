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

	#region PlainClass

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
		public int Field1 { get; set; }

		public string Field2 { get; set; }

		public TestEnum TestEnumField { get; set; }

		public static PlainClassSerializable CreateExampleData()
		{
			return new PlainClassSerializable()
			{
				Field1 = 42,
				Field2 = "Some string",
				TestEnumField = TestEnum.SomeValue1
			};
		}
	}

	[Serializable]
	[CompactFormatter.Attributes.Serializable]
	[ProtoBuf.ProtoContract]
	public class PlainClassSerializableBackingFields
	{
		public int Field1
		{
			get { return m_Field1; }
			set { m_Field1 = value; }
		}

		public string Field2
		{
			get { return m_Field2; }
			set { m_Field2 = value; }
		}
		
		public TestEnum TestEnumField
		{
			get { return m_TestEnumField; }
			set { m_TestEnumField = value; }
		}

		public static PlainClassSerializableBackingFields CreateExampleData()
		{
			return new PlainClassSerializableBackingFields()
			{
				Field1 = 42,
				Field2 = "Some string",
				TestEnumField = TestEnum.SomeValue1
			};
		}

		private int m_Field1;
		private string m_Field2;
		private TestEnum m_TestEnumField;

	}

	[DataContract]
	public class PlainClassDataContract
	{
		[DataMember]
		public int Field1 { get; set; }

		[DataMember]
		public string Field2 { get; set; }

		[DataMember]
		public TestEnum TestEnumField { get; set; }

		public static PlainClassDataContract CreateExampleData()
		{
			return new PlainClassDataContract()
			{
				Field1 = 42,
				Field2 = "Some string",
				TestEnumField = TestEnum.SomeValue1
			};
		}
	}

	#endregion PlainClass
}
