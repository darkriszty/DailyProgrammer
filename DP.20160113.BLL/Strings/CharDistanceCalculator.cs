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
		public int GetDistance(string s, string t)
		{
			// only same length strings can be used
			if (s.Length != t.Length)
				return -1;

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