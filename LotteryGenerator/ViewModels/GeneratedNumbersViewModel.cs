using LotteryGenerator.Model;

namespace LotteryGenerator.ViewModels
{
    public class GeneratedNumbersViewModel : ViewModelBase
    {
        private readonly GeneratedNumbers _generatedNumbers;

        public GeneratedNumbersViewModel(GeneratedNumbers generatedNumbers) 
        {
            _generatedNumbers = generatedNumbers;
        }

        public int Number1
        {
            get => _generatedNumbers.Number1;
            set
            {
                _generatedNumbers.Number1 = value;
                OnPropertyChanged(nameof(Number1));
            }
        }

        public int Number2
        {
            get => _generatedNumbers.Number2;
            set
            {
                _generatedNumbers.Number2 = value;
                OnPropertyChanged(nameof(Number2));
            }
        }

        public int Number3
        {
            get => _generatedNumbers.Number3;
            set
            {
                _generatedNumbers.Number3 = value;
                OnPropertyChanged(nameof(Number3));
            }
        }

        public int Number4
        {
            get => _generatedNumbers.Number4;
            set
            {
                _generatedNumbers.Number4 = value;
                OnPropertyChanged(nameof(Number4));
            }
        }

        public int Number5
        {
            get => _generatedNumbers.Number5;
            set
            {
                _generatedNumbers.Number5 = value;
                OnPropertyChanged(nameof(Number5));
            }
        }

        public int BonusNumber
        {
            get => _generatedNumbers.BonusNumber;
            set
            {
                _generatedNumbers.BonusNumber = value;
                OnPropertyChanged(nameof(BonusNumber));
            }
        }

        public void Update(GeneratedNumbers generatedNumbers)
        {
            Number1 = generatedNumbers.Number1;
            Number2 = generatedNumbers.Number2;
            Number3 = generatedNumbers.Number3;
            Number4 = generatedNumbers.Number4;
            Number5 = generatedNumbers.Number5;
            BonusNumber = generatedNumbers.BonusNumber;
        }
    }
}
