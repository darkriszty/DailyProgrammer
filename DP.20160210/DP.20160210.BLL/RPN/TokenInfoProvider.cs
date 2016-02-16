using DP._20160210.BLL.Models.Rpn;

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
			// check if it is a value
			double value;
			if (double.TryParse(input, out value))
			{
				return TokenType.Value;
			}

			// if it's a single char then check if it is a known operation type
			if (input.Length == 1)
			{
				OperationType operationType = GetOperationType(input[0]);
				if (operationType != OperationType.Unkown)
				{
					return TokenType.Operator;
				}
			}

			return TokenType.Unkown;
		}

		/// <summary>
		/// Gets the type of operation of the provided input.
		/// </summary>
		/// <param name="input">The input operation</param>
		/// <returns>The type of operation if found; Unkown otherwise.</returns>
		public OperationType GetOperationType(char input)
		{
			switch (input)
			{
				case '+':
					return OperationType.Addition;
				case '-':
					return OperationType.Subtraction;
				case '*':
					return OperationType.Multiplication;
				case '/':
					return OperationType.Division;
			}

			return OperationType.Unkown;
		}
	}
}