public class Game
{
	public int Score { get; init; }

	public Game(char opponentPlay, char myMove)
	{
		Score = CalculateScore(opponentPlay, myMove);
	}

	private int CalculateScore(char oppenentPlays, char myMove)
	{
		int opp = ToValue(oppenentPlays);
		int me = ToValue(myMove);

		int turnPoints = CheckWin(opp, me);

		return turnPoints + me;
	}

	private int CheckWin(int opponentPlays, int myMove) => myMove switch
	{
		// Sten
		1 when opponentPlays == myMove => 3,
		1 when opponentPlays == 2 => 0,
		1 when opponentPlays == 3 => 6,

		// Påse
		2 when opponentPlays == myMove => 3,
		2 when opponentPlays == 1 => 6,
		2 when opponentPlays == 3 => 0,

		// Sax
		3 when opponentPlays == myMove => 3,
		3 when opponentPlays == 1 => 0,
		3 when opponentPlays == 2 => 6,

		_ => throw new ArgumentOutOfRangeException(nameof(opponentPlays), $"Not expected char  value: {opponentPlays}"),
	};


	private static int ToValue(char chr) => chr switch
	{
		'A' or 'X' => 1,
		'B' or 'Y' => 2,
		'C' or 'Z' => 3,
		_ => throw new ArgumentOutOfRangeException(nameof(chr), $"Not expected char  value: {chr}"),
	};
}
