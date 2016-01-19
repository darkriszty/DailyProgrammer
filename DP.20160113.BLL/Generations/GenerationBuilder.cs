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
			result.Ancestors = new Ancestor();
			result.Offspring = new Offspring();

			// find the best 2 ancestors to create a new generation (this includes the parents)
			Dictionary <string, int> allPossibleAncestors = new Dictionary<string, int>();

			// include the ancestors of the last generation
			foreach (string parent in oldGeneration.Ancestors.Parents)
			{
				if (!allPossibleAncestors.ContainsKey(parent))
				{
					allPossibleAncestors[parent] = _stringDistanceCalculator.GetDistance(parent, expectedResult);
				}
			}
			// include the offspring of the last generation
			if (!string.IsNullOrWhiteSpace(oldGeneration.Offspring?.Child))
			{
				if (!allPossibleAncestors.ContainsKey(oldGeneration.Offspring.Child))
				{
					allPossibleAncestors[oldGeneration.Offspring.Child] = _stringDistanceCalculator.GetDistance(oldGeneration.Offspring.Child, expectedResult);
				}
			}

			// order by fitness values in ascending order to take the best 2 ancestors, the rest are eliminated
			var bestAncestors = allPossibleAncestors.OrderBy(d => d.Value).Take(2).ToArray();
			result.Ancestors.Parents.Add(bestAncestors[0].Key);
			result.Ancestors.Parents.Add(bestAncestors[1].Key);

			// create the child and evaluate its fitness
			result.Offspring.Child = _childFactory.GetNewChild(result.Ancestors);
			result.Offspring.Fitness = _stringDistanceCalculator.GetDistance(result.Offspring.Child, expectedResult);

			return result;
		}
	}
}