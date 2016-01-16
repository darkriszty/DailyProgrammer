using System;

namespace DP._20160113.BLL.Strings
{
	/// <summary>
	/// Responsible to randomize strings.
	/// </summary>
	public class StringRandomizer : IStringRandomizer
	{
		private const string ALLOWED_CHARACTERS = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789`-=[]\;',./~!@#$%^&*()_+{}|:\""<>?";
		private readonly Random _random;

		public StringRandomizer()
		{
			_random = new Random();
		}

		/// <summary>
		/// Returns a random, same length string as the provided input.
		/// </summary>
		public string GetRandomizedInput(string originalInput)
		{
			string result;

			// make sure the input is not returned
			do
			{
				result = string.Empty;

				// build a random string char by char
				for (int i = 0; i < originalInput.Length; i++)
				{
					int nextCharIndex = _random.Next(ALLOWED_CHARACTERS.Length);

					result += ALLOWED_CHARACTERS[nextCharIndex];
				}
			} while (result == originalInput);

			return result;
		}
	}
}