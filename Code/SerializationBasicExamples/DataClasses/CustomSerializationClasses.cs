using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

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

		public static PlainClassSerializableBackingFieldsCustom CreateExampleData()
		{
			return new PlainClassSerializableBackingFieldsCustom()
			{
				Property1 = 42,
				Property2 = "Some string",
				PropertyEnum1 = TestEnum.SomeValue1
			};
		}

		private int m_Field1;
		private string m_Field2;
		private TestEnum m_TestEnumField;

		public PlainClassSerializableBackingFieldsCustom()
		{
		}

		public PlainClassSerializableBackingFieldsCustom(SerializationInfo info, StreamingContext context)
//			: base(info, context)
		{
			m_Field1 = info.GetInt32("Field1");
			m_Field2 = info.GetString("Field2");
			m_TestEnumField = (TestEnum) info.GetInt32("TestEnumField");
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			// Call the base object's data first.
			//base.SendObjectData(parent, stream);

			info.AddValue("Field1", m_Field1);
			info.AddValue("Field2", m_Field2);
			info.AddValue("TestEnumField", m_TestEnumField);
		}
	}

	[Serializable]
	[CompactFormatter.Attributes.Serializable]
	public class PlainClassSerializableBackingFieldsCustomXml : IXmlSerializable
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

		public static PlainClassSerializableBackingFieldsCustomXml CreateExampleData()
		{
			return new PlainClassSerializableBackingFieldsCustomXml()
			{
				Property1 = 42,
				Property2 = "Some string",
				PropertyEnum1 = TestEnum.SomeValue1
			};
		}

		private int m_Field1;
		private string m_Field2;
		private TestEnum m_TestEnumField;

		public PlainClassSerializableBackingFieldsCustomXml()
		{
		}

		public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
			reader.ReadToFollowing("Field1");
			m_Field1 = Int32.Parse(reader.ReadElementString("Field1"));
			m_Field2 = reader.ReadElementString("Field2");
			m_TestEnumField = (TestEnum) Int32.Parse(reader.ReadElementString("TestEnumField"));
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteElementString("Field1", m_Field1.ToString(CultureInfo.InvariantCulture));
			writer.WriteElementString("Field2", m_Field2);
			writer.WriteElementString("TestEnumField", ((Int32)m_TestEnumField).ToString(CultureInfo.InvariantCulture));
		}
	}
}
