using System;
using System.Runtime.Serialization;

namespace SerializationBasicExamples.DataClasses
{
	[Serializable]
	[CompactFormatter.Attributes.Serializable]
	public class PlainClassSerializableBackingFieldsCustom : ISerializable
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

		public PlainClassSerializableBackingFieldsCustom(SerializationInfo info, StreamingContext context)
//			: base(info, context)
		{
			m_Field1 = info.GetInt32("Field1");
			m_Field2 = info.GetString("Field2");
			m_TestEnumField = (TestEnum) info.GetInt32("TestEnumField");
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			// Call the base object's data first.
			//base.SendObjectData(parent, stream);

			info.AddValue("Field1", m_Field1);
			info.AddValue("Field2", m_Field2);
			info.AddValue("TestEnumField", m_TestEnumField);
		}
	}
}
