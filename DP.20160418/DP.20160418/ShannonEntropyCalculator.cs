using System;
using System.Collections.Generic;

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
		/// <returns>The entropy represented as a double</returns>
		/// <exception cref="ArgumentNullException">If the input is null</exception>
		public static double GetEntropy(string input)
		{
			if (input == null) 
				throw new ArgumentNullException(nameof(input));

			// build a character frequency mapping since chars may be duplicated and this gives a little performance improvment
			// over calculating it in a loop for every character
			Dictionary<char, int> charFrequencies = new Dictionary<char, int>();
			foreach (char c in input)
			{
				if (!charFrequencies.ContainsKey(c))
					charFrequencies[c] = 0;
				charFrequencies[c]++;
			}

			int length = input.Length;
			double entropy = 0;

			// loop through all the distinct characters
			foreach (var frequency in charFrequencies)
			{
				int characterCount = frequency.Value;

				// get the probability of the character in the sequence
				double probability = (double) characterCount / length;
				// log2 the probability and multiply
				probability *= Math.Log(probability, 2);

				// sum the result of this iteration
				entropy += probability;
			}

			return -entropy;
		}
	}
}