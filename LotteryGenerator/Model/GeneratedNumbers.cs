namespace LotteryGenerator.Model
{
    public sealed class GeneratedNumbers
    {
        public GeneratedNumbers(int number1,
            int number2,
            int number3,
            int number4,
            int number5,
            int bonusNumber) 
        {
            Number1 = number1;
            Number2 = number2;
            Number3 = number3;
            Number4 = number4;
            Number5 = number5;
            BonusNumber = bonusNumber;
        }

        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Number3 { get; set; }
        public int Number4 { get; set; }
        public int Number5 { get; set; }
        public int BonusNumber { get; set; }    
    }
}
