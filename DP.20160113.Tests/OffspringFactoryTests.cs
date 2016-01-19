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
			var individFactory = container.Resolve<IndividFactory>();

			var parents = new List<Person>();
			parents.Add(individFactory.CreateIndividual("abcdef", "123456"));
			parents.Add(individFactory.CreateIndividual("ghijkl", "123456"));

			// act
			string offspring = offspringFactory.GetNewChild(parents);

			// assert
			Assert.IsNotNull(offspring);
			Assert.IsTrue(offspring.Length == parents[0].Value.Length);
			Assert.IsTrue(AreParents(offspring, parents, mutationCount), offspring);
		}

		[TestMethod]
		public void GetNewOffspring_TwoParentsOddLength_ExpectedOffspringWithOneMutation()
		{
			// arrange
			const int mutationCount = 1;
			var container = new UnityContainer();
			container.RegisterServices(mutationCount);
			var offspringFactory = container.Resolve<IChildFactory>();
			var individFactory = container.Resolve<IndividFactory>();

			var parents = new List<Person>();
			parents.Add(individFactory.CreateIndividual("abcde", "abcde"));
			parents.Add(individFactory.CreateIndividual("ghijk", "ghijk"));

			// act
			string offspring = offspringFactory.GetNewChild(parents);

			// assert
			Assert.IsNotNull(offspring);
			Assert.IsTrue(offspring.Length == parents[0].Value.Length);
			Assert.IsTrue(AreParents(offspring, parents, mutationCount), offspring);
		}

		[TestMethod]
		public void GetNewOffspring_TwoParentsEvenLength_ExpectedOffspringWithTwoMutations()
		{
			// arrange
			const int mutationCount = 2;
			var container = new UnityContainer();
			container.RegisterServices(mutationCount);
			var offspringFactory = container.Resolve<IChildFactory>();
			var individFactory = container.Resolve<IndividFactory>();

			var parents = new List<Person>();
			parents.Add(individFactory.CreateIndividual("qwer", "qwer"));
			parents.Add(individFactory.CreateIndividual("asdf", "asdf"));

			// act
			string offspring = offspringFactory.GetNewChild(parents);

			// assert
			Assert.IsNotNull(offspring);
			Assert.IsTrue(offspring.Length == parents[0].Value.Length);
			Assert.IsTrue(AreParents(offspring, parents, mutationCount), offspring);
		}

		[TestMethod]
		public void GetNewOffspring_TwoParentsOddLength_ExpectedOffspringWithTwoMutations()
		{
			// arrange
			const int mutationCount = 2;
			var container = new UnityContainer();
			container.RegisterServices(mutationCount);
			var offspringFactory = container.Resolve<IChildFactory>();
			var individFactory = container.Resolve<IndividFactory>();

			var parents = new List<Person>();
			parents.Add(individFactory.CreateIndividual("a", "a"));
			parents.Add(individFactory.CreateIndividual("b", "b"));

			// act
			string offspring = offspringFactory.GetNewChild(parents);

			// assert
			Assert.IsNotNull(offspring);
			Assert.IsTrue(offspring.Length == parents[0].Value.Length);
			Assert.IsTrue(AreParents(offspring, parents, mutationCount), offspring);
		}

		[TestMethod]
		public void GetNewOffspring_ThreeParentsEvenLength_ExpectedOffspringWithOneMutation()
		{
			// arrange
			const int mutationCount = 1;
			var container = new UnityContainer();
			container.RegisterServices(mutationCount);
			var offspringFactory = container.Resolve<IChildFactory>();
			var individFactory = container.Resolve<IndividFactory>();

			var parents = new List<Person>();
			parents.Add(individFactory.CreateIndividual("abcdef", "abcdef"));
			parents.Add(individFactory.CreateIndividual("ghijkl", "ghijkl"));
			parents.Add(individFactory.CreateIndividual("mnopqr", "mnopqr"));
			

			// act
			string offspring = offspringFactory.GetNewChild(parents);

			// assert
			Assert.IsNotNull(offspring);
			Assert.IsTrue(offspring.Length == parents[0].Value.Length);
			Assert.IsTrue(AreParents(offspring, parents, mutationCount), offspring);
		}

		[TestMethod]
		public void GetNewOffspring_ThreeParentsOddLength_ExpectedOffspringWithOneMutation()
		{
			// arrange
			const int mutationCount = 1;
			var container = new UnityContainer();
			container.RegisterServices(mutationCount);
			var offspringFactory = container.Resolve<IChildFactory>();
			var individFactory = container.Resolve<IndividFactory>();

			var parents = new List<Person>();
			parents.Add(individFactory.CreateIndividual("abcde", "abcde"));
			parents.Add(individFactory.CreateIndividual("ghijk", "ghijk"));
			parents.Add(individFactory.CreateIndividual("mnopq", "mnopq"));


			// act
			string offspring = offspringFactory.GetNewChild(parents);

			// assert
			Assert.IsNotNull(offspring);
			Assert.IsTrue(offspring.Length == parents[0].Value.Length);
			Assert.IsTrue(AreParents(offspring, parents, mutationCount), offspring);
		}

		private bool AreParents(string offspring, List<Person> parents, int mutationCount)
		{
			int foundMutationCount = 0;
			char[] offspringChars = offspring.ToCharArray();

			foreach (char c in offspringChars)
			{
				bool parentCharFound = parents.Any(p => p.Value.Contains(c));

				if (!parentCharFound)
					foundMutationCount++;

				if (foundMutationCount > mutationCount)
					break;
			}

			return foundMutationCount <= mutationCount;
		}
	}
}
