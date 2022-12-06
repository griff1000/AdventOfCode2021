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

            foreach (var row in Rows)
            {
                var isMatch = row.CallNumber(numberCalled);
                if (!isMatch || !row.IsBingo()) continue;
                HasWon = true;
                return true;
            }
            return CheckColumns();
        }

        private bool CheckColumns()
        {
            for (var i = 0; i < 5; i++)
            { 
                var isBingo = Rows.Select(r => r.Values.ElementAt(i)).All(e => e.Value);
                if (!isBingo) continue;
                HasWon = true;
                return true;
            }
            return false;
        }

        internal int CalculateScore()
        {
            return Rows
                .SelectMany(r => r.Values)
                .Where(v => !v.Value)
                .Sum(v => v.Key);
        }
    }
}
