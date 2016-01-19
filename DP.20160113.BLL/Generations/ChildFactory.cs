using System;
using System.Linq;
using System.Text;
using DP._20160113.BLL.Strings;

namespace DP._20160113.BLL.Generations
{
	/// <summary>
	/// Responsible to create new offsprings.
	/// </summary>
	public class ChildFactory : IChildFactory
	{
		private readonly IStringRandomizer _stringRandomizer;
		private readonly int _mutationCountPerGeneration;
		private readonly Random _random;

		public ChildFactory(IStringRandomizer stringRandomizer, int mutationCountPerGeneration)
		{
			_stringRandomizer = stringRandomizer;
			_mutationCountPerGeneration = mutationCountPerGeneration;

			_random = new Random();
		}

		/// <summary>
		/// Use the parents to generate a new child.
		/// </summary>
		/// <param name="ancestor">The previous generation</param>
		/// <returns>The new child</returns>
		public string GetNewChild(Ancestor ancestor)
		{

			if (!ancestor.Parents.Any())
			{
				throw new ArgumentException("Parents must exist to create offsprings!");
			}

			int length = ancestor.Parents.First().Length;
			if (ancestor.Parents.Any(parent => parent.Length != length))
			{
				throw new ArgumentException("Parents must be of the same length!");
			}

			// get the cut off point in the parents
			StringBuilder sb = new StringBuilder();
			int cutOffSize = length / ancestor.Parents.Count;

			int lastCutoffPoint = 0;
			IOrderedEnumerable<string> randomizedParents = ancestor.Parents.OrderBy(p => _random.Next());
			foreach (string parent in randomizedParents)
			{
				sb.Append(parent.Substring(lastCutoffPoint, cutOffSize));
				lastCutoffPoint += cutOffSize;
			}

			// make sure the required length is reached (int division)
			int missing = length - sb.Length;
			if (missing > 0)
			{
				// if not then copy from the beginning of the last parent
				string lastParent = randomizedParents.Last();
				sb.Append(lastParent.Substring(0, missing));
			}

			// now perform the mutation
			string result = _stringRandomizer.RandomizeCharacter(sb.ToString(), _mutationCountPerGeneration);

			return result;
		}
	}
}