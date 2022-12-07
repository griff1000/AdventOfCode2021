namespace Challenge6
{
    /// <summary>
    /// This worked for the first part with just 80 iterations but quickly ran out of puff
    /// as the number of iterations grew
    /// </summary>
    internal class LanternFish
    {
        internal int Timer { get; private set; }

        public LanternFish() : this(8)
        { }

        internal LanternFish(int timer)
        {
            Timer = timer;
        }

        internal LanternFish? Age()
        {
            if (Timer == 0)
            {
                Timer = 6;
                return new LanternFish();
            }

            Timer--;
            return null;
        }
    }
}
