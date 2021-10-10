using System;
using Main.Model;
using static System.Console;

namespace Main
{
	public static class GameView
	{
		public static readonly Action<Suites> TraceTrump = delegate(Suites trump)
		{
			WriteLine($"The trump is {trump}");
		};

		public static readonly Action<Winner, Card, Card> TraceTurn = delegate(Winner winner, Card c1, Card c2)
		{
			string TraceCard(Card c) => $"{c.Price} of {c.Suite}";

			WriteLine($"{winner} wins:\tP1 has {TraceCard(c1)}, P2 has {TraceCard(c2)}.");
		};

		public static readonly Action<Winner> TraceWinner = delegate(Winner winner)
		{
			WriteLine($"The winner is: {winner}");
		};
	}
}