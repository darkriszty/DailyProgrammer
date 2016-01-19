using System.Collections.Generic;
using System.Linq;
using DP._20160113.BLL.Strings;

namespace DP._20160113.BLL.Generations
{
	/// <summary>
	/// Responsible to generate new generations from old ones.
	/// </summary>
	public class GenerationBuilder
	{
		private readonly IStringDistanceCalculator _stringDistanceCalculator;
		private readonly IChildFactory _childFactory;

		public GenerationBuilder(IStringDistanceCalculator stringDistanceCalculator, IChildFactory childFactory)
		{
			_stringDistanceCalculator = stringDistanceCalculator;
			_childFactory = childFactory;
		}

		public Generation BuildNewGeneration(Generation oldGeneration, string expectedResult)
		{
			Generation result = new Generation();
			result.Offspring = new Person();

			// find the best 2 ancestors to create a new generation (this includes the parents)
			var allPossibleAncestors = new List<Person>();

			// include the ancestors of the last generation
			foreach (Person parent in oldGeneration.Ancestors)
			{
				if (allPossibleAncestors.All(a => a.Value != parent.Value))
				{
					allPossibleAncestors.Add(parent);
				}
			}
			// include the offspring of the last generation
			if (!string.IsNullOrWhiteSpace(oldGeneration.Offspring?.Value))
			{
				if (allPossibleAncestors.All(a => a.Value != oldGeneration.Offspring.Value))
				{
					allPossibleAncestors.Add(oldGeneration.Offspring);
				}
			}

			// order by fitness values in ascending order to take the best 2 ancestors, the rest are eliminated
			Person[] bestAncestors = allPossibleAncestors.OrderBy(d => d.Fitness).Take(2).ToArray();
			result.Ancestors.Add(bestAncestors[0]);
			result.Ancestors.Add(bestAncestors[1]);

			// create the child and evaluate its fitness
			result.Offspring.Value = _childFactory.GetNewChild(result.Ancestors);
			result.Offspring.Fitness = _stringDistanceCalculator.GetDistance(result.Offspring.Value, expectedResult);

			return result;
		}
	}
}