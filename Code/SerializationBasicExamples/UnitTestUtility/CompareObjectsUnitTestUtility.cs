#region Namespaces

using System;
using System.Data;
using KellermanSoftware.CompareNetObjects;

#endregion Namespaces

namespace SerializationBasicExamples.UnitTestUtility
{
	/// <summary>
	/// Compare two objects.
	/// </summary>
	public static class CompareObjectsUnitTestUtility
	{
		/// <summary>
		/// Compare two objects using the default CompareObjects settings
		/// </summary>
		/// <param name="object1">First object to compare</param>
		/// <param name="object2">Second object to compare</param>
		public static void CompareObjects(object object1, object object2)
		{
			CompareObjects(object1, object2, CreateComparer());
		}

		/// <summary>
		/// Compare two objects
		/// </summary>
		/// <param name="object1">First object to compare</param>
		/// <param name="object2">Second object to compare</param>
		/// <param name="compareChildren">Compare child</param>
		/// <param name="compareFields">If true, compare fields of a class (see also CompareProperties).</param>
		/// <param name="comparePrivateFields">If true, private fields will be compared.</param>
		/// <param name="comparePrivateProperties">If true, private properties will be compared.</param>
		/// <param name="compareProperties">If true, compare properties of a class (see also CompareFields).</param>
		/// <param name="compareReadOnly">If true, compare read only properties (only the getter is implemented).</param>
		/// <param name="elementsToIgnore"></param>
		public static void CompareObjects(
			object object1, 
			object object2, 
			bool compareChildren,
			bool compareFields,
			bool comparePrivateFields,
			bool comparePrivateProperties,
			bool compareProperties,
			bool compareReadOnly,
			params string[] elementsToIgnore)
		{
			CompareObjects comparer = CreateComparer();

			comparer.CompareChildren = compareChildren;
			comparer.CompareFields = compareFields;
			comparer.ComparePrivateFields = comparePrivateFields;
			comparer.ComparePrivateProperties = comparePrivateProperties;
			comparer.CompareProperties = compareProperties;
			comparer.CompareReadOnly = compareReadOnly;

			if ((elementsToIgnore != null) && (elementsToIgnore.Length > 0))
			{
				comparer.ElementsToIgnore.AddRange(elementsToIgnore);
			}

			CompareObjects(object1, object2, comparer);
		}

		/// <summary>
		/// Compare two objects
		/// </summary>
		/// <param name="object1">First object to compare</param>
		/// <param name="object2">Second object to compare</param>
		/// <param name="comparer">An instance of type CompareObjects to use.</param>
		public static void CompareObjects(object object1, object object2, CompareObjects comparer) 
		{
			if (!comparer.Compare(object1, object2))
				throw new Exception(comparer.DifferencesString);
		}

		/// <summary>
		/// Creates a new CompareObjects object and sets the MaxDifferences to 99;
		/// </summary>
		/// <returns></returns>
		public static CompareObjects CreateComparer()
		{
			CompareObjects comparer = new CompareObjects();
			comparer.MaxDifferences = 99;
			comparer.AddCustomComparer(typeof(DataSet), CompareDataSet);

			return comparer;
		}

		private static bool CompareDataSet(object object1, object object2)
		{
			DataSet dataSet1 = (DataSet)object1;
			DataSet dataSet2 = (DataSet)object2;

			if (dataSet1.Tables.Count != dataSet2.Tables.Count)
				return false;

			for (int index = 0; index < dataSet1.Tables.Count; index++)
			{
				if (dataSet1.Tables[index].Rows.Count != dataSet2.Tables[index].Rows.Count)
				{
					return false;
				}
			}

			return true;
		}
	}
}
