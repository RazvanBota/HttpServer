using Xunit;
using HttpServer;

namespace HttpServerTest
{
    public class AuthorityTest
    {
        [Fact]
        public void CheckAnCorrectInput()
        {
            var authority = new Authority().Match("razvan:@gmail.com:123");
            Assert.True(authority.IsSuccesful());
            Assert.Equal("", authority.RemainingText());
        }

        [Fact]
        public void CheckCorrectInputWithoutUsserinfo()
        {
            Assert.True(new Authority().Match("gmail.com:230").IsSuccesful());
        }

        [Fact]
        public void CheckCorrectInputWithoutPort()
        {
            Assert.True(new Authority().Match("razvan:@gmail.com").IsSuccesful());
        }

        [Fact]
        public void CheckCorrectInputWithoutPortAndUsserinfo()
        {
            Assert.True(new Authority().Match("gmail.com").IsSuccesful());
        }

    }
}
