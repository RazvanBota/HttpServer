using Xunit;
using HttpServer;

namespace HttpServerTest
{
    public class UriTest
    {
        [Fact]
        public void CorrectInput()
        {
            var uri = new URI().Match("http://www.ietf.org/rfc/rfc2396.txt");
            Assert.Equal("", uri.RemainingText());
            Assert.True(uri.IsSuccesful());
        }

        [Fact]
        public void GoogleUriTest()
        {
            Assert.True(new URI().Match("https://www.google.com/").IsSuccesful());
        }

        [Fact]
        public void GoogleUriAfterSearchingWikipedia()
        {
            Assert.True(new URI().Match("https://www.google.com/search?source=hp&ei=22WlW_W8IIe3kwWA6InICw&q=wikipedia&oq=wiki&gs_l=psy-ab.3.0.0l10.178562.179111.0.179984.7.5.0.0.0.0.103.347.3j1.4.0....0...1c.1.64.psy-ab..3.4.346.0..35i39k1.0.UP_v5YOHW24").IsSuccesful());
        }

        [Fact]
        public void RandomExepleOfUriFromDocumentation()
        {
            Assert.True(new URI().Match("telnet://192.0.2.16:80/").IsSuccesful());
        }
    }
}
