using Xunit;
using HttpServer;

namespace HttpServerTest
{
    public class HostTest
    {
        [Fact]
        public void CheckAnCorrectInput()
        {
            Assert.True(new Host().Match("www.google.ro").IsSuccesful());
        }

        [Fact]
        public void CheckAnCorrectIpv4()
        {
            Assert.True(new Host().Match("89.32.21.42").IsSuccesful());
        }

        [Fact]
        public void CheckAnIncorectIpv4()
        {
            Assert.True(new Host().Match("583.23.120.75.55").IsSuccesful());
        }

        [Fact]
        public void CheckAnCorrectRegName()
        {
            Assert.True(new Host().Match("asd123-+;").IsSuccesful());
        }

        [Fact]
        public void CheckAnIncorrectRegName()
        {
            Assert.False(new Host().Match("@123").IsSuccesful());
        }

    }
}
