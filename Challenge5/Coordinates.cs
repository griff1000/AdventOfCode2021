namespace Challenge5
{
    using System.Drawing;

    internal class Coordinates
    {
        internal Point Point1 { get; }
        internal Point Point2 { get; }

        public Coordinates(string input)
        {
            var elements = input.Split(new [] {",", "->", ","}, StringSplitOptions.TrimEntries).Select(int.Parse).ToArray(); 
            Point1 = new Point(elements[0], elements[1]);
            Point2 = new Point(elements[2], elements[3]);
        }
    }
}
