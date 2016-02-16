using System;
using System.Collections.Generic;
using System.Linq;
using DP._20160210.BLL.Models.Rpn;
using DP._20160210.BLL.RPN.Validation;

namespace DP._20160210.BLL.RPN
{
	/// <summary>
	/// Responsible to perform calculations in Reverse Polish Notation
	/// </summary>
	public class RpnCalculator : IRpnCalculator
	{
		private const string NO_INPUT = "Input not available.";
		private const string NOT_ENOUGH_VALUES = "Unable to find the two numbers to perform the operation {0}.";
		private const string UNABLE_TO_CALCULATE = "Unable to calculate final result, {0} numbers are left instead of one.";
		private readonly ITokenInfoProvider _tokenInfoProvider;
		private readonly IRpnInputValidator _inputValidator;

		public RpnCalculator(ITokenInfoProvider tokenInfoProvider,
			IRpnInputValidator inputValidator)
		{
			_tokenInfoProvider = tokenInfoProvider;
			_inputValidator = inputValidator;
		}

		/// <summary>
		/// Calculates and returns the result of the input string.
		/// </summary>
		/// <param name="input">The input string in RPN</param>
		/// <returns>The calculated result.</returns>
		public RpnResult GetResult(string input)
		{
			RpnResult result = new RpnResult();

			if (string.IsNullOrWhiteSpace(input))
			{
				result.ErrorMessages.Add(NO_INPUT);
				return result;
			}

			// split the input to obtain the tokens, then reverse it (in order to simplify removal from list later)
			List<string> pieces = input.Split(' ').Reverse().ToList();

			// ensure that the input only contains valid tokens
			RpnInputValidationResult validationResult = _inputValidator.Validate(pieces);
			if (!validationResult.IsValid)
			{
				result.ErrorMessages.AddRange(validationResult.ErrorMessages);
				return result;
			}

			// put the values on the stack
			Stack<decimal> stack = new Stack<decimal>();

			// loop through the reversed list in reverse order
			for (int i = pieces.Count - 1; i >= 0; i--)
			{
				string currentValue = pieces[i];
				pieces.RemoveAt(i);
				TokenType tokenType =_tokenInfoProvider.GetTokenType(currentValue);

				switch (tokenType)
				{
					case TokenType.Unkown:
						throw new ApplicationException("Unkown token type; this should have been prevented by the validation.");

					case TokenType.Value:
						// if the token is a value then put it on the stack
						stack.Push(decimal.Parse(currentValue));
						break;
					
					case TokenType.Operator:
						// if the token is an operator then perform the operation on the last two values from the stack

						if (stack.Count < 2)
						{
							result.ErrorMessages.Add(string.Format(NOT_ENOUGH_VALUES, currentValue));
							return result;
						}

						// pop the right then the left (the order matters since not all operations are commutative)
						decimal right = stack.Pop();
						decimal left = stack.Pop();

						OperationType operationType = _tokenInfoProvider.GetOperationType(currentValue[0]);
						switch (operationType)
						{
							case OperationType.Addition:
								stack.Push(left + right);
								break;
							case OperationType.Subtraction:
								stack.Push(left - right);
								break;
							case OperationType.Multiplication:
								stack.Push(left * right);
								break;
							case OperationType.Division:
								stack.Push(left / right);
								break;
							default:
								throw new ApplicationException("Unkown operation type; this should have been prevented by the validation.");
						}

						break;
				}
			}

			// in the end there should be a single value left on the stack: the result
			if (stack.Count == 1)
			{
				result.CalculationResult = stack.Pop();
			}
			else
			{
				result.ErrorMessages.Add(string.Format(UNABLE_TO_CALCULATE, stack.Count));
			}

			return result;
		}
	}
}