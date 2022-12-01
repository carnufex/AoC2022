// See https://aka.ms/new-console-template for more information
using System.Linq;
using System.Collections.Generic;


public class Day1
{
	private string input;
	public Day1()
	{
		input = File.ReadAllText("input.txt");
	}

	public int Part1()
	{
		return AvailableCalories(input).First();
	}

	public int Part2()
	{
		return AvailableCalories(input).Take(3).Sum();
	}

	private IEnumerable<int> AvailableCalories(string input) =>
		from section in input.Split("\r\n\r\n")
		let calorieSum = section.Split("\r\n").Select(int.Parse).Sum()
		orderby calorieSum descending
		select calorieSum;
}


class cls
{
	static public void Main(String[] args)
	{

		Day1 day1 = new Day1();
		Console.WriteLine($"Part 1: {day1.Part1()}");
		Console.WriteLine($"Part 2: {day1.Part2()}");
	}
}