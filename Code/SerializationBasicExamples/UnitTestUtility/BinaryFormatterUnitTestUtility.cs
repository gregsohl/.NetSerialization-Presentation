#region Namespaces

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

#endregion Namespaces

namespace SerializationBasicExamples.UnitTestUtility
{
	/// <summary>
	/// Contains utility methods for testing BinaryFormatter operations.
	/// </summary>
	public static class BinaryFormatterUnitTestUtility
	{
		#region Public Methods

		/// <summary>
		/// Serializes the specified object using the BinaryFormatter.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="objectToSerialize">The object to serialize.</param>
		public static T SerializeAndDeserialize<T>(T objectToSerialize) where T : class
		{
			BinaryFormatter serializer = new BinaryFormatter();
			MemoryStream stream = new MemoryStream();
			serializer.Serialize(stream, objectToSerialize);
			byte[] buffer = stream.ToArray();
			stream.Close();

			// Deserialize the element.
			stream = new MemoryStream(buffer);
			T deserializedObject = serializer.Deserialize(stream) as T;

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