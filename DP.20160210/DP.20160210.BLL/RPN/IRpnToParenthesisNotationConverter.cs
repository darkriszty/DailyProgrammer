namespace DP._20160210.BLL.RPN
{
	public interface IRpnToParenthesisNotationConverter
	{
		/// <summary>
		/// Tries to convert the RPN to parenthesis notation.
		/// </summary>
		/// <param name="input">The RPN input</param>
		/// <param name="result">The output, if any; otherwise null.</param>
		/// <returns>True, for success; false for failure.</returns>
		bool TryGetParenthesisNotation(string input, out string result);
	}
}