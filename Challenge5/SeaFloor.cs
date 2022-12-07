namespace Challenge5
{
    using System.Diagnostics;

    internal class SeaFloor
    {
        private readonly Dictionary<(int x, int y), int> Floor = new();

        internal void Process(Coordinates coordinates)
        {
            if (coordinates.Point1.X == coordinates.Point2.X)
            {
                MarkVertical(coordinates.Point1.X, coordinates.Point1.Y, coordinates.Point2.Y);
            }
            else if (coordinates.Point1.Y == coordinates.Point2.Y)
            {
                MarkHorizontal(coordinates.Point1.Y, coordinates.Point1.X, coordinates.Point2.X);
            }
            else
            {
                MarkDiagonal(coordinates);
            }

        }

        private void MarkVertical(int x, int y1, int y2)
        {
            for (var i = Math.Min(y1, y2); i <= Math.Max(y1, y2); i++)
            {

                Mark((x, i));
            }
        }

        private void MarkHorizontal(int y, int x1, int x2)
        {
            for (var i = Math.Min(x1, x2); i <= Math.Max(x1, x2); i++)
            {
                Mark((i, y));
            }
        }

        private void MarkDiagonal(Coordinates coordinates)
        {
            var xStep = coordinates.Point1.X < coordinates.Point2.X ? 1 : -1;
            var yStep = coordinates.Point1.Y < coordinates.Point2.Y ? 1 : -1;
            var distance = Math.Abs(coordinates.Point1.X - coordinates.Point2.X);
            Debug.Assert(distance == Math.Abs(coordinates.Point1.Y - coordinates.Point2.Y));
            var xLatest = coordinates.Point1.X;
            var yLatest = coordinates.Point1.Y;
            for (var i = 0; i <= distance; i++)
            {
                Mark((xLatest, yLatest));
                xLatest += xStep;
                yLatest += yStep;
            }
        }

        private void Mark((int x, int y) key)
        {
            if (Floor.ContainsKey(key))
            {
                Floor[key]++;
            }
            else
            {
                Floor[key] = 1;
            }
        }

        internal int CountOverlaps(int minOverlaps)
        {
            return Floor.Count(f => f.Value >= minOverlaps);
        }

    }
}
