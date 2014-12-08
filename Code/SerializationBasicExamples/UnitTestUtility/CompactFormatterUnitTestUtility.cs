#region Namespaces

using System;
using System.IO;

#endregion Namespaces

namespace SerializationBasicExamples.UnitTestUtility
{
	/// <summary>
	/// Provides utilities for common CompactFormatter tests.
	/// </summary>
	public static class CompactFormatterUnitTestUtility
	{
		/// <summary>
		/// Serializes the specified object to a memory stream, deserialize back to
		/// the original type, returning what should be a copy of the orginal.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="objectToSerialize">The object to serialize.</param>
		public static T SerializeAndDeserialize<T>(T objectToSerialize) where T : class
		{
			// Try to serialize the object.
			var compactFormatter = new CompactFormatterEx();
			var stream = new MemoryStream();
			compactFormatter.Serialize(stream, objectToSerialize);
			byte[] buffer = stream.ToArray();
			stream.Close();

			// Deserialize the element.
			stream = new MemoryStream(buffer);
			T deserializedObject = compactFormatter.Deserialize(stream) as T;

			// Make sure it isn't null.
			if (deserializedObject == null)
			{
				throw new Exception("Got a null value from the deserialization");
			}

			return deserializedObject;
		}

		/// <summary>
		/// Serialize and deserialize the object followed by a compare.
		/// </summary>
		/// <typeparam name="T">Object type</typeparam>
		/// <param name="objectToSerialize">Object to test</param>
		/// <param name="elementsToIgnore">Elements to ignore when comparing</param>
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
	}
}