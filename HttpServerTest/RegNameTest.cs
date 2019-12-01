using Xunit;
using HttpServer;

namespace HttpServerTest
{
    public class RegNameTest
    {
        [Fact]
        public void CorrectInputWithUnreservedCharFirst()
        {
            Assert.True(new RegName().Match("ABsd();A;b").IsSuccesful());
        }

        [Fact]
        public void CorrectInputWithSubdelimsCharFirst()
        {
            Assert.True(new RegName().Match("!()asd").IsSuccesful());
        }

        [Fact]
        public void IncorectInput()
        {
            Assert.False(new RegName().Match("[asdf]").IsSuccesful());
        }
    }
}
