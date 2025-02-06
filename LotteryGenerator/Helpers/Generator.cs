using LotteryGenerator.Model;

namespace LotteryGenerator.Helpers
{
    public class Generator
    {
        private readonly IRandomNumberGenerator _random;

        public Generator(IRandomNumberGenerator random)
        {
            _random = random;
        }

        public GeneratedNumbers Generate()
        {
            var lotteryNumbers = new List<int>();

            while (lotteryNumbers.Count < 5)
            {
                var newNumber = _random.Next(1, 60);
                // Lottery numbers must be unique
                if (!lotteryNumbers.Contains(newNumber))
                {
                    lotteryNumbers.Add(newNumber);
                }
            }

            // Lottery numbers must be in ascending order
            lotteryNumbers = lotteryNumbers.Order().ToList();

            int bonusNumber;
            do
            {
                bonusNumber = _random.Next(1, 60);
            } // Bonus number must also be unique 
            while (lotteryNumbers.Contains(bonusNumber));

            return new GeneratedNumbers(lotteryNumbers[0],
                lotteryNumbers[1],
                lotteryNumbers[2],
                lotteryNumbers[3],
                lotteryNumbers[4],
                bonusNumber);
        }
    }
}
