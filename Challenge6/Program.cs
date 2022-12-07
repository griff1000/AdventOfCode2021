using Challenge6;

var input = await File.ReadAllTextAsync("./Input.txt");

var lanternFish = input.Split(',').Select(int.Parse).Select(i => new LanternFish(i)).ToList();

for (var day = 0; day < 80; day++)
{
    var newFish = new List<LanternFish>();
    foreach (var fish in lanternFish)
    {
        var fishToAdd = fish.Age();
        if (fishToAdd is not null) newFish.Add(fishToAdd);
    }
    lanternFish.AddRange(newFish);
}

Console.WriteLine($"There are now {lanternFish.Count} fish");
