using System;
using System.IO;

namespace DP._20160404.IO
{
	/// <summary>
	/// Responsible to read integer values from an input.
	/// </summary>
	public interface IIntegerInputReader
	{
		/// <summary>
		/// Reads integer values with retry, until the correct value is provided.
		/// </summary>
		/// <param name="input">The input to read the number from</param>
		/// <param name="message">Optional; a message to display to the <see cref="output"/></param>
		/// <param name="output">>Optional; an output to write the provided <see cref="message"/> to</param>
		/// <returns>The value read</returns>
		/// <exception cref="ArgumentNullException">If the input is null.</exception>
		int ReadInteger(TextReader input, string message, TextWriter output);
	}
}