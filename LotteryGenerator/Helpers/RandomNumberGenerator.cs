namespace LotteryGenerator.Helpers
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly Random _random;
        public RandomNumberGenerator(Random random)
        {
            _random = random;
        }

        public int Next(int minValue, int maxValue)
        { 
            return _random.Next(minValue, maxValue);
        }
    }
}
