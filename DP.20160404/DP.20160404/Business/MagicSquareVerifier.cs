using System;
using DP._20160404.Models;

namespace DP._20160404.Business
{
	/// <summary>
	/// Responsible to verify if a square is magic or not.
	/// <remarks>A square is magic of the sum of the rows, columns and two diagonals add up to a magic number.</remarks>
	/// </summary>
	public class MagicSquareVerifier : IMagicSquareVerifier
	{
		/// <summary>
		/// The magic number to verify the square against.
		/// </summary>
		private readonly int _magicNumber;

		public MagicSquareVerifier(int magicNumber)
		{
			_magicNumber = magicNumber;
		}

		/// <summary>
		/// Verifies if the provided square matches the magic number.
		/// </summary>
		/// <param name="square">The square to check</param>
		/// <returns>True, if the square is magic; otherwise false.</returns>
		/// <exception cref="ArgumentNullException">If the square is null.</exception>
		public bool IsMagicSquare(Square square)
		{
			if (square == null) throw new ArgumentNullException(nameof(square));

			int mainDiagSum = 0;
			int antiDiagSum = 0;
			for (int i = 0; i < square.Size; i++)
			{
				int rowSum = 0;
				int colSum = 0;
				for (int j = 0; j < square.Size; j++)
				{
					// sum the current row
					rowSum += square.Values[i][j];
					// sum the current column
					colSum += square.Values[j][i];

					// sum the main diagonal values (when the two indicies are equal)
					if (i == j)
						mainDiagSum += square.Values[i][j];

					// sum the anti diagonal values (when the two indicis add up to size - 1)
					if ((i + j) == (square.Size - 1))
						antiDiagSum += square.Values[i][j];
				}

				// after each row/column summing is complete verify if the magic value is obtained; otherwise do an early stop
				if (rowSum != _magicNumber || colSum != _magicNumber)
					return false;
			}

			// after passing through the whole square (with magic sum on rows and colums) verify the two diagonal sums
			if (mainDiagSum != _magicNumber || antiDiagSum != _magicNumber)
				return false;

			return true;
		}
	}
}