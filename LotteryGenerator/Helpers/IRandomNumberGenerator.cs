namespace LotteryGenerator.Helpers
{
    public interface IRandomNumberGenerator
    {
        public int Next(int minValue, int maxValue);
    }
}
