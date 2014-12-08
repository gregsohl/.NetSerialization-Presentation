#region Namespaces

using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

#endregion Namespaces

namespace SerializationBasicExamples
{
	[Serializable]
	public class SerializationAttributesClassSerializable
	{
		public int Property1 { get; set; }

		public int Property2 { get; set; }

		public int Property3 { get; set; }

		[NonSerialized]
		public int Field1;

		[NonSerialized]
		public bool Saved = false;

		public int Property4 { get; set; }

		[OnSerializing]
		private void OnSerializing(StreamingContext context)
		{
			Property1 = 41;
		}

		[OnSerialized]
		private void OnSerialized(StreamingContext context)
		{
			Property2 = 42;
			Saved = true;
		}

		[OnDeserializing]
		private void OnDeserializing(StreamingContext context)
		{
			Property3 = 43;
			Field1 = 44;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			Property4 = 45;
		}
	}
}
