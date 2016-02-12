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
		public void Test_GetTokenType()
		{
			//TODO
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
