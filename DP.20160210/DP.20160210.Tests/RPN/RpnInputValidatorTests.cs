using System.Linq;
using DP._20160210.BLL.IoC;
using DP._20160210.BLL.Models.Rpn;
using DP._20160210.BLL.RPN.Validation;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DP._20160210.Tests.RPN
{
	[TestClass]
	public class RpnInputValidatorTests
	{
		[TestMethod]
		public void Test_Validate_PositiveIntegersValid()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var validator = container.Resolve<IRpnInputValidator>();

			// act
			RpnInputValidationResult validationResult = validator.Validate(new[] { "5", "6", "7" });

			// assert
			Assert.IsNotNull(validationResult);
			Assert.IsTrue(validationResult.IsValid);
			Assert.IsTrue(!validationResult.ErrorMessages.Any());
		}

		[TestMethod]
		public void Test_Validate_NegativeIntegersValid()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var validator = container.Resolve<IRpnInputValidator>();

			// act
			RpnInputValidationResult validationResult = validator.Validate(new[] { "-15", "-556", "-9997", "-966375" });

			// assert
			Assert.IsNotNull(validationResult);
			Assert.IsTrue(validationResult.IsValid);
			Assert.IsTrue(!validationResult.ErrorMessages.Any());
		}

		[TestMethod]
		public void Test_Validate_PositiveRealsValid()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var validator = container.Resolve<IRpnInputValidator>();

			// act
			RpnInputValidationResult validationResult = validator.Validate(new[] { "0.44", "5.11", "87.02" });

			// assert
			Assert.IsNotNull(validationResult);
			Assert.IsTrue(validationResult.IsValid);
			Assert.IsTrue(!validationResult.ErrorMessages.Any());
		}

		[TestMethod]
		public void Test_Validate_NegativeRealsValid()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var validator = container.Resolve<IRpnInputValidator>();

			// act
			RpnInputValidationResult validationResult = validator.Validate(new[] { "-15.111", "-5.56", "-999.7", "-9.66375" });

			// assert
			Assert.IsNotNull(validationResult);
			Assert.IsTrue(validationResult.IsValid);
			Assert.IsTrue(!validationResult.ErrorMessages.Any());
		}

		[TestMethod]
		public void Test_Validate_MixedNumbersValid()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var validator = container.Resolve<IRpnInputValidator>();

			// act
			RpnInputValidationResult validationResult = validator.Validate(new[] { "-15.111", "5.56", "-999", "-35", "1024" });

			// assert
			Assert.IsNotNull(validationResult);
			Assert.IsTrue(validationResult.IsValid);
			Assert.IsTrue(!validationResult.ErrorMessages.Any());
		}

		[TestMethod]
		public void Test_Validate_OperationsValid()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var validator = container.Resolve<IRpnInputValidator>();

			// act
			RpnInputValidationResult validationResult = validator.Validate(new[] { "+", "-", "*", "/" });

			// assert
			Assert.IsNotNull(validationResult);
			Assert.IsTrue(validationResult.IsValid);
			Assert.IsTrue(!validationResult.ErrorMessages.Any());
		}

		[TestMethod]
		public void Test_Validate_MixedNumbersAndOperationsValid1()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var validator = container.Resolve<IRpnInputValidator>();

			// act
			RpnInputValidationResult validationResult = validator.Validate(new[] { "1234", "-0.523", "+", "95", "*", "/", "2456.21" });

			// assert
			Assert.IsNotNull(validationResult);
			Assert.IsTrue(validationResult.IsValid);
			Assert.IsTrue(!validationResult.ErrorMessages.Any());
		}

		[TestMethod]
		public void Test_Validate_MixedNumbersAndOperationsValid2()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var validator = container.Resolve<IRpnInputValidator>();

			// act
			RpnInputValidationResult validationResult = validator.Validate(new[] { "1", "-", "-9.333", "*" });

			// assert
			Assert.IsNotNull(validationResult);
			Assert.IsTrue(validationResult.IsValid);
			Assert.IsTrue(!validationResult.ErrorMessages.Any());
		}

		[TestMethod]
		public void Test_Validate_MixedNumbersAndOperationsInvalid1()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var validator = container.Resolve<IRpnInputValidator>();

			// act
			RpnInputValidationResult validationResult = validator.Validate(new[] { "1234", "-0.523", "#", "95", "*", "/", "2456.21" });

			// assert
			Assert.IsNotNull(validationResult);
			Assert.IsFalse(validationResult.IsValid);
			Assert.IsTrue(validationResult.ErrorMessages.Any());
			foreach(string errorMessage in validationResult.ErrorMessages)
				Assert.IsTrue(!string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void Test_Validate_MixedNumbersAndOperationsInvalid2()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var validator = container.Resolve<IRpnInputValidator>();

			// act
			RpnInputValidationResult validationResult = validator.Validate(new[] { "1", "=", "-9.333", "*" });

			// assert
			Assert.IsNotNull(validationResult);
			Assert.IsFalse(validationResult.IsValid);
			foreach (string errorMessage in validationResult.ErrorMessages)
				Assert.IsTrue(!string.IsNullOrWhiteSpace(errorMessage));
		}
	}
}