using LotteryGenerator.Helpers;
using Moq;

namespace LotteryGeneratorTests
{
    [TestClass]
    public sealed class GeneratorTests
    {
        [TestMethod]
        public void EachNumberMustBeUniqueInSequence()
        {
            var mockRandom = new Mock<IRandomNumberGenerator>();
            //var generator = new Generator();
        }
    }
}
