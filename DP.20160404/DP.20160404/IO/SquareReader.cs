using System;
using System.IO;
using DP._20160404.Models;

namespace DP._20160404.IO
{
	/// <summary>
	/// Responsible to read the square from the provided input.
	/// </summary>
	public class SquareReader : ISquareReader
	{
		private readonly IIntegerInputReader _integerInputReader;

		public SquareReader(IIntegerInputReader integerInputReader)
		{
			_integerInputReader = integerInputReader;
		}

		/// <summary>
		/// Reads the square size and values from the provided input.
		/// </summary>
		/// <param name="input">Where to read the values from</param>
		/// <param name="output">Optional; where to write messages to</param>
		/// <returns>The constructed square.</returns>
		/// <exception cref="ArgumentNullException">Thrown if the input is null.</exception>
		public Square ReadSquare(TextReader input, TextWriter output)
		{
			if (input == null) throw new ArgumentNullException(nameof(input));

			int size = _integerInputReader.ReadInteger(input, "Square size (greater than zero) :", output);

			var square = new Square(size);
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					square.Values[i][j] = _integerInputReader.ReadInteger(input, $"Square value [{i}, {j}]: ", output);
				}
			}

			return square;
		}
	}
}