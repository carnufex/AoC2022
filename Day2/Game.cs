public class Game
{
	public int Score { get; init; }
	public int Score2 { get; init; }

	public Game(char opponentPlay, char myMove)
	{
		Score = CalculateScore(opponentPlay, myMove);
		Score2 = CalculateScorePart2(opponentPlay, myMove);
	}

	private int CalculateScorePart2(char oppenentPlays, char myMove)
	{
		int opp = ToValuePart2(oppenentPlays);
		int turnPoint = ToValuePart2(myMove);

		int playChoice = CheckWinPart2(opp, turnPoint);

		return playChoice + turnPoint;
	}

	private int CheckWinPart2(int opponentPlays, int outcome) => opponentPlays switch
	{
		1 when outcome == 0 => 3,
		1 when outcome == 3 => 1,
		1 when outcome == 6 => 2,

		2 when outcome == 0 => 1,
		2 when outcome == 3 => 2,
		2 when outcome == 6 => 3,

		3 when outcome == 0 => 2,
		3 when outcome == 3 => 3,
		3 when outcome == 6 => 1,

		_ => throw new ArgumentOutOfRangeException(nameof(opponentPlays), $"Not expected char  value: {opponentPlays}"),
	};


	private static int ToValuePart2(char chr) => chr switch
	{
		'A' => 1,
		'B' => 2,
		'C' => 3,
		'X' => 0,
		'Y' => 3,
		'Z' => 6,
		_ => throw new ArgumentOutOfRangeException(nameof(chr), $"Not expected char  value: {chr}"),
	};

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
