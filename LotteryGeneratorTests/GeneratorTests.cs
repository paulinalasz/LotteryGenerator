using LotteryGenerator.Helpers;
using LotteryGenerator.Model;
using Moq;

namespace LotteryGeneratorTests
{
    [TestClass]
    public sealed class GeneratorTests
    {
        private readonly Random _random = new Random();

        private GeneratedNumbers Setup(Queue<int> randomNumberSequence)
        {
            // Arrange
            var randomMock = new Mock<IRandomNumberGenerator>();
            // This ensures that the test will never loop forever, as after completing our handwritten random sequence
            // we return to generating truely random numbers
            randomMock.Setup(r => r.Next(It.IsAny<int>(), It.IsAny<int>()))
                      .Returns(() => randomNumberSequence.Count > 0 ? randomNumberSequence.Dequeue() : _random.Next(1, 60));

            var generator = new Generator(randomMock.Object);

            // Act
            return generator.Generate();
        }

        [DataTestMethod]
        [DynamicData(nameof(UniqueNumbers_TestInputs), DynamicDataSourceType.Method)]
        public void EachNumberMustBeUniqueInSequence(Queue<int> randomNumberSequence)
        {
            var generatedNumbers = Setup(randomNumberSequence);

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

        public static IEnumerable<object[]> UniqueNumbers_TestInputs()
        {
            // Example data sets for different test cases
            yield return new object[] { new Queue<int>(new[] { 55, 21, 12, 16, 15, 59 }) }; // Expected non-issue input 
            yield return new object[] { new Queue<int>(new[] { 1, 2, 3, 4, 5, 6 }) };
            yield return new object[] { new Queue<int>(new[] { 1, 1, 2, 3, 4, 5, 6 }) }; // First few numbers repeat and then become unique
            yield return new object[] { new Queue<int>(new[] { 1, 2, 3, 4, 5, 2 }) }; // First 5 numbers are unique, but the bonus is the same
            yield return new object[] { new Queue<int>(new[] { 1, 1, 1, 1, 1, 1 }) }; // First few numbers are all the same
            yield return new object[] { new Queue<int>(new[] { 1, 1, 1, 1, 1, 1, 2, 3, 4, 5, 6, 7 }) }; // First few numbers are all the same
        }

        [DataTestMethod]
        [DynamicData(nameof(AscendingNumbers_TestInputs), DynamicDataSourceType.Method)]
        public void NumbersMustBeInAscendingOrder(Queue<int> randomNumberSequence)
        {
            var generatedNumbers = Setup(randomNumberSequence);

            // We do not care about the BonusNumber, it can be lower than the previous
            var generatedNumbersAsList = new List<int>
            {
                generatedNumbers.Number1,
                generatedNumbers.Number2,
                generatedNumbers.Number3,
                generatedNumbers.Number4,
                generatedNumbers.Number5,
            };

            Assert.IsTrue(generatedNumbersAsList.SequenceEqual(generatedNumbersAsList.OrderBy(x => x)));
        }

        public static IEnumerable<object[]> AscendingNumbers_TestInputs()
        {
            // Example data sets for different test cases
            yield return new object[] { new Queue<int>(new[] { 1, 12, 23, 34, 45 }) }; // Expected non-issue input 
            yield return new object[] { new Queue<int>(new[] { 6, 5, 4, 3, 2, 1 }) }; // All number chosen in descending order
            yield return new object[] { new Queue<int>(new[] { 6, 10, 3, 5, 20 }) }; // All number chosen in random order
            yield return new object[] { new Queue<int>(new[] { 6, 10, 3, 10, 5, 20 }) }; // All number chosen in random order with some repeating
        }

        [DataTestMethod]
        [DynamicData(nameof(BonusNumberNotSortedNumbers_TestInputs), DynamicDataSourceType.Method)]
        public void BonusNumberIsNotSorted(Queue<int> randomNumberSequence, bool BonusIsExpectedHighest)
        {
            var generatedNumbers = Setup(randomNumberSequence);

            Assert.AreEqual(generatedNumbers.Number5 < generatedNumbers.BonusNumber, BonusIsExpectedHighest);
        }

        public static IEnumerable<object[]> BonusNumberNotSortedNumbers_TestInputs()
        {
            // Example data sets for different test cases
            yield return new object[] { new Queue<int>(new[] { 1, 12, 23, 34, 45, 56 }), true }; // Expected non-issue input 
            yield return new object[] { new Queue<int>(new[] { 1, 12, 23, 34, 45, 16 }), false }; // Shows that bonus is not sorted
        }
    }
}
