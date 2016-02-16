using System.Linq;
using DP._20160210.BLL.IoC;
using DP._20160210.BLL.RPN;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DP._20160210.Tests.RPN
{
	[TestClass]
	public class RpnCalculatorTests
	{
		[TestMethod]
		public void Test_GetResult_OneNumber_NoOp()
		{
			var container = new UnityContainer();
			container.RegisterServices();
			var calculator = container.Resolve<IRpnCalculator>();

			// act
			RpnResult result = calculator.GetResult("1");

			// assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.CalculationResult.HasValue);
			Assert.IsTrue(!result.ErrorMessages.Any());
			Assert.AreEqual(result.CalculationResult.Value, 1);
		}

		[TestMethod]
		public void Test_GetResult_TwoIntegers_Subtract_Negative()
		{
			var container = new UnityContainer();
			container.RegisterServices();
			var calculator = container.Resolve<IRpnCalculator>();

			// act
			RpnResult result = calculator.GetResult("1 2 -");

			// assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.CalculationResult.HasValue);
			Assert.IsTrue(!result.ErrorMessages.Any());
			Assert.AreEqual(result.CalculationResult.Value, -1);
		}

		[TestMethod]
		public void Test_GetResult_TwoReals_Subtract_Positive()
		{
			var container = new UnityContainer();
			container.RegisterServices();
			var calculator = container.Resolve<IRpnCalculator>();

			// act
			RpnResult result = calculator.GetResult("44.5 2 -");

			// assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.CalculationResult.HasValue);
			Assert.IsTrue(!result.ErrorMessages.Any());
			Assert.AreEqual(result.CalculationResult.Value, (decimal)42.5);
		}

		[TestMethod]
		public void Test_GetResult_TwoIntegers_Add_Negative()
		{
			var container = new UnityContainer();
			container.RegisterServices();
			var calculator = container.Resolve<IRpnCalculator>();

			// act
			RpnResult result = calculator.GetResult("441 1441 +");

			// assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.CalculationResult.HasValue);
			Assert.IsTrue(!result.ErrorMessages.Any());
			Assert.AreEqual(result.CalculationResult.Value, 1882);
		}

		[TestMethod]
		public void Test_GetResult_TwoReals_Add_Positive()
		{
			var container = new UnityContainer();
			container.RegisterServices();
			var calculator = container.Resolve<IRpnCalculator>();

			// act
			RpnResult result = calculator.GetResult("-100 105 +");

			// assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.CalculationResult.HasValue);
			Assert.IsTrue(!result.ErrorMessages.Any());
			Assert.AreEqual(result.CalculationResult.Value, 5);
		}

		[TestMethod]
		public void Test_GetResult_TwoNumbers_Multiply_Negative()
		{
			var container = new UnityContainer();
			container.RegisterServices();
			var calculator = container.Resolve<IRpnCalculator>();

			// act
			RpnResult result = calculator.GetResult("-55 6 *");

			// assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.CalculationResult.HasValue);
			Assert.IsTrue(!result.ErrorMessages.Any());
			Assert.AreEqual(result.CalculationResult.Value, -330);
		}

		[TestMethod]
		public void Test_GetResult_TwoNumbers_Multiply_Positive()
		{
			var container = new UnityContainer();
			container.RegisterServices();
			var calculator = container.Resolve<IRpnCalculator>();

			// act
			RpnResult result = calculator.GetResult("5 6 *");

			// assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.CalculationResult.HasValue);
			Assert.IsTrue(!result.ErrorMessages.Any());
			Assert.AreEqual(result.CalculationResult.Value, 30);
		}

		[TestMethod]
		public void Test_GetResult_TwoNumbers_Divide_Negative()
		{
			var container = new UnityContainer();
			container.RegisterServices();
			var calculator = container.Resolve<IRpnCalculator>();

			// act
			RpnResult result = calculator.GetResult("-120.2 2 /");

			// assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.CalculationResult.HasValue);
			Assert.IsTrue(!result.ErrorMessages.Any());
			Assert.AreEqual(result.CalculationResult.Value, (decimal)-60.1);
		}

		[TestMethod]
		public void Test_GetResult_TwoNumbers_Divide_Positive()
		{
			var container = new UnityContainer();
			container.RegisterServices();
			var calculator = container.Resolve<IRpnCalculator>();

			// act
			RpnResult result = calculator.GetResult("21 3.5 /");

			// assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.CalculationResult.HasValue);
			Assert.IsTrue(!result.ErrorMessages.Any());
			Assert.AreEqual(result.CalculationResult.Value, 6);
		}

		[TestMethod]
		public void Test_GetResult_Mixed1()
		{
			var container = new UnityContainer();
			container.RegisterServices();
			var calculator = container.Resolve<IRpnCalculator>();

			// act
			RpnResult result = calculator.GetResult("5 1 2 + 4 * + 3 -");

			// assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.CalculationResult.HasValue);
			Assert.IsTrue(!result.ErrorMessages.Any());
			Assert.AreEqual(result.CalculationResult.Value, 14);
		}

		[TestMethod]
		public void Test_GetResult_Mixed2()
		{
			var container = new UnityContainer();
			container.RegisterServices();
			var calculator = container.Resolve<IRpnCalculator>();

			// act
			RpnResult result = calculator.GetResult("1 5 100 5 - * 9 - 10 + +");

			// assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.CalculationResult.HasValue);
			Assert.IsTrue(!result.ErrorMessages.Any());
			Assert.AreEqual(result.CalculationResult.Value, 477);
		}

		[TestMethod]
		public void Test_GetResult_NoOpFail()
		{
			var container = new UnityContainer();
			container.RegisterServices();
			var calculator = container.Resolve<IRpnCalculator>();

			// act
			RpnResult result = calculator.GetResult("5 1 2");

			// assert
			Assert.IsNotNull(result);
			Assert.IsFalse(result.CalculationResult.HasValue);
			Assert.IsTrue(result.ErrorMessages.Any());
			foreach (string message in result.ErrorMessages)
			{
				Assert.IsTrue(!string.IsNullOrWhiteSpace(message));
			}
		}

		[TestMethod]
		public void Test_GetResult_IncorrectTokenFail()
		{
			var container = new UnityContainer();
			container.RegisterServices();
			var calculator = container.Resolve<IRpnCalculator>();

			// act
			RpnResult result = calculator.GetResult("5 1 x");

			// assert
			Assert.IsNotNull(result);
			Assert.IsFalse(result.CalculationResult.HasValue);
			Assert.IsTrue(result.ErrorMessages.Any());
			foreach (string message in result.ErrorMessages)
			{
				Assert.IsTrue(!string.IsNullOrWhiteSpace(message));
			}
		}
	}
}
