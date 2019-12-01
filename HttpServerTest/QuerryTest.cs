using Xunit;
using HttpServer;

namespace HttpServerTest
{
    public class QuerryTest
    {
        [Fact]
        public void AnCorrectInput()
        {
            Assert.True(new Querry().Match("name=ferret").IsSuccesful());
        }

        [Fact]
        public void MaybeWorkWithOnlyLeters()
        {
            Assert.True(new Querry().Match("asdasferwgewijiad").IsSuccesful());
        }

        [Fact]
        public void MaybeWithOnlyDigits()
        {
            Assert.True(new Querry().Match("12356342").IsSuccesful());
        }

        [Fact]
        public void IfStartWithSlash()
        {
            Assert.True(new Querry().Match("/name=123").IsSuccesful());
        }
    }
}
