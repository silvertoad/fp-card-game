using System;
using System.Collections.Generic;
using System.Linq;
using Main.Model;
using Main.Utils;
using static Main.Utils.RandomExtensions;

namespace Main
{
	public static class GameGenerator
	{
		public static Game CreateGame(Random random)
		{
			return GetSuits()
				.Map(random, (suites, rand) =>
					new Game(GenerateDeck(suites), GetRandom(suites, rand)));
		}

		private static IEnumerable<Card> GenerateDeck(IEnumerable<Suites> suites)
		{
			return Range(2, 14).Select(value =>
					suites.Select(suite => new Card(value, suite)))
				.SelectMany(m => m);
		}

		private static IEnumerable<uint> Range(uint start, uint end)
		{
			for (uint i = start; i <= end; i++)
			{
				yield return i;
			}
		}

		private static Suites[] GetSuits()
		{
			return Enum.GetValues<Suites>();
		}
	}
}