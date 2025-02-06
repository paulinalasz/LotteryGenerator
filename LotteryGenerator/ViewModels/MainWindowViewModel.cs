using LotteryGenerator.Helpers;
using LotteryGenerator.Model;
using System.Windows.Input;

namespace LotteryGenerator.ViewModels
{
    public sealed class MainWindowViewModel : ViewModelBase
    {
        private readonly Generator _generator;

        public MainWindowViewModel() 
        {
            _generator = new Generator(new RandomNumberGenerator(new Random()));
            GeneratedNumbersViewModel = new GeneratedNumbersViewModel(new GeneratedNumbers(0, 0, 0, 0, 0, 0));
        }

        public GeneratedNumbersViewModel GeneratedNumbersViewModel { get; set; }

        private ICommand _generateCommand;
        public ICommand GenerateCommand => _generateCommand ?? (_generateCommand = new CommandHandler(Generate, () => { return true; }));

        public void Generate() 
        {
            var generatedNumbers = _generator.Generate();
            GeneratedNumbersViewModel.Update(generatedNumbers);
        }
    }
}
