using System;

namespace DP._20160418
{
	/// <summary>
	/// Responsible to calculate the Shannon entropy of given strings.
	/// </summary>
	/// <remarks>https://en.wiktionary.org/wiki/Shannon_entropy</remarks>
	public class ShannonEntropyCalculator
	{
		/// <summary>
		/// Get the Shannon entropy of the input.
		/// </summary>
		/// <param name="input">The input to get the entropy for</param>
		/// <returns>The entropy represented as a decimal</returns>
		/// <exception cref="ArgumentNullException">If the input is null</exception>
		public static decimal GetEntropy(string input)
		{
			if (input == null) 
				throw new ArgumentNullException(nameof(input));

			return 0;
		}
	}
}