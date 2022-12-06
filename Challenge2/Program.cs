var input = await File.ReadAllLinesAsync("./Input.txt");
int pos = 0, depth = 0, aim = 0;
foreach (var move in input)
{
    var parts = move.Split(' ');
    switch (parts[0])
    {
        case "forward":
            pos += int.Parse(parts[1]);
            break;
        case "down":
            depth += int.Parse(parts[1]);
            break;
        case "up":
            depth -= int.Parse(parts[1]);
            break;
    }
}
Console.WriteLine($"Part 1 Product = {pos * depth}");

pos = depth = aim;
foreach (var move in input)
{
    var parts = move.Split(' ');
    switch (parts[0])
    {
        case "forward":
            pos += int.Parse(parts[1]);
            depth += int.Parse(parts[1]) * aim;
            break;
        case "down":
            aim += int.Parse(parts[1]);
            break;
        case "up":
            aim -= int.Parse(parts[1]);
            break;
    }
}
Console.WriteLine($"Part 2 Product = {pos * depth}");
