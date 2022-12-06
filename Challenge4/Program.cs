using Challenge4;

var input = await File.ReadAllLinesAsync("./Input.txt");

var game = new Game(input[2..]);
var numbersCalled = input[0].Split(',');

var winners = new List<(int Number, Board Board)>();
foreach (var numberAsString in numbersCalled)
{
    var number = int.Parse(numberAsString);
    var winningBoards = game.CallNumber(number);
    winners.AddRange(winningBoards.Select(winningBoard => (number, winningBoard)));
}

Console.WriteLine($"First Bingo on number {winners.First().Number}; score is {winners.First().Number * winners.First().Board.CalculateScore()}");
Console.WriteLine($"Last Bingo on number {winners.Last().Number}; score is {winners.Last().Number * winners.Last().Board.CalculateScore()}");

