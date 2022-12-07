using Challenge5;

var input = await File.ReadAllLinesAsync("./Input.txt");

var seaFloor = new SeaFloor();
var coordinates = input.Select(i => new Coordinates(i));
foreach (var coordinate in coordinates)
{
    seaFloor.Process(coordinate);
}

Console.WriteLine($"Number of overlapping points = {seaFloor.CountOverlaps(2)}");
