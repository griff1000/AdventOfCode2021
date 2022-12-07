using Challenge6;

var input = await File.ReadAllTextAsync("./Input.txt");

#region Slow way which ran out of steam long before 256 iterations

// This worked for the first part with just 80 iterations but quickly ran out of puff
// as the number of iterations grew
//var lanternFish = input.Split(',').Select(int.Parse).Select(i => new LanternFish(i)).ToList();

//for (var day = 0; day < 80; day++)
//{
//    var newFish = new List<LanternFish>();
//    foreach (var fish in lanternFish)
//    {
//        var fishToAdd = fish.Age();
//        if (fishToAdd is not null) newFish.Add(fishToAdd);
//    }
//    lanternFish.AddRange(newFish);
//}

//Console.WriteLine($"There are now {lanternFish.Count} fish");

#endregion

#region Much more scalable way

// This is much more performant - it doesn't create new fish, it just keeps a count of fish
// for each day of the timer

var lanternFishShoal = new LanternFishShoal();
input.Split(',').Select(int.Parse).ToList().ForEach(lanternFishShoal.AddFish);
Enumerable.Range(0, 256).ToList().ForEach(_ => lanternFishShoal.Age());
Console.WriteLine($"There are now {lanternFishShoal.Count} fish");

#endregion