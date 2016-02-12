using DP._20160210.BLL.IoC;
using DP._20160210.BLL.RPN;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DP._20160210.Tests.RPN
{
	[TestClass]
	public class TokenInfoProviderTests
	{
		[TestMethod]
		public void Test_GetTokenType_PositiveIntegerValue()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var tokenInfoProvider = container.Resolve<ITokenInfoProvider>();

			// act
			TokenType tokenType = tokenInfoProvider.GetTokenType("4");

			// assert
			Assert.AreEqual(tokenType, TokenType.Value);
		}

		[TestMethod]
		public void Test_GetTokenType_NegativeIntegerValue()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var tokenInfoProvider = container.Resolve<ITokenInfoProvider>();

			// act
			TokenType tokenType = tokenInfoProvider.GetTokenType("-529");

			// assert
			Assert.AreEqual(tokenType, TokenType.Value);
		}

		[TestMethod]
		public void Test_GetTokenType_PositiveRealValue()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var tokenInfoProvider = container.Resolve<ITokenInfoProvider>();

			// act
			TokenType tokenType = tokenInfoProvider.GetTokenType("9.617");

			// assert
			Assert.AreEqual(tokenType, TokenType.Value);
		}

		[TestMethod]
		public void Test_GetTokenType_NegativeRealValue()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var tokenInfoProvider = container.Resolve<ITokenInfoProvider>();

			// act
			TokenType tokenType = tokenInfoProvider.GetTokenType("-74539.27405");

			// assert
			Assert.AreEqual(tokenType, TokenType.Value);
		}

		[TestMethod]
		public void Test_GetTokenType_Operator1()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var tokenInfoProvider = container.Resolve<ITokenInfoProvider>();

			// act
			TokenType tokenType = tokenInfoProvider.GetTokenType("+");

			// assert
			Assert.AreEqual(tokenType, TokenType.Operator);
		}

		[TestMethod]
		public void Test_GetTokenType_Operator2()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var tokenInfoProvider = container.Resolve<ITokenInfoProvider>();

			// act
			TokenType tokenType = tokenInfoProvider.GetTokenType("-");

			// assert
			Assert.AreEqual(tokenType, TokenType.Operator);
		}

		[TestMethod]
		public void Test_GetTokenType_Operator3()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var tokenInfoProvider = container.Resolve<ITokenInfoProvider>();

			// act
			TokenType tokenType = tokenInfoProvider.GetTokenType("*");

			// assert
			Assert.AreEqual(tokenType, TokenType.Operator);
		}

		[TestMethod]
		public void Test_GetTokenType_Operator4()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var tokenInfoProvider = container.Resolve<ITokenInfoProvider>();

			// act
			TokenType tokenType = tokenInfoProvider.GetTokenType("/");

			// assert
			Assert.AreEqual(tokenType, TokenType.Operator);
		}

		[TestMethod]
		public void Test_GetTokenType_Unkown1()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var tokenInfoProvider = container.Resolve<ITokenInfoProvider>();

			// act
			TokenType tokenType = tokenInfoProvider.GetTokenType("x");

			// assert
			Assert.AreEqual(tokenType, TokenType.Unkown);
		}

		[TestMethod]
		public void Test_GetTokenType_Unkown2()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var tokenInfoProvider = container.Resolve<ITokenInfoProvider>();

			// act
			TokenType tokenType = tokenInfoProvider.GetTokenType("15*");

			// assert
			Assert.AreEqual(tokenType, TokenType.Unkown);
		}

		[TestMethod]
		public void Test_GetOperationType_Addition()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var tokenInfoProvider = container.Resolve<ITokenInfoProvider>();

			// act
			OperationType operationType = tokenInfoProvider.GetOperationType('+');

			// assert
			Assert.AreEqual(operationType, OperationType.Addition);
		}

		[TestMethod]
		public void Test_GetOperationType_Subtraction()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var tokenInfoProvider = container.Resolve<ITokenInfoProvider>();

			// act
			OperationType operationType = tokenInfoProvider.GetOperationType('-');

			// assert
			Assert.AreEqual(operationType, OperationType.Subtraction);
		}

		[TestMethod]
		public void Test_GetOperationType_Multiplication()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var tokenInfoProvider = container.Resolve<ITokenInfoProvider>();

			// act
			OperationType operationType = tokenInfoProvider.GetOperationType('*');

			// assert
			Assert.AreEqual(operationType, OperationType.Multiplication);
		}

		[TestMethod]
		public void Test_GetOperationType_Division()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var tokenInfoProvider = container.Resolve<ITokenInfoProvider>();

			// act
			OperationType operationType = tokenInfoProvider.GetOperationType('/');

			// assert
			Assert.AreEqual(operationType, OperationType.Division);
		}

		[TestMethod]
		public void Test_GetOperationType_Unkown1()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var tokenInfoProvider = container.Resolve<ITokenInfoProvider>();

			// act
			OperationType operationType = tokenInfoProvider.GetOperationType('x');

			// assert
			Assert.AreEqual(operationType, OperationType.Unkown);
		}

		[TestMethod]
		public void Test_GetOperationType_Unkown2()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices();
			var tokenInfoProvider = container.Resolve<ITokenInfoProvider>();

			// act
			OperationType operationType = tokenInfoProvider.GetOperationType('8');

			// assert
			Assert.AreEqual(operationType, OperationType.Unkown);
		}
	}
}
