namespace Challenge4
{
    internal class Row
    {
        internal Dictionary<int, bool> Values { get; }

        internal Row(string numbersToAdd)
        {
            var numbers = numbersToAdd.Split(' ');
            Values = new Dictionary<int, bool>(numbers
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .Select(n => new KeyValuePair<int,bool>(int.Parse(n), false)));
        }

        internal bool CallNumber(int number)
        {
            if (!Values.ContainsKey(number)) return false;
            Values[number] = true;
            return true;
        }

        internal bool IsBingo()
        {
            return Values.All(v => v.Value);
        }
    }
}
