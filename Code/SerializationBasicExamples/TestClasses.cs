#region Namespaces

using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

#endregion Namespaces

namespace SerializationBasicExamples
{
	[Serializable]
	public class NonSerializedClass
	{
		public int Field1 { get; set; }

		[NonSerialized]
		public int Field2;
	}

	[DataContract]
	public class DataContractClass
	{
		[DataMember]
		public int Field1 { get; set; }

		public string Field2 { get; set; }
	}




	#region SerializationAttributesClass

	public class SerializationAttributesClassUnattributed
	{
		public static int Field1 { get; set; }

		public static int Field2 { get; set; }

		public static int Field3 { get; set; }

		public static int Field4 { get; set; }

		[OnSerializing]
		private void OnSerializing(StreamingContext context)
		{
			Field1 = 41;
		}

		[OnSerialized]
		private void OnSerialized(StreamingContext context)
		{
			Field2 = 42;
		}

		[OnDeserializing]
		private void OnDeserializing(StreamingContext context)
		{
			Field3 = 43;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			Field4 = 44;
		}
	}

	[Serializable]
	public class SerializationAttributesClassSerializable
	{
		public int Field1 { get; set; }

		public int Field2 { get; set; }

		public int Field3 { get; set; }

		[NonSerialized]
		public int Field4;

		public int Field5 { get; set; }

		[OnSerializing]
		private void OnSerializing(StreamingContext context)
		{
			this.Field1 = 41;
		}

		[OnSerialized]
		private void OnSerialized(StreamingContext context)
		{
			this.Field2 = 42;
		}

		[OnDeserializing]
		private void OnDeserializing(StreamingContext context)
		{
			this.Field3 = 43;
			this.Field4 = 44;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			this.Field5 = 45;
		}
	}

	[DataContract]
	public class SerializationAttributesClassDataContract
	{
		[DataMember]
		public int Field1 { get; set; }

		[DataMember]
		public int Field2 { get; set; }

		[DataMember]
		public int Field3 { get; set; }

		public int Field4;

		[DataMember]
		public int Field5 { get; set; }

		[OnSerializing]
		private void OnSerializing(StreamingContext context)
		{
			this.Field1 = 41;
		}

		[OnSerialized]
		private void OnSerialized(StreamingContext context)
		{
			this.Field2 = 42;
		}

		[OnDeserializing]
		private void OnDeserializing(StreamingContext context)
		{
			this.Field3 = 43;
			this.Field4 = 44;
		}

		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			this.Field5 = 45;
		}
	}

	#endregion SerializationAttributesClass



	#region ClassWithoutParameterLessConstructor

	public class ClassWithoutParameterLessConstructorUnattributed
	{
		public int Field1 { get; set; }

		public ClassWithoutParameterLessConstructorUnattributed(int field1)
		{
			this.Field1 = field1;
		}
	}

	[Serializable]
	public class ClassWithoutParameterLessConstructorSerializable
	{
		public int Field1 { get; set; }

		public ClassWithoutParameterLessConstructorSerializable(int field1)
		{
			this.Field1 = field1;
		}
	}

	[DataContract]
	public class ClassWithoutParameterLessConstructorDataContract
	{
		[DataMember]
		public int Field1 { get; set; }

		public ClassWithoutParameterLessConstructorDataContract(int field1)
		{
			this.Field1 = field1;
		}
	}

	#endregion ClassWithoutParameterLessConstructor



	#region ClassWithPrivateConstructor

	public class ClassWithPrivateConstructorUnattributed
	{
		public int Field1 { get; set; }

		private ClassWithPrivateConstructorUnattributed(int field1)
		{
			this.Field1 = field1;
		}

		public static ClassWithPrivateConstructorUnattributed Create(int field1)
		{
			return new ClassWithPrivateConstructorUnattributed(field1);
		}
	}

	[Serializable]
	public class ClassWithPrivateConstructorSerializable
	{
		public int Field1 { get; set; }

		private ClassWithPrivateConstructorSerializable(int field1)
		{
			this.Field1 = field1;
		}

		public static ClassWithPrivateConstructorSerializable Create(int field1)
		{
			return new ClassWithPrivateConstructorSerializable(field1);
		}
	}

	[DataContract]
	public class ClassWithPrivateConstructorDataContract
	{
		[DataMember]
		public int Field1 { get; set; }

		private ClassWithPrivateConstructorDataContract(int field1)
		{
			this.Field1 = field1;
		}

		public static ClassWithPrivateConstructorDataContract Create(int field1)
		{
			return new ClassWithPrivateConstructorDataContract(field1);
		}
	}

	#endregion ClassWithoutParameterLessConstructor



	#region ClassWithStaticField

	public class ClassWithStaticFieldUnattributed
	{
		public static int StaticField;
	}

	[Serializable]
	public class ClassWithStaticFieldSerializable
	{
		public static int StaticField;
	}

	[DataContract]
	public class ClassWithStaticFieldDataContract
	{
		[DataMember]
		public static int StaticField;
	}

	#endregion ClassWithStaticField



	#region ClassWithParameterLessConstructor

	public class ClassWithParameterLessConstructorUnattributed
	{
		public static int StaticField;

		public ClassWithParameterLessConstructorUnattributed()
		{
			StaticField = 41;
		}
	}

	[Serializable]
	public class ClassWithParameterLessConstructorSerializable
	{
		public static int StaticField;

		public ClassWithParameterLessConstructorSerializable()
		{
			StaticField = 42;
		}
	}

	[DataContract]
	public class ClassWithParameterLessConstructorDataContract
	{
		public static int StaticField;

		public ClassWithParameterLessConstructorDataContract()
		{
			StaticField = 43;
		}
	}

	#endregion ClassWithParameterLessConstructor



	#region ClassWithAccessors

	public class ClassWithAccessorsUnattributed
	{
		public static int StaticField1;

		public static int StaticField2;

		public int Field1
		{
			get
			{
				StaticField1++;
				return this.m_backingField;
			}

			set
			{
				StaticField2++;
				this.m_backingField = value;
			}
		}

		private int m_backingField;
	}

	[Serializable]
	public class ClassWithAccessorsSerializable
	{
		public static int StaticField1;

		public static int StaticField2;

		public int Field1
		{
			get
			{
				StaticField1++;
				return this.m_backingField;
			}

			set
			{
				StaticField2++;
				this.m_backingField = value;
			}
		}

		[NonSerialized]
		private int m_backingField;
	}

	[DataContract]
	public class ClassWithAccessorsDataContract
	{
		public static int StaticField1;

		public static int StaticField2;

		[DataMember]
		public int Field1
		{
			get
			{
				StaticField1++;
				return this.m_backingField;
			}

			set
			{
				StaticField2++;
				this.m_backingField = value;
			}
		}

		private int m_backingField;
	}

	#endregion ClassWithAccessors



	#region ClassWithPrivateSetter

	public class ClassWithPrivateSetterUnattributed
	{
		public static int StaticField1;

		public int Field1
		{
			get
			{
				return this.m_backingField;
			}

			private set
			{
				StaticField1++;
				this.m_backingField = value;
			}
		}

		public void SetBackingField(int value)
		{
			this.m_backingField = value;
		}

		private int m_backingField;
	}

	[Serializable]
	public class ClassWithPrivateSetterSerializable
	{
		public static int StaticField1;

		public int Field1
		{
			get
			{
				return this.m_backingField;
			}

			private set
			{
				StaticField1++;
				this.m_backingField = value;
			}
		}

		public void SetBackingField(int value)
		{
			this.m_backingField = value;
		}

		[NonSerialized]
		private int m_backingField;
	}

	[DataContract]
	public class ClassWithPrivateSetterDataContract
	{
		public static int StaticField1;

		[DataMember]
		public int Field1
		{
			get
			{
				return this.m_backingField;
			}

			private set
			{
				
				StaticField1++;
				this.m_backingField = value;
			}
		}

		public void SetBackingField(int value)
		{
			this.m_backingField = value;
		}

		private int m_backingField;
	}

	#endregion ClassWithPrivateSetter



	#region ClassWithPrivateField

	public class ClassWithPrivateFieldUnattributed
	{
		private int m_field1;

		public void SetField1(int value)
		{
			this.m_field1 = value;
		}

		public int GetField1()
		{
			return this.m_field1;
		}
	}

	[Serializable]
	public class ClassWithPrivateFieldSerializable
	{
		private int m_field1;

		public void SetField1(int value)
		{
			this.m_field1 = value;
		}

		public int GetField1()
		{
			return this.m_field1;
		}
	}

	[DataContract]
	public class ClassWithPrivateFieldDataContract
	{
		[DataMember]
		private int m_field1;

		public void SetField1(int value)
		{
			this.m_field1 = value;
		}

		public int GetField1()
		{
			return this.m_field1;
		}
	}

	#endregion ClassWithPrivateField



	#region ClassWithReadonlyField

	public class ClassWithReadonlyFieldUnattributed
	{
		public readonly int Field1;

		public ClassWithReadonlyFieldUnattributed()
		{
			this.Field1 = -1;
		}

		public ClassWithReadonlyFieldUnattributed(int value)
		{
			this.Field1 = value;
		}
	}

	[Serializable]
	public class ClassWithReadonlyFieldSerializable
	{
		public readonly int Field1;

		public ClassWithReadonlyFieldSerializable()
		{
			this.Field1 = -1;
		}

		public ClassWithReadonlyFieldSerializable(int value)
		{
			this.Field1 = value;
		}
	}

	[DataContract]
	public class ClassWithReadonlyFieldDataContract
	{
		[DataMember]
		public readonly int Field1;

		public ClassWithReadonlyFieldDataContract()
		{
			this.Field1 = -1;
		}

		public ClassWithReadonlyFieldDataContract(int value)
		{
			this.Field1 = value;
		}
	}

	#endregion ClassWithReadonlyField



	#region ClassWithEnumField

	public class ClassWithEnumFieldUnattributed
	{
		public TestEnum EnumField { get; set; }
	}

	[Serializable]
	public class ClassWithEnumFieldSerializable
	{
		public TestEnum EnumField { get; set; }
	}

	[DataContract]
	public class ClassWithEnumFieldDataContract
	{
		[DataMember]
		public TestEnum EnumField { get; set; }
	}

	#endregion ClassWithEnumField



	#region Mix attribute types

	public class UnattributedClassWithSerializableMember
	{
		public PlainClassSerializable SubMember { get; set; }
	}

	public class UnattributedClassWithDataContractMember
	{
		public PlainClassDataContract SubMember { get; set; }
	}

	[Serializable]
	public class SerializableClassWithUnattributedMember
	{
		public PlainClassUnattributed SubMember { get; set; }
	}

	[Serializable]
	public class SerializableClassWithDataContractMember
	{
		public PlainClassDataContract SubMember { get; set; }
	}

	[DataContract]
	public class DataContractClassWithUnattributedMember
	{
		[DataMember]
		public PlainClassUnattributed SubMember { get; set; }
	}

	[DataContract]
	public class DataContractClassWithSerializableMember
	{
		[DataMember]
		public PlainClassSerializable SubMember { get; set; }
	}

	#endregion Mix attribute types

	public class ClassWithSelfReferenceUnattributed
	{
		public int SomeField { get; set; }

		public ClassWithSelfReferenceUnattributed Member1 { get; set; }

		public ClassWithSelfReferenceUnattributed Member2 { get; set; }
	}

	[Serializable]
	public class ClassWithSelfReferenceSerializable
	{
		public int SomeField { get; set; }

		public ClassWithSelfReferenceSerializable Member1 { get; set; }

		public ClassWithSelfReferenceSerializable Member2 { get; set; }
	}

	[DataContract(IsReference = false)]
	public class ClassWithSelfReferenceDataContractAndReferenceFalse
	{
		[DataMember]
		public int SomeField { get; set; }

		[DataMember]
		public ClassWithSelfReferenceDataContractAndReferenceFalse Member1 { get; set; }

		[DataMember]
		public ClassWithSelfReferenceDataContractAndReferenceFalse Member2 { get; set; }
	}

	[DataContract(IsReference = true)]
	public class ClassWithSelfReferenceDataContractAndReferenceTrue
	{
		[DataMember]
		public int SomeField { get; set; }

		[DataMember]
		public ClassWithSelfReferenceDataContractAndReferenceTrue Member1 { get; set; }

		[DataMember]
		public ClassWithSelfReferenceDataContractAndReferenceTrue Member2 { get; set; }
	}

	namespace InnerNamespace1
	{
		public class ClassWithNamespaceUnattributed
		{
			public int SomeField { get; set; }
		}

		[Serializable]
		public class ClassWithNamespaceSerializable
		{
			public int SomeField { get; set; }
		}

		[DataContract]
		public class ClassWithNamespaceDataContract
		{
			[DataMember]
			public int SomeField { get; set; }
		}

		public class ClassWithOtherNameUnattributed
		{
			public int SomeField { get; set; }
		}

		[Serializable]
		public class ClassWithOtherNameSerializable
		{
			public int SomeField { get; set; }
		}

		[DataContract]
		public class ClassWithOtherNameDataContractWithoutAttrib
		{
			[DataMember]
			public int SomeField { get; set; }
		}

		[DataContract(Name = "ClassWithNamespaceDataContract")]
		public class ClassWithOtherNameDataContractWithAttrib
		{
			[DataMember]
			public int SomeField { get; set; }
		}
	}

	namespace InnerNamespace2
	{
		// ReSharper disable once ClassNeverInstantiated.Global
		public class ClassWithNamespaceUnattributed
		{
			public int SomeField { get; set; }
		}

		[Serializable]
		public class ClassWithNamespaceSerializable
		{
			public int SomeField { get; set; }
		}

		[DataContract]
		public class ClassWithNamespaceDataContractWithoutAttrib
		{
			[DataMember]
			public int SomeField { get; set; }
		}

		[DataContract(Name = "ClassWithNamespaceDataContract", Namespace = "http://schemas.datacontract.org/2004/07/SerializerTests.InnerNamespace1")]
		public class ClassWithNamespaceDataContractWithAttrib
		{
			[DataMember]
			public int SomeField { get; set; }
		}
	}

	#region Read Only Collections

	public class ClassWithReadonlyCollectionUnattributed
	{
		public ReadOnlyCollection<int> Collection { get; set; }
	}

	[Serializable]
	public class ClassWithReadonlyCollectionSerializable
	{
		public ReadOnlyCollection<int> Collection { get; set; }
	}

	[DataContract]
	public class ClassWithReadonlyCollectionDataContract
	{
		[DataMember]
		public ReadOnlyCollection<int> Collection { get; set; }
	}

	#endregion Read Only Collections
}
