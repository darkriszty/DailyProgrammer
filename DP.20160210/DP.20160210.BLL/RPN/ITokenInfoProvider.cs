namespace DP._20160210.BLL.RPN
{
	/// <summary>
	/// Responsible to provide information about the input tokens in RPN.
	/// </summary>
	public interface ITokenInfoProvider
	{
		/// <summary>
		/// Gets the type of the input token.
		/// </summary>
		TokenType GetTokenType(string input);

		/// <summary>
		/// Gets the type of operation of the provided input.
		/// </summary>
		/// <param name="input">The input operation</param>
		/// <returns>The type of operation if found; Unkown otherwise.</returns>
		OperationType GetOperationType(char input);
	}
}