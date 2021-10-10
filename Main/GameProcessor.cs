using System;
using System.Collections.Generic;
using System.Linq;
using Main.Model;

namespace Main
{
	public static class GameProcessor
	{
		public static Players SplitCards(this IEnumerable<Card> allCards)
		{
			var grouped = allCards
				.Select<Card, (Card card, bool group)>((c, i) => (c, i % 2 > 0))
				.GroupBy((c) => c.group, c => c.card)
				.ToList();
			return new Players(grouped.First(), grouped.Last());
		}

		public static IEnumerable<Winner> ProcessGame(
			this Players players,
			Func<Card, Card, Winner> makeTurn)
		{
			return players.Player1.Zip(players.Player2, makeTurn);
		}

		public static Winner GetTurnWinner(Card p1, Card p2, Suites trump)
		{
			return (p1, p2) switch
			{
				ValueTuple<Card, Card>(var p1Card, var p2Card) when p1Card.Suite == p2Card.Suite => CompareRank(
					p1.Price, p2.Price),
				ValueTuple<Card, Card>(var p1Card, _) when p1Card.Suite == trump => Winner.P1,
				ValueTuple<Card, Card>(_, var p2Card) when p2Card.Suite == trump => Winner.P2,
				_ => CompareRank(p1.Price, p2.Price)
			};
		}

		public static Winner GetGameWinner(this IEnumerable<Winner> results)
		{
			return GetWinner(CountCards(results));
		}

		private static Winner CompareRank(CardPrice p1, CardPrice p2)
		{
			return GetWinner(p1.CompareTo(p2));
		}

		private static Winner GetWinner(int result)
		{
			return result switch
			{
				> 0 => Winner.P1,
				< 0 => Winner.P2,
				_ => Winner.Both
			};
		}

		private static int CountCards(IEnumerable<Winner> results)
		{
			return results.Aggregate(0, (result, winner) =>
			{
				return result + winner switch
				{
					Winner.P1 => 1,
					Winner.P2 => -1,
					_ => 0
				};
			});
		}
	}
}