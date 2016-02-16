using System;
using System.Collections.Generic;
using System.Linq;
using DP._20160210.BLL.Models.Rpn;
using DP._20160210.BLL.RPN.Validation;

namespace DP._20160210.BLL.RPN
{
	/// <summary>
	/// Responsible to convert the  Reverse Polish Notation to paranthesis notation.
	/// </summary>
	public class RpnToParenthesisNotationConverterConverter : IRpnToParenthesisNotationConverter
	{
		private readonly IRpnInputValidator _inputValidator;
		private readonly ITokenInfoProvider _tokenInfoProvider;

		public RpnToParenthesisNotationConverterConverter(IRpnInputValidator inputValidator, 
			ITokenInfoProvider tokenInfoProvider)
		{
			_inputValidator = inputValidator;
			_tokenInfoProvider = tokenInfoProvider;
		}

		/// <summary>
		/// Tries to convert the RPN to parenthesis notation.
		/// </summary>
		/// <param name="input">The RPN input</param>
		/// <param name="result">The output, if any; otherwise null.</param>
		/// <returns>True, for success; false for failure.</returns>
		public bool TryGetParenthesisNotation(string input, out string result)
		{
			// split the input to obtain the tokens, then reverse it (in order to simplify removal from list later)
			List<string> pieces = input.Split(' ').Reverse().ToList();

			// ensure that the input only contains valid tokens
			RpnInputValidationResult validationResult = _inputValidator.Validate(pieces);
			if (!validationResult.IsValid)
			{
				result = null;
				return false;
			}

			result = null;

			// put the values on the stack
			Stack<decimal> stack = new Stack<decimal>();

			int operatorCount = 0;

			// loop through the reversed list in reverse order
			for (int i = pieces.Count - 1; i >= 0; i--)
			{
				string currentValue = pieces[i];
				pieces.RemoveAt(i);
				TokenType tokenType = _tokenInfoProvider.GetTokenType(currentValue);

				bool firstPop = string.IsNullOrWhiteSpace(result);
				bool isLast = pieces.Count == 0;
				

				switch (tokenType)
				{
					case TokenType.Unkown:
						throw new ApplicationException("Unkown token type; this should have been prevented by the validation.");

					case TokenType.Value:
						// if the token is a value then put it on the stack
						stack.Push(decimal.Parse(currentValue));
						break;

					case TokenType.Operator:
						// if the token is an operator then there must be at least one number left on the stack

						if (stack.Count < 1)
						{
							result = null;
							return false;
						}

						operatorCount++;

						string operationChar = currentValue[0].ToString();
						if (firstPop)
						{
							// pop the right then the left (the order matters since not all operations are commutative)
							decimal right = stack.Pop();
							decimal left = stack.Pop();

							result = isLast
								? left + operationChar + right
								: string.Format("({0}{1}{2})", left, operationChar, right);
						}
						else
						{
							decimal value = stack.Pop();
							// oscilate when adding a new value to the result in order not to get all the opening parenthesis on the left, like (((((...
							if (operatorCount%2 == 0)
							{
								if (isLast)
									result = result + operationChar + value;
								else
									result = "(" + result + operationChar + value + ")";
							}
							else
							{
								if (isLast)
									result = value + operationChar + result;
								else
									result = "(" + value + operationChar + result + ")";
							}
						}

						break;
				}
			}

			return !string.IsNullOrWhiteSpace(result);
		}
	}
}