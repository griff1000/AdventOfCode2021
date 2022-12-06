using System.Text;

var input = await File.ReadAllLinesAsync("./Input.txt");

// Part 1:
var gamma = new StringBuilder();
var epsilon = new StringBuilder();
for (var i = 0; i < 12; i++)
{
    var mostCommonBit = MostCommonBit(input, i).mostCommon;
    gamma.Append(mostCommonBit);
    epsilon.Append(mostCommonBit == '0' ? '1' : '0');
}

var gammaRate = Convert.ToInt32(gamma.ToString(), 2);
var epsilonRate = Convert.ToInt32(epsilon.ToString(), 2);
Console.WriteLine($"Product = {gammaRate * epsilonRate}");

// Part 2:
var o2GenRatingBinary = Reduce(input, 0, true).Single();
var co2ScrubRatingBinary = Reduce(input, 0, false).Single();
var o2GenRating = Convert.ToInt32(o2GenRatingBinary, 2);
var co2ScrubRating = Convert.ToInt32(co2ScrubRatingBinary, 2);
Console.WriteLine($"O2: {o2GenRating}; CO2: {co2ScrubRating}");
Console.WriteLine($"Product = {o2GenRating*co2ScrubRating}");

string[] Reduce(string[] currentArray, int index, bool o2ReadingSwitch)
{
    if (currentArray.Length <= 1) return currentArray;
    var (mostCommonBit, matchingCount) = MostCommonBit(currentArray, index);
    var criterion = (matchingCount, o2ReadingSwitch) switch
    {
        (true, true) => '1',
        (true, false) => '0',
        (false, true) => mostCommonBit,
        (false, false) => (mostCommonBit == '0' ? '1' : '0')
    };
    var reducedArray = currentArray
        .Where(reading => reading[index] == criterion)
        .ToArray();
    return Reduce(reducedArray, ++index, o2ReadingSwitch);
}

(char mostCommon, bool matchingCount) MostCommonBit(string[] array, int index)
{
    var zeroCount = array.Count(number => number[index] == '0');
    var oneCount = array.Count(number => number[index] == '1');
    if (zeroCount == oneCount) return ('1', true);
    return zeroCount > oneCount ? ('0', false) : ('1', false);
}
