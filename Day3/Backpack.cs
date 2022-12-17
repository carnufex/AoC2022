public class Backpack
{
	public string CompartmentOne { get; init; }
	public string CompartmentTwo { get; init; }

	public Backpack(string compartmentOne, string compartmentTwo)
	{
		CompartmentOne = compartmentOne;
		CompartmentTwo = compartmentTwo;
	}

	public int Calc()
	{
		HashSet<char> charSet = new HashSet<char>();
		int sum = 0;
		foreach (var letter in CompartmentOne)
		{
			if (CompartmentTwo.Contains(letter))
			{
				charSet.Add(letter);
			}
		}
		foreach (var item in charSet)
		{
			sum += ToPriority(item);
		}

		return sum;
	}

	public int ToPriority(char c)
	{
		if (char.IsUpper(c))
		{
			return (int)c - 64 + 26;
		}
		return (int)c - 96;
	}
}
