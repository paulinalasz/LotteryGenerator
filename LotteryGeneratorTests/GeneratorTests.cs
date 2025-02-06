using LotteryGenerator.Helpers;
using Moq;

namespace LotteryGeneratorTests
{
    [TestClass]
    public sealed class GeneratorTests
    {
        private readonly Random _random = new Random();

        [DataTestMethod]
        [DynamicData(nameof(NumberSequences), DynamicDataSourceType.Method)]
        public void EachNumberMustBeUniqueInSequence(Queue<int> randomNumberSequence)
        {
            // Arrange
            var randomMock = new Mock<IRandomNumberGenerator>();
            // This ensures that the test will never loop forever, as after completing our handwritten random sequence
            // we return to generating truely random numbers
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>()))
                      .Returns(() => randomNumberSequence.Count > 0 ? randomNumberSequence.Dequeue() : _random.Next(1, 60));

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

            Assert.IsTrue(generatedNumbersAsList.Count == generatedNumbersAsList.Distinct().Count());
        }

        public static IEnumerable<object[]> NumberSequences()
        {
            // Example data sets for different test cases
            yield return new object[] { new Queue<int>(new[] { 55, 21, 12, 16, 15, 59 }) }; // Expected non-issue input 
            yield return new object[] { new Queue<int>(new[] { 1, 2, 3, 4, 5, 6 }) };
            yield return new object[] { new Queue<int>(new[] { 1, 1, 2, 3, 4, 5, 6 }) };
            yield return new object[] { new Queue<int>(new[] { 1, 2, 3, 4, 5, 2 }) }; // First 5 numbers are unique, but the bonus is the same
            yield return new object[] { new Queue<int>(new[] { 1, 1, 1, 1, 1, 1 }) }; // First few numbers are all the same
        }
    }
}
