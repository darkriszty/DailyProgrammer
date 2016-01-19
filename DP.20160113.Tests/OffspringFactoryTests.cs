using System.Collections.Generic;
using System.Linq;
using DP._20160113.BLL.Generations;
using DP._20160113.BLL.IoC;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DP._20160113.Tests
{
	[TestClass]
	public class OffspringFactoryTests
	{
		[TestMethod]
		public void GetNewOffspring_TwoParentsEvenLength_ExpectedOffspringWithOneMutation()
		{
			// arrange
			const int mutationCount = 1;
			var container = new UnityContainer();
			container.RegisterServices(mutationCount);
			var offspringFactory = container.Resolve<IChildFactory>();
			Ancestor g1 = new Ancestor();
			g1.Parents.AddRange(new List<string>
			{
				"abcdef",
				"ghijkl"
			});

			// act
			string offspring = offspringFactory.GetNewChild(g1);

			// assert
			Assert.IsNotNull(offspring);
			Assert.IsTrue(offspring.Length == g1.Parents[0].Length);
			Assert.IsTrue(AreParents(offspring, g1.Parents, mutationCount), offspring);
		}

		[TestMethod]
		public void GetNewOffspring_TwoParentsOddLength_ExpectedOffspringWithOneMutation()
		{
			// arrange
			const int mutationCount = 1;
			var container = new UnityContainer();
			container.RegisterServices(mutationCount);
			var offspringFactory = container.Resolve<IChildFactory>();
			Ancestor g1 = new Ancestor();
			g1.Parents.AddRange(new List<string>
			{
				"abcde",
				"ghijk"
			});

			// act
			string offspring = offspringFactory.GetNewChild(g1);

			// assert
			Assert.IsNotNull(offspring);
			Assert.IsTrue(offspring.Length == g1.Parents[0].Length);
			Assert.IsTrue(AreParents(offspring, g1.Parents, mutationCount), offspring);
		}

		[TestMethod]
		public void GetNewOffspring_TwoParentsEvenLength_ExpectedOffspringWithTwoMutations()
		{
			// arrange
			const int mutationCount = 2;
			var container = new UnityContainer();
			container.RegisterServices(mutationCount);
			var offspringFactory = container.Resolve<IChildFactory>();
			Ancestor g1 = new Ancestor();
			g1.Parents.AddRange(new List<string>
			{
				"qwer",
				"asdf"
			});

			// act
			string offspring = offspringFactory.GetNewChild(g1);

			// assert
			Assert.IsNotNull(offspring);
			Assert.IsTrue(offspring.Length == g1.Parents[0].Length);
			Assert.IsTrue(AreParents(offspring, g1.Parents, mutationCount), offspring);
		}

		[TestMethod]
		public void GetNewOffspring_TwoParentsOddLength_ExpectedOffspringWithTwoMutations()
		{
			// arrange
			const int mutationCount = 2;
			var container = new UnityContainer();
			container.RegisterServices(mutationCount);
			var offspringFactory = container.Resolve<IChildFactory>();
			Ancestor g1 = new Ancestor();
			g1.Parents.AddRange(new List<string>
			{
				"a",
				"b"
			});

			// act
			string offspring = offspringFactory.GetNewChild(g1);

			// assert
			Assert.IsNotNull(offspring);
			Assert.IsTrue(offspring.Length == g1.Parents[0].Length);
			Assert.IsTrue(AreParents(offspring, g1.Parents, mutationCount));
		}

		[TestMethod]
		public void GetNewOffspring_ThreeParentsEvenLength_ExpectedOffspringWithOneMutation()
		{
			// arrange
			const int mutationCount = 1;
			var container = new UnityContainer();
			container.RegisterServices(mutationCount);
			var offspringFactory = container.Resolve<IChildFactory>();
			Ancestor g1 = new Ancestor();
			g1.Parents.AddRange(new List<string>
			{
				"abcdef",
				"ghijkl",
				"mnopqr"
			});

			// act
			string offspring = offspringFactory.GetNewChild(g1);

			// assert
			Assert.IsNotNull(offspring);
			Assert.IsTrue(offspring.Length == g1.Parents[0].Length);
			Assert.IsTrue(AreParents(offspring, g1.Parents, mutationCount), offspring);
		}

		[TestMethod]
		public void GetNewOffspring_ThreeParentsOddLength_ExpectedOffspringWithOneMutation()
		{
			// arrange
			const int mutationCount = 1;
			var container = new UnityContainer();
			container.RegisterServices(mutationCount);
			var offspringFactory = container.Resolve<IChildFactory>();
			Ancestor g1 = new Ancestor();
			g1.Parents.AddRange(new List<string>
			{
				"abcde",
				"ghijk",
				"mnopq"
			});

			// act
			string offspring = offspringFactory.GetNewChild(g1);

			// assert
			Assert.IsNotNull(offspring);
			Assert.IsTrue(offspring.Length == g1.Parents[0].Length);
			Assert.IsTrue(AreParents(offspring, g1.Parents, mutationCount), offspring);
		}

		private bool AreParents(string offspring, List<string> parents, int mutationCount)
		{
			int foundMutationCount = 0;
			char[] offspringChars = offspring.ToCharArray();

			foreach (char c in offspringChars)
			{
				bool parentCharFound = parents.Any(p => p.Contains(c));

				if (!parentCharFound)
					foundMutationCount++;

				if (foundMutationCount > mutationCount)
					break;
			}

			return foundMutationCount <= mutationCount;
		}
	}
}
