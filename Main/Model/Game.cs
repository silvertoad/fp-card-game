using System.Collections.Generic;

namespace Main.Model
{
	public readonly struct Game
	{
		public readonly IEnumerable<Card> Deck;
		public readonly Suites Trump;

		public Game(IEnumerable<Card> deck, Suites trump)
		{
			Deck = deck;
			Trump = trump;
		}
	}
}