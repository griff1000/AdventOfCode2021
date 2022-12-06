namespace Challenge4
{
    internal class Board
    {
        private List<Row> Rows { get; }
        internal bool HasWon { get; private set; }
        internal Board(IEnumerable<string> boardNumbers)
        {
            Rows = new List<Row>(boardNumbers.Select(bn => new Row(bn)));
        }

        internal bool CallNumber(int numberCalled)
        {
            // isAnyMatch is just a performance tweak to stop it checking columns
            // for wins when the number didn't match in any of the rows.  It could
            // be removed and functionally still work.
            var isAnyMatch = false;
            foreach (var row in Rows)
            {
                var isMatch = row.CallNumber(numberCalled);
                if (isMatch) isAnyMatch = true;
                if (!isMatch || !row.IsBingo()) continue;
                return HasWon = true; // could raise events at this point
            }
            return isAnyMatch && CheckColumns(); 
        }

        private bool CheckColumns()
        {
            for (var i = 0; i < 5; i++)
            { 
                var isBingo = Rows.Select(r => r.BoardNumbers.ElementAt(i)).All(e => e.Value);
                if (!isBingo) continue;
                return HasWon = true; // could raise events at this point
            }
            return false;
        }

        internal int CalculateScore()
        {
            return Rows
                .SelectMany(r => r.BoardNumbers)
                .Where(v => !v.Value)
                .Sum(v => v.Key);
        }
    }
}
