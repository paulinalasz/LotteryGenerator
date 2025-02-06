using LotteryGenerator.Helpers;
using System.Windows.Input;

namespace LotteryGenerator
{
    public sealed class MainWindowViewModel
    {
        private ICommand _generateCommand;
        public ICommand GenerateCommand => _generateCommand ?? (_generateCommand = new CommandHandler(Generate, () => { return true; }));

        public void Generate() { }

        private int _number1;
        public int Number1
        {
            get => _number1;
            set
            {
                _number1 = value;
            }
        }

        private int _number2;
        public int Number2
        {
            get => _number2;
            set
            {
                _number2 = value;
            }
        }

        private int _number3;
        public int Number3
        {
            get => _number3;
            set
            {
                _number3 = value;
            }
        }

        private int _number4;
        public int Number4
        {
            get => _number4;
            set
            {
                _number4 = value;
            }
        }

        private int _number5;
        public int Number5
        {
            get => _number5;
            set
            {
                _number5 = value;
            }
        }

        private int _bonusNumber;
        public int BonusNumber
        {
            get => _bonusNumber;
            set
            {
                _bonusNumber = value;
            }
        }
    }
}
