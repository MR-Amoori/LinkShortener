using System;

namespace LinkShortener.Utility
{
    public static class RandomGenerator
    {
        public static int randomNumbe()
        {
            Random random = new Random();
            return random.Next(0, 5000);
        }
    }
}
