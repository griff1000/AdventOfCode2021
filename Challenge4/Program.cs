using Challenge4;

var input = await File.ReadAllLinesAsync("./Input.txt");

var game = new Game(input[2..]);

#region identify the first and last winners

var firstWinnerFound = false;
(int Number, Board Board) lastWinner = default;

#endregion

foreach (var number in input[0].Split(',').Select(int.Parse))
{
    var winningBoards = game.CallNumber(number).ToArray();

    #region identify the first and last winners

    if (!firstWinnerFound && winningBoards.Any())
    {
        firstWinnerFound = true;
        Console.WriteLine($"First Bingo score is {number * winningBoards.First().CalculateScore()}");
    }
    if (winningBoards.Any()) lastWinner = (number, winningBoards.Last());

    #endregion
}

Console.WriteLine($"Last Bingo score is {lastWinner.Number * lastWinner.Board!.CalculateScore()}");

