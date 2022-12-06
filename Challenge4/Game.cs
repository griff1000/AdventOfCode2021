namespace Challenge4
{
    internal class Game
    {
        private List<Board> Boards { get; }

        public Game(IEnumerable<string> boardNumbers)
        {
            var boardNumbersChunked = boardNumbers
                .Where(bn => !string.IsNullOrWhiteSpace(bn))
                .Chunk(5);
            Boards = new List<Board>(boardNumbersChunked.Select(b => new Board(b)));
        }

        internal IEnumerable<Board> CallNumber(int numberCalled)
        {
            return Boards.Where(b => !b.HasWon).Where(board => board.CallNumber(numberCalled));
        }
    }
}
