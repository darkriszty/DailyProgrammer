using DP._20160210.BLL.IoC;
using DP._20160210.BLL.RPN;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DP._20160210.Tests.RPN
{
	[TestClass]
	public class RpnToParenthesisNotationConverterConverterTests
	{
		[TestMethod]
		public void Test_TryGetParenthesisNotation_Simple_Succeeds()
		{
			var container = new UnityContainer();
			container.RegisterServices();
			var converter = container.Resolve<IRpnToParenthesisNotationConverter>();

			// act
			string result;
			bool convertSucceeded = converter.TryGetParenthesisNotation("6 5 *", out result);

			// assert
			Assert.IsTrue(convertSucceeded);
			Assert.AreEqual(result, "6*5");
		}

		[TestMethod]
		public void Test_TryGetParenthesisNotation_Simple_MultiOp_Fails()
		{
			var container = new UnityContainer();
			container.RegisterServices();
			var converter = container.Resolve<IRpnToParenthesisNotationConverter>();

			// act
			string result;
			bool convertSucceeded = converter.TryGetParenthesisNotation("6 5 * +", out result);

			// assert
			Assert.IsFalse(convertSucceeded);
			Assert.IsNull(result);
		}

		[TestMethod]
		public void Test_TryGetParenthesisNotation_Simple_NoOp_Fails()
		{
			var container = new UnityContainer();
			container.RegisterServices();
			var converter = container.Resolve<IRpnToParenthesisNotationConverter>();

			// act
			string result;
			bool convertSucceeded = converter.TryGetParenthesisNotation("5 7", out result);

			// assert
			Assert.IsFalse(convertSucceeded);
			Assert.IsNull(result);
		}

		[TestMethod]
		public void Test_TryGetParenthesisNotation_Complex_Succeeds1()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var converter = container.Resolve<IRpnToParenthesisNotationConverter>();

			// act
			string result;
			bool convertSucceeded = converter.TryGetParenthesisNotation("2 1 100 10 10 * / + 2 -", out result);

			// assert
			Assert.IsTrue(convertSucceeded);
			Assert.AreEqual(result, "(1+((10*10)/100))-2");
		}

		[TestMethod]
		public void Test_TryGetParenthesisNotation_Complex_Succeeds2()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var converter = container.Resolve<IRpnToParenthesisNotationConverter>();

			// act
			string result;
			bool convertSucceeded = converter.TryGetParenthesisNotation("1 5 100 5 - * 9 - 10 + +", out result);

			// assert
			Assert.IsTrue(convertSucceeded);
			Assert.AreEqual(result, "1+((9-((100-5)*5))+10)");
		}
	}
}