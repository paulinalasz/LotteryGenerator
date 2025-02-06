using LotteryGenerator.Helpers;
using System.Windows.Input;

namespace LotteryGenerator
{
    public sealed class MainWindowViewModel
    {
        private ICommand _generateCommand;
        public ICommand GenerateCommand => _generateCommand ?? (_generateCommand = new CommandHandler(Generate, () => { return true; }));

        public void Generate() { }
    }
}
