namespace Kata_realization.Tests
{
    using NUnit.Framework;
    using Shouldly;
    using System;

    public class StringSummatorTests
    {
        private StringSummator _summator;

        [SetUp]
        public void Setup()
        {
            _summator = new StringSummator();
        }

        [Test]
        public void Test1()
        {
            // String empty, throw ArgumentNullException
            var exception = Assert.Throws<ArgumentNullException>(() => _summator.Sum(string.Empty, "1"));
            Assert.That(exception.Message, Is.SupersetOf("String can not be null or empty"));

            // Should return 3
            var result = _summator.Sum("1", "2");
            result.ShouldBe(3);

            // Should return 9 then 6
            result = _summator.Sum("11", "9");
            result.ShouldBe(9);
            result = _summator.Sum("6", "15");
            result.ShouldBe(6);

            // String contains any non-digit character, throw ArgumentException
            var e = Assert.Throws<ArgumentException>(() => _summator.Sum("a", "1"));
            Assert.That(e.Message, Is.SupersetOf($"One of the arguments is a letter. Num1: a, Num2: 1"));
            e = Assert.Throws<ArgumentException>(() => _summator.Sum("2", "&"));
            Assert.That(e.Message, Is.SupersetOf($"One of the arguments is a letter. Num1: 2, Num2: &"));
        }
    }
}