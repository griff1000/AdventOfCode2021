namespace Challenge4
{
    internal class Row
    {
        internal Dictionary<int, bool> BoardNumbers { get; }

        internal Row(string numbersToAdd)
        {
            var numbers = numbersToAdd.Split(' ');
            BoardNumbers = new Dictionary<int, bool>(numbers
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .Select(n => new KeyValuePair<int,bool>(int.Parse(n), false)));
        }

        internal bool CallNumber(int number)
        {
            if (!BoardNumbers.ContainsKey(number)) return false;
            BoardNumbers[number] = true;
            return true;
        }

        internal bool IsBingo()
        {
            return BoardNumbers.All(v => v.Value);
        }
    }
}
