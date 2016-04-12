using System.IO;
using DP._20160404.IO;
using DP._20160404.Models;

namespace DP._20160404.Business
{
	/// <summary>
	/// Responsible to deal with the business logic of reading squares and verifying their 'magicness'.
	/// </summary>
	public class MagicSquareController : IMagicSquareController
	{
		private readonly ISquareReader _squareReader;
		private readonly ISquareWriter _squareWriter;
		private readonly IMagicSquareVerifier _magicSquareVerifier;

		public MagicSquareController(ISquareReader squareReader, 
			ISquareWriter squareWriter, IMagicSquareVerifier magicSquareVerifier)
		{
			_squareReader = squareReader;
			_squareWriter = squareWriter;
			_magicSquareVerifier = magicSquareVerifier;
		}

		/// <summary>
		/// Runs the controller (read square + verify magic property).
		/// </summary>
		/// <param name="input">The input to read the square from</param>
		/// <param name="output">The output where to write the messages</param>
		public void Run(TextReader input, TextWriter output)
		{
			Square square = _squareReader.ReadSquare(input, output);

			_squareWriter.WriteSquare(square, output);

			output.WriteLine(_magicSquareVerifier.IsMagicSquare(square) 
				? "Magic square found!" 
				: "Not a magic square.");
		}
	}
}