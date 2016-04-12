using System.IO;

namespace DP._20160404.Business
{
	/// <summary>
	/// Responsible to deal with the business logic of reading squares and verifying their 'magicness'.
	/// </summary>
	public interface IMagicSquareController
	{
		/// <summary>
		/// Runs the controller (read square + verify magic property).
		/// </summary>
		/// <param name="input">The input to read the square from</param>
		/// <param name="output">The output where to write the messages</param>
		void Run(TextReader @in, TextWriter @out);
	}
}