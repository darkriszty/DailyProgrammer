namespace DP._20160113.BLL.Strings
{
	/// <summary>
	/// Compute the distance between two strings.
	/// </summary>
	public interface IStringDistanceCalculator
	{
		/// <summary>
		/// Get the "distance" between two strings.
		/// </summary>
		/// <param name="s">The first string.</param>
		/// <param name="t">The second string.</param>
		/// <returns>The distance</returns>
		int GetDistance(string s, string t);
	}
}
