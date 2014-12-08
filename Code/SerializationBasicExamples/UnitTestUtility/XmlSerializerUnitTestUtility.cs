#region Namespaces

using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

#endregion Namespaces

namespace SerializationBasicExamples.UnitTestUtility
{
	/// <summary>
	/// Contains utility methods for testing XmlSerializer operations.
	/// </summary>
	public static class XmlSerializerUnitTestUtility
	{
		#region Public Methods

		/// <summary>
		/// Serializes the specified object using the NetDataContractSerializer.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="objectToSerialize">The object to serialize.</param>
		public static T SerializeAndDeserialize<T>(T objectToSerialize) where T : class
		{
			// Serialize the object via XML.
			XmlSerializer serializer = new XmlSerializer(typeof (T));
			StringBuilder stringBuilder = new StringBuilder();
			XmlWriter writer = XmlWriter.Create(stringBuilder);
			serializer.Serialize(writer, objectToSerialize);

			// Deserialize the element.
			StringReader stringReader = new StringReader(stringBuilder.ToString());
			XmlReader reader = XmlReader.Create(stringReader);
			T deserializedObject = serializer.Deserialize(reader) as T;

			// Make sure it isn't null.
			if (deserializedObject == null)
			{
				throw new Exception("Got a null value from the deserialization");
			}

			return deserializedObject;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="objectToSerialize"></param>
		/// <param name="elementsToIgnore"></param>
		public static void SerializeAndDeserializeComparisonTest<T>(T objectToSerialize, params string[] elementsToIgnore)
			where T : class
		{
			CompareObjectsUnitTestUtility.CompareObjects(
				objectToSerialize,
				SerializeAndDeserialize(objectToSerialize),
				true,
				true,
				true,
				true,
				true,
				true,
				elementsToIgnore);
		}

		#endregion Public Methods
	}
}