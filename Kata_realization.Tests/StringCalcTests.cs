namespace Kata_realization.Tests
{
    using NUnit.Framework;
    using Shouldly;
    using System;

    public class StringCalcTests
    {
        private StringCalc _calc;

        [SetUp]
        public void Setup()
        {
           _calc = new StringCalc();
        }

        [Test]
        public void Test1()
        {
            // String empty, throw ArgumentNullException
            var exception = Assert.Throws<ArgumentNullException>(() => _calc.Add(string.Empty));
            Assert.That(exception.Message, Is.SupersetOf("String can not be null or empty"));

            // String invalid format, throw FormatException
            var ex = Assert.Throws<FormatException>(() => _calc.Add("1,\n"));
            Assert.That(ex.Message, Is.SupersetOf("String contains an invalid sequence. Invalid format: 'number, separator, line feed.'"));
            ex = Assert.Throws<FormatException>(() => _calc.Add("1,\n,3"));
            Assert.That(ex.Message, Is.SupersetOf("String contains an invalid sequence. Invalid format: 'number, separator, line feed.'"));

            // String contains negatives digits, throw ArgumentException
            var e = Assert.Throws<ArgumentException>(() => _calc.Add("-1,5,-7"));
            Assert.That(e.Message, Is.SupersetOf("Negatives not allowed. -1,-7"));

            _calc.Add("1").ShouldBe(1);
            _calc.Add("1,2").ShouldBe(3);
            _calc.Add("1\n2").ShouldBe(3);
            _calc.Add(";1\n2;3").ShouldBe(6);

        }
    }
}
