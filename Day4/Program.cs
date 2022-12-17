using System.Security.Cryptography.X509Certificates;

public class Day4
{
	private readonly string input = File.ReadAllText("input.txt");

	public int Part1()
	{
		return Parse.Count<bool>(t => t);
	}

	public IEnumerable<bool> Parse =>
		from lines in input.Split("\r\n")
		let section = new Section(lines).IsSubset()
		select section;
}

public class Section
{
	public HashSet<int> SectionOne { get; set; }
	public HashSet<int> SectionTwo { get; set; }

	public Section(string line)
	{
		string[] lineParts = line.Split(",");
		SectionTwo = Populate(lineParts.First());
		SectionOne = Populate(lineParts.Last());
	}

	private HashSet<int>? Populate(string input)
	{
		var range = input.Split("-");
		var start =int.Parse(range.First());
		var end = int.Parse(range.Last());

		HashSet<int> res = new();

		for (int i = start; i <= end; i++)
		{
			res.Add(i);
		}

		return res;
	}

	public bool IsSubset()
	{
		if (SectionOne.IsSubsetOf(SectionTwo) || SectionTwo.IsSubsetOf(SectionOne))
		{
			return true;
		}

		return false;
	}
}

class cls
{
	static public void Main(String[] args)
	{
		Day4 day = new Day4();
		Console.WriteLine($"Part 1: {day.Part1()}");
		//Console.WriteLine($"Part 2: {day3.Part2()}");
	}
}