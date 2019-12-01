using Xunit;
using HttpServer;

namespace HttpServerTest
{
    public class HeaderContentTest
    {
        [Fact]
        public void AnCorrectInput()
        {
            var header = new HeaderContent().Match("Accept: asd");
            Assert.True(header.IsSuccesful());
            Assert.Equal(" asd", header.RemainingText());
        }

        [Fact]
        public void InputWithMiddleLine()
        {
            var header = new HeaderContent().Match("Accept-Language:");
            Assert.True(header.IsSuccesful());
            Assert.Equal("", header.RemainingText());
        }

        [Fact]
        public void WrongInputFormat()
        {
            Assert.False(new HeaderContent().Match("Maybe this is wrong.").IsSuccesful());
        }

        [Fact]
        public void AnotherWrongFormat()
        {
            Assert.False(new HeaderContent().Match("Accept").IsSuccesful());
        }
    }
}
