namespace DP._20160210.BLL.RPN.Validation
{
	/// <summary>
	/// Encapsulates the properties of a RPN input validation.
	/// </summary>
	public class RpnInputValidationResult
	{
		/// <summary>
		/// Gets or sets a value indicating whether or not the input is valid.
		/// </summary>
		public bool IsValid { get; set; }

		/// <summary>
		/// Gets or sets an error message for the case when the input is not valid
		/// </summary>
		public string ErrorMessage { get; set; }
	}
}