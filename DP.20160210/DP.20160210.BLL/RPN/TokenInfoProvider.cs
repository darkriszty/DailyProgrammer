namespace DP._20160210.BLL.RPN
{
	/// <summary>
	/// Responsible to provide information about the input tokens in RPN.
	/// </summary>
	public class TokenInfoProvider : ITokenInfoProvider
	{
		/// <summary>
		/// Gets the type of the input token.
		/// </summary>
		public TokenType GetTokenType(string input)
		{
			return TokenType.Value;
		}

		/// <summary>
		/// Gets the type of operation of the provided input.
		/// </summary>
		/// <param name="input">The input operation</param>
		/// <returns>The type of operation if found; Unkown otherwise.</returns>
		public OperationType GetOperationType(char input)
		{
			return OperationType.Unkown;
		}
	}
}