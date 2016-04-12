using System;
using DP._20160404.Models;

namespace DP._20160404.Business
{
	/// <summary>
	/// Responsible to verify if a square is magic or not.
	/// <remarks>A square is magic of the sum of the rows, columns and two diagonals add up to a magic number.</remarks>
	/// </summary>
	public interface IMagicSquareVerifier
	{
		/// <summary>
		/// Verifies if the provided square matches the magic number.
		/// </summary>
		/// <param name="square">The square to check</param>
		/// <returns>True, if the square is magic; otherwise false.</returns>
		/// <exception cref="ArgumentNullException">If the square is null.</exception>
		bool IsMagicSquare(Square square);
	}
}