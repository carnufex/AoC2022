public class Day2
{
	private readonly string input = File.ReadAllText("input.txt");

	public int Part1()
	{
		return Parse.Sum(x => x.Score);
	}

	public int Part2()
	{
		return Parse.Sum(x => x.Score2);
	}

	private IEnumerable<Game> Parse =>
		from lines in input.Split("\r\n")
		let games = lines.Split(" ").Select(char.Parse).ToList()
		let game = new Game(games[0], games[1])
		select game;
}

class cls
{
	static public void Main(String[] args)
	{

		Day2 day2 = new Day2();
		Console.WriteLine($"Part 1: {day2.Part1()}");
		Console.WriteLine($"Part 2: {day2.Part2()}");
	}
}