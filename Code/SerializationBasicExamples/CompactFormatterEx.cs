using CompactFormatter;
using CompactFormatter.Surrogate;

namespace SerializationBasicExamples
{
	/// <summary>
	/// Extends the CompactFormatter to automatically include the overrides and surrogates
	/// commonly used.
	/// </summary>
	public class CompactFormatterEx : CompactFormatter.CompactFormatter
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="CompactFormatterEx"/> class.
		/// </summary>
		public CompactFormatterEx()
			: this(CFormatterMode.SURROGATE)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CompactFormatterEx"/> class.
		/// </summary>
		/// <param name="mode">The mode.</param>
		public CompactFormatterEx(CFormatterMode mode)
			: base(mode)
		{
			AddSurrogate(typeof(DefaultSurrogates));
			AddOverrider(typeof(DataSetOverrider));
			AddOverrider(typeof(GhostDataTableOverrider));
		}

		#endregion Constructors
	}
}