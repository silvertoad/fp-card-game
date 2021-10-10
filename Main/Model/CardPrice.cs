using System;

namespace Main.Model
{
	public readonly struct CardPrice : IComparable<CardPrice>
	{
		private readonly long _value;

		private CardPrice(uint value)
		{
			_value = value;
		}

		public static implicit operator CardPrice(uint price) => new(price);

		public int CompareTo(CardPrice other)
		{
			return _value.CompareTo(other._value);
		}

		public override string ToString()
		{
			return _value switch
			{
				11 => "Jack",
				12 => "Queen",
				13 => "King",
				14 => "Ace",
				_ => _value.ToString()
			};
		}
	}
}