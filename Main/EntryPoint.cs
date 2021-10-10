using System;
using Main.Utils;
using static Main.GameGenerator;
using static Main.GameProcessor;
using static Main.GameView;

namespace Main
{
	public static class EntryPoint
	{
		public static void Main()
		{
			var random = new Random(0);
			CreateGame(random)
				.Passthrough(game => TraceTrump(game.Trump))
				.Map(random, (game, rand) => game.Deck
					.Shuffle(rand)
					.SplitCards()
					.ProcessGame((c1, c2)
						=> GetTurnWinner(c1, c2, game.Trump)
							.Passthrough(winner => TraceTurn(winner, c1, c2))))
				.GetGameWinner()
				.Passthrough(TraceWinner);
		}
	}
}