#region Namespaces

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using CompactFormatter;

#endregion Namespaces

namespace SerializationBasicExamples.DataClasses
{
	/// <summary>
	/// Represents a server job that has one statement associated with it.
	/// </summary>
	[Serializable]
	[CompactFormatter.Attributes.Serializable(Custom = true)]
	public abstract class JobInfo
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="JobInfo"/> class. This is intended
		/// for use with serialization and should not be used in normal development.
		/// </summary>
		protected JobInfo()
		{
		}

		/// <summary>
		/// Deserialize the job object from serialization info
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected JobInfo(SerializationInfo info, StreamingContext context)
			// : base(info, context)
		{
			// Grab the statement
			info.GetInt32("JobInfoVersion");
			m_ID = (Guid)info.GetValue("Id", typeof(Guid));
			m_Identifiers = new List<string>((string[])info.GetValue("Identifiers", typeof(string[])));
		}

		#endregion Constructors

		#region Public Properties

		/// <summary>
		/// Gets the statement ID for this job.
		/// </summary>
		/// <value>The statement ID.</value>
		public Guid Id
		{
			get { return m_ID; }
			set { m_ID = value; }
		}

		/// <summary>
		/// Gets or sets the identifiers.
		/// </summary>
		/// <value>
		/// The identifiers.
		/// </value>
		public List<string> Identifiers
		{
			get { return m_Identifiers; }
			set { m_Identifiers = value; }
		}

		#endregion Public Properties

		#region Public Methods

		#region Implementation of ICSerializable

		/// <summary>
		/// This function is invoked by CompactFormatter when serializing a 
		/// Custom Serializable object.
		/// </summary>
		/// <param name="parent">A reference to the CompactFormatter instance which called this method.</param>
		/// <param name="stream">The Stream where object data must be written</param>
		public void SendObjectData(CompactFormatter.CompactFormatter parent, Stream stream)
		{
			// Call the base implement to get those values.
			//base.SendObjectData(parent, stream);

			// Start by adding the versioning field for the job.
			CustomSerializationHelper.Serialize(stream, VERSION);

			// Serialize the statement job elements.
			CustomSerializationHelper.Serialize(stream, m_ID);
			parent.Serialize(stream, m_Identifiers.ToArray());
		}

		/// <summary>
		/// This function is invoked by CompactFormatter when deserializing a
		/// Custom Serializable object.
		/// </summary>
		/// <param name="parent">A reference to the CompactFormatter instance which called this method.</param>
		/// <param name="stream">The Stream where object data must be read</param>
		public void ReceiveObjectData(CompactFormatter.CompactFormatter parent, Stream stream)
		{
			// Retrieve the information for the base implementation.
			//base.ReceiveObjectData(parent, stream);

			// Grab the version field.
			CustomSerializationHelper.DeserializeInt32(stream);

			// Deserialize the job elements.
			m_ID = CustomSerializationHelper.DeserializeGuid(stream);
			m_Identifiers = new List<string>((string[])parent.Deserialize(stream));
		}

		#endregion Implementation of ICSerializable

		#region ISerializable Implementation

		/// <summary>
		/// Populate serialization info with all the data required to represent
		/// the object for serialization
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			// base.GetObjectData(info, context);
			info.AddValue("JobInfoVersion", VERSION);
			info.AddValue("Id", m_ID);
			info.AddValue("Identifiers", m_Identifiers.ToArray());
		}

		#endregion ISerializable Implementation

		#endregion Public Methods

		#region Private Constants

		private const int VERSION = 1;

		#endregion Private Constants

		#region Private Fields

		private Guid m_ID;
		private List<string> m_Identifiers = new List<string>();

		#endregion Private Fields
	}
}
