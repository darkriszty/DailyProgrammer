using System;
using DP._20160113.BLL;
using DP._20160113.BLL.IoC;
using DP._20160113.BLL.Strings;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DP._20160113.Tests
{
	[TestClass]
	public class CharDistanceCalculatorTests
	{
		[TestMethod]
		public void GetDistance_SingleChange_Expected1()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices(AppSettings.MutationCountPerGeneration);
			var charDistanceCalculator = container.Resolve<IStringDistanceCalculator>();

			string s1 = "ABC";
			string s2 = "ABD";

			// act
			int distance = charDistanceCalculator.GetDistance(s1, s2);

			// assert
			Assert.AreEqual(distance, 1);
		}

		[TestMethod]
		public void GetDistance_TwoChanges_Expected2()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices(AppSettings.MutationCountPerGeneration);
			var charDistanceCalculator = container.Resolve<IStringDistanceCalculator>();

			string s1 = "ABC";
			string s2 = "ACD";

			// act
			int distance = charDistanceCalculator.GetDistance(s1, s2);

			// assert
			Assert.AreEqual(distance, 2);
		}

		[TestMethod]
		public void GetDistance_ThreeChanges_Expected3()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices(AppSettings.MutationCountPerGeneration);
			var charDistanceCalculator = container.Resolve<IStringDistanceCalculator>();

			string s1 = "ABC";
			string s2 = "BCD";

			// act
			int distance = charDistanceCalculator.GetDistance(s1, s2);

			// assert
			Assert.AreEqual(distance, 3);
		}

		[TestMethod]
		public void GetDistance_Reverse_Expected4()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices(AppSettings.MutationCountPerGeneration);
			var charDistanceCalculator = container.Resolve<IStringDistanceCalculator>();

			string s1 = "ABC";
			string s2 = "CBA";

			// act
			int distance = charDistanceCalculator.GetDistance(s1, s2);

			// assert
			Assert.AreEqual(distance, 4);
		}

		[TestMethod]
		public void GetDistance_Matching_Expected0()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices(AppSettings.MutationCountPerGeneration);
			var charDistanceCalculator = container.Resolve<IStringDistanceCalculator>();

			string s1 = "ABCDEF";
			string s2 = "ABCDEF";

			// act
			int distance = charDistanceCalculator.GetDistance(s1, s2);

			// assert
			Assert.AreEqual(distance, 0);
		}


		[TestMethod]
		[ExpectedException(typeof(ArgumentException), "Only same-length strings are allowed.")]
		public void GetDistance_IncorrectInput_ExpectedException()
		{
			// arrange
			var container = new UnityContainer();
			container.RegisterServices(AppSettings.MutationCountPerGeneration);
			var charDistanceCalculator = container.Resolve<IStringDistanceCalculator>();

			string s1 = "ABC";
			string s2 = "ABCDEF";

			// act
			charDistanceCalculator.GetDistance(s1, s2);

			// assert
			// (exception expected)
		}
	}
}
