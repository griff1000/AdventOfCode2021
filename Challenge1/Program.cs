var input = await File.ReadAllLinesAsync("./Input.txt");
var intInput = input.Select(int.Parse).ToArray();
// Part 1:
var basicIncreaseCount = intInput.Where((reading, index) =>
{
    if (index == 0) return false;
    return reading > intInput[index - 1];
}).Count();

Console.WriteLine($"Part 2 answer: {basicIncreaseCount}");

// Part 2:
var increaseCount = 0;
for (var i = 4; i <= intInput.Length; i++)
{
    var firstWindow = intInput[(i-4)..(i-1)];
    var secondWindow = intInput[(i-3)..i];
    if (secondWindow.Sum() > firstWindow.Sum()) increaseCount++;
}
Console.WriteLine($"Part 2 answer: {increaseCount}");

