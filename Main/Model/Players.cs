using System.Collections.Generic;

namespace Main.Model
{
	public readonly struct Players
	{
		public readonly IEnumerable<Card> Player1;
		public readonly IEnumerable<Card> Player2;

		public Players(IEnumerable<Card> player1, IEnumerable<Card> player2)
		{
			Player1 = player1;
			Player2 = player2;
		}
	}
}