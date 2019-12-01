using Xunit;
using HttpServer;

namespace HttpServerTest
{
    public class Ipv4Test
    {
        [Fact]
        public void CorrectInput()
        {
            Assert.True(new Ipv4().Match("123.156.178.2").IsSuccesful());
        }

        [Fact]
        public void InputOver255Limit()
        {
            Assert.False(new Ipv4().Match("123.456.789.0").IsSuccesful());
        }

        [Fact]
        public void InputWithIncorectDigitsFormat()
        {
            Assert.False(new Ipv4().Match("012.134.250.00").IsSuccesful());
        }

        [Fact]
        public void InputWithRandomCharInsteadPoint()
        {
            Assert.False(new Ipv4().Match("0,123.56:23").IsSuccesful());
        }

        [Fact]
        public void ShortFormat()
        {
            Assert.False(new Ipv4().Match("123.45.67.").IsSuccesful());
        }

        [Fact]
        public void FourDigitInsteadOfThree()
        {
            Assert.False(new Ipv4().Match("1234.2345.1200.0000").IsSuccesful());
        }
    }
}
