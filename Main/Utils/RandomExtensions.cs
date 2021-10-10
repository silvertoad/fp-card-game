using System;
using System.Collections.Generic;
using System.Linq;

namespace Main.Utils
{
	public static class RandomExtensions
	{
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random random)
		{
			return source.OrderBy(item => random.Next()).ToList();
		}

		public static T GetRandom<T>(IEnumerable<T> source, Random rnd)
		{
			var list = source.ToList();
			var index = rnd.Next(list.Count);
			return list[index];
		}
	}
}