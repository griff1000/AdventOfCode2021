namespace Challenge6
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class LanternFishShoal
    {
        // Key is number of days, value is number of fish at that number of days
        internal Dictionary<int, long> TimerDaysAndCount { get; } = new ();

        internal LanternFishShoal()
        {
            foreach (var i in Enumerable.Range(0,8))
            {
                TimerDaysAndCount[i] = 0;
            }
        }

        internal void AddFish(int timer)
        {
            TimerDaysAndCount[timer]++;
        }

        internal void Age()
        {
            var goingToGiveBirth = TimerDaysAndCount[0];
            for (var i = 1; i < 8; i++)
            {
                TimerDaysAndCount[i - 1] = TimerDaysAndCount[i];
            }

            TimerDaysAndCount[7] = goingToGiveBirth; // new fish
            TimerDaysAndCount[5] += goingToGiveBirth; // existing fish
        }

        internal long Count => TimerDaysAndCount.Sum(x => x.Value);
    }
}
