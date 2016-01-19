using System;

namespace DP._20160113.BLL.Strings
{
	public class CharDistanceCalculator : IStringDistanceCalculator
	{
		/// <summary>
		/// Get the sum of character distances between two strings.
		/// </summary>
		/// <param name="s">The first string.</param>
		/// <param name="t">The second string.</param>
		/// <returns>The distance</returns>
		/// <exception cref="ArgumentException">If the strings don't have the same length</exception>
		public int GetDistance(string s, string t)
		{
			// only same length strings can be used
			if (s.Length != t.Length)
				throw new ArgumentException("Only same length-strings are allowed for char distance calculation.");

			int distance = 0;
			char[] left = s.ToCharArray();
			char[] right = t.ToCharArray();

			for (int i = 0; i < left.Length; i++)
			{
				int charDistance = Math.Abs(left[i] - right[i]);
				distance += charDistance;
			}

			return distance;
		}
	}
}