using Xunit;
using HttpServer;

namespace HttpServerTest
{
    public class UsserinfoTest
    {
        [Fact]
        public void CheckAnCorrectInput()
        {
            Assert.True(new Userinfo().Match("Asd123:").IsSuccesful());
        }

        [Fact]
        public void CheckAnIncorrectInputWithCorrectEnd()
        {
            Assert.False(new Userinfo().Match("!%^&:").IsSuccesful());
        }
        
    }
}
