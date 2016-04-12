using System;
using System.IO;
using DP._20160404.Models;

namespace DP._20160404.IO
{
	/// <summary>
	/// Responsible to write the square values to the provided output.
	/// </summary>
	public interface ISquareWriter
	{
		/// <summary>
		/// Write the provided square to the provided output.
		/// </summary>
		/// <param name="square">The square to write</param>
		/// <param name="output">The output to write into</param>
		/// <exception cref="ArgumentNullException">In case the square or the output is null.</exception>
		void WriteSquare(Square square, TextWriter output);
	}
}