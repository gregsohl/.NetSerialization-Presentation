using System;
using NUnit.Framework;
using SerializationBasicExamples.DataClasses;
using SerializationBasicExamples.UnitTestUtility;

namespace SerializationBasicExamples
{
	public class UnitTests
	{
		private VersionedClasses m_CompanyBase;

		#region Public Methods

		[SetUp]
		public void SetUp()
		{
			m_CompanyBase = new VersionedClasses();
		}

		#region Test Methods

		[Test]
		[Category("Serialization")]
		public void BinaryFormatter_Serialize_DeserializeCorrectly()
		{
			// Act
			BinaryFormatterUnitTestUtility.SerializeAndDeserializeComparisonTest(m_CompanyBase);
		}

		[Test]
		[Category("Serialization")]
		public void CompactFormatter_Serialize_DeserializeCorrectly()
		{
			// Act
			CompactFormatterUnitTestUtility.SerializeAndDeserializeComparisonTest(m_CompanyBase);
		}

		[Test]
		[Category("Serialization")]
		public void XmlSerializer_Serialize_DeserializeCorrectly()
		{
			// Act
			XmlSerializerUnitTestUtility.SerializeAndDeserializeComparisonTest(m_CompanyBase);
		}

		#endregion Test Methods

		#endregion Public Methods

	}
}
