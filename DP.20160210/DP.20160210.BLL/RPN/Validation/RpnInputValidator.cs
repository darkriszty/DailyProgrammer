using System.Collections.Generic;

namespace DP._20160210.BLL.RPN.Validation
{
	/// <summary>
	/// Responsible for validation the RPN input.
	/// </summary>
	public class RpnInputValidator : IRpnInputValidator
	{
		private const string INVALID_TOKEN = "Invalid token '{0}'";
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

			foreach (string token in input)
			{
				TokenType tokenType = _tokenInfoProvider.GetTokenType(token);
				if (tokenType == TokenType.Unkown)
				{
					result.IsValid = false;
					result.ErrorMessages.Add(string.Format(INVALID_TOKEN, token));
					break;
				}
			}

			return result;
		}
	}
}