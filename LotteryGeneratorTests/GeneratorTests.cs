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
            // Arrange
            var randomMock = new Mock<IRandomNumberGenerator>();
            randomMock.SetupSequence(r => r.Next(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(1)  
                .Returns(2)
                .Returns(3)  
                .Returns(4)
                .Returns(5) 
                .Returns(6);

            var generator = new Generator(randomMock.Object);

            // Act
            var generatedNumbers = generator.Generate();

            // Assert
            var generatedNumbersAsList = new List<int>
            { 
                generatedNumbers.Number1,
                generatedNumbers.Number2,
                generatedNumbers.Number3,
                generatedNumbers.Number4,
                generatedNumbers.Number5,
                generatedNumbers.BonusNumber
            };

            Assert.AreEqual(generatedNumbersAsList.Count == generatedNumbersAsList.Distinct().Count(), true);
        }
    }
}
