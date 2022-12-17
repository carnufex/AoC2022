using MoreLinq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public class Day3
{
	private readonly string input = File.ReadAllText("input.txt");
	public Day3()
	{

	}

	public IEnumerable<int> Priorities =>
		from lines in input.Split("\r\n")
		let backpack = new Backpack(lines[..(lines.Length / 2)], lines[(lines.Length / 2)..])
		let priorities = backpack.Calc()
		select priorities;

	public int Part1()
	{
		return Priorities.Sum();
	}

	public IEnumerable<IEnumerable<IEnumerable<string>>> Groups =>
		from lines in input.Split("\r\n").Batch(3)
		let elves = lines.Split("\r\n")
		select elves;

	public int Part2()
	{
		int res = 0;

		foreach (var group in Groups)
		{
			// bah, just make it work
			var elfOne = group.First().Take(1).First();
			var elfTwo = group.First().Slice(1, 1).First();
			var elfThree = group.First().Slice(2,2).First();

			foreach (var letter in elfOne)
			{
				if (elfTwo.Contains(letter) && elfThree.Contains(letter))
				{
					res += ToPriority(letter);
					break;
				}
			}
		}

		return res;
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

class cls
{
	static public void Main(String[] args)
	{

		Day3 day3 = new Day3();
		Console.WriteLine($"Part 1: {day3.Part1()}");
		Console.WriteLine($"Part 2: {day3.Part2()}");
	}
}