namespace DP._20160113.BLL.Strings
{
	/// <summary>
	/// Compute the distance between two strings.
	/// </summary>
	public interface IStringDistanceCalculator
	{
		/// <summary>
		/// Get the minimum number of single-character edits (i.e. insertions, deletions or substitutions) required to change one word into the other.
		/// </summary>
		/// <param name="s">The first string.</param>
		/// <param name="t">The second string.</param>
		/// <remarks>From http://www.dotnetperls.com/levenshtein</remarks>
		/// <returns>The distance</returns>
		int GetDistance(string s, string t);
	}
}
