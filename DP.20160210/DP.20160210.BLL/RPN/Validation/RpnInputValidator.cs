using System.Collections.Generic;
using System.Linq;
using DP._20160210.BLL.Models.Rpn;

namespace DP._20160210.BLL.RPN.Validation
{
	/// <summary>
	/// Responsible for validation the RPN input.
	/// </summary>
	public class RpnInputValidator : IRpnInputValidator
	{
		private const string INVALID_TOKEN = "Invalid token '{0}'";
		private const string NOT_ENOUGH_VALUES = "Not enough values left on the stack.";
		private readonly ITokenInfoProvider _tokenInfoProvider;

		public RpnInputValidator(ITokenInfoProvider tokenInfoProvider)
		{
			_tokenInfoProvider = tokenInfoProvider;
		}

		/// <summary>
		/// Validates the RPN input and returns a validation result indicating the success.
		/// </summary>
		/// <param name="input">The input to validate</param>
		/// <returns>The validation result</returns>
		public RpnInputValidationResult Validate(IEnumerable<string> input)
		{
			RpnInputValidationResult result = new RpnInputValidationResult
			{
				IsValid = true
			};

			List<string> inputList = input.Reverse().ToList();

			Stack<decimal> stack = new Stack<decimal>();
			for (int index = inputList.Count - 1; index >= 0; index--)
			{
				string token = inputList[index];
				inputList.RemoveAt(index);

				TokenType tokenType = _tokenInfoProvider.GetTokenType(token);

				if (!result.IsValid)
					break;

				switch (tokenType)
				{
					case TokenType.Unkown:
						result.IsValid = false;
						result.ErrorMessages.Add(string.Format(INVALID_TOKEN, token));
						break;

					case TokenType.Value:
						stack.Push(decimal.Parse(token));
						break;

					case TokenType.Operator:

						if (stack.Count < 2)
						{
							result.IsValid = false;
							result.ErrorMessages.Add(string.Format(NOT_ENOUGH_VALUES));
							break;
						}

						// equivalent of removing two values, performing the operation and putting the result back on the stack
						stack.Pop();
						break;
				}
			}

			return result;
		}
	}
}