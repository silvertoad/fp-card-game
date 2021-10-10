namespace Main.Model
{
	public readonly struct Card
	{
		public readonly CardPrice Price;
		public readonly Suites Suite;

		public Card(CardPrice price, Suites suite)
		{
			Price = price;
			Suite = suite;
		}
	}
}