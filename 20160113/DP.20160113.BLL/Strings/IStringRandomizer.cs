namespace DP._20160113.BLL.Strings
{
	/// <summary>
	/// Responsible to randomize strings.
	/// </summary>
	public interface IStringRandomizer
	{
		/// <summary>
		/// Returns a random, same length string as the provided input.
		/// </summary>
		string GetRandomizedInput(string originalInput);

		/// <summary>
		/// Randomize a given number of characters in the input string.
		/// </summary>
		string RandomizeCharacter(string input, int charactersToRandomize);
	}
}