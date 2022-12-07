namespace Challenge6
{
    /// <summary>
    /// This is much more performant - it doesn't create new fish objects, it just keeps a
    /// count of fish for each day of the timer and moves that count along accordingly
    /// </summary>
    internal class LanternFishShoal
    {
        // Key is number of days, value is number of fish at that number of days
        private Dictionary<int, long> TimerDaysAndCount { get; } = new ();

        internal LanternFishShoal()
        {
            Enumerable.Range(0,9).ToList().ForEach(i => TimerDaysAndCount[i] = 0);
        }

        internal void AddFish(int timer)
        {
            TimerDaysAndCount[timer]++;
        }

        internal void Age()
        {
            // keep a record of the fish about to give birth
            var goingToGiveBirth = TimerDaysAndCount[0];

            for (var i = 1; i < 9; i++)
            {
                // Move the counts of fish not about to give birth down a day
                TimerDaysAndCount[i - 1] = TimerDaysAndCount[i];
            }

            // Add new baby fish
            TimerDaysAndCount[8] = goingToGiveBirth; 
            // Reset fish who just gave birth
            TimerDaysAndCount[6] += goingToGiveBirth;
        }

        internal long Count => TimerDaysAndCount.Sum(x => x.Value);
    }
}
