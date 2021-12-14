namespace Kata_realization.Tests
{
    using NUnit.Framework;
    using Shouldly;

    public class OddEvenCheckerTests
    {
        private OddEvenChecker _checker;
        [SetUp]
        public void Setup()
        {
            _checker = new OddEvenChecker();
        }

        [Test]
        public void Test1()
        {
            _checker.isOddEvenRange(1,100);

            _checker.isOddEvenDigit(1).ShouldBe(true);
            _checker.isOddEvenDigit(9).ShouldBe(true);
            _checker.isOddEvenDigit(10).ShouldBe(true);
            _checker.isOddEvenDigit(11).ShouldBe(false);
        }
    }
}
