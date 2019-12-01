using Xunit;
using HttpServer;

namespace HttpServerTest
{
    public class PortTest
    {
        [Fact]
        public void CheckAnCorrectInput()
        {
            Assert.True(new Port().Match(":123").IsSuccesful());
        }

        [Fact]
        public void CheckAnBiggerPort()
        {
            var port = new Port().Match(":67000");
            Assert.True(port.IsSuccesful());
            Assert.Equal("0", port.RemainingText());
        }

        [Fact]
        public void CheckIncorectPortFormat()
        {
            Assert.False(new Port().Match("123a").IsSuccesful());
        }
    }
}
