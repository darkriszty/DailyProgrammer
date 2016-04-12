using System;
using System.IO;
using DP._20160404.Models;

namespace DP._20160404.IO
{
	/// <summary>
	/// Responsible to write the square values to the provided output.
	/// </summary>
	public class SquareWriter : ISquareWriter
	{
		/// <summary>
		/// Write the provided square to the provided output.
		/// </summary>
		/// <param name="square">The square to write</param>
		/// <param name="output">The output to write into</param>
		/// <exception cref="ArgumentNullException">In case the square or the output is null.</exception>
		public void WriteSquare(Square square, TextWriter output)
		{
			if (square == null) throw new ArgumentNullException(nameof(square));
			if (output == null) throw new ArgumentNullException(nameof(output));

			output.WriteLine("Square:");
			for (int i = 0; i < square.Size; i++)
			{
				for (int j = 0; j < square.Size; j++)
				{
					output.Write($"{square.Values[i][j]} ");
				}
				output.WriteLine();
			}
		}
	}
}