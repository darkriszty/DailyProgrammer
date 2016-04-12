using System;
using System.IO;
using DP._20160404.Models;

namespace DP._20160404.IO
{
	/// <summary>
	/// Responsible to read the square from the provided input.
	/// </summary>
	public interface ISquareReader
	{
		/// <summary>
		/// Reads the square size and values from the provided input.
		/// </summary>
		/// <param name="input">Where to read the values from</param>
		/// <param name="output">Optional; where to write messages to</param>
		/// <returns>The constructed square.</returns>
		/// <exception cref="ArgumentNullException">Thrown if the input is null.</exception>
		Square ReadSquare(TextReader input, TextWriter output);
	}
}