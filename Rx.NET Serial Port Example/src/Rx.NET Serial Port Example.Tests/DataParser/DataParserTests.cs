using FluentAssertions;
using NUnit.Framework;

namespace Rx.NET_Serial_Port_Example.Tests.DataParser
{
    [TestFixture]
    public class DataParserTests
    {

        public class GreenPathTests : DataParserTests
        {

            [SetUp]
            public void Setup()
            {
            }

            [Test]
            public void ForOneDigitFloat_ShouldReturnValue()
            {
                //arrange
                var target = new NET_Serial_Port_Example.DataParser();
                var weightMessage = "PREFIX 2.05 kg";

                //act
                var result = target.Parse(weightMessage);

                //assert
                result.Value.Should().Be(2.05f);
                result.Unit.Should().Be("kg");

            }


            [Test]
            public void ForSixDigitsFloat_ShouldReturnValue()
            {
                //arrange
                var target = new NET_Serial_Port_Example.DataParser();
                var weightMessage = "PREFIX 456782.12 kg";

                //act
                var result = target.Parse(weightMessage);

                //assert
                result.Value.Should().Be(456782.12f);
                result.Unit.Should().Be("kg");

            }
        }
    }
}
