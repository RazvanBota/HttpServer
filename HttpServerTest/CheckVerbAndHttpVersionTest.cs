using HttpServer;
using Xunit;

namespace HttpServerTest
{
    public class CheckVerbAndHttpVersionTest
    {
        string verb;
        readonly string correctHttp = "HTTP/1.1\r";
        readonly string wrongHttp = "HTTP/1.0\r";

        [Fact]
        public void OptionVerbWithCorectHttp()
        {
            verb = "OPTIONS";
            Assert.True(new VerbAndHttpVersion().Match(verb + correctHttp).IsSuccesful());
        }

        [Fact]
        public void OptionVerbWithWrongHttp()
        {
            Assert.False(new VerbAndHttpVersion().Match(verb + wrongHttp).IsSuccesful());
        }

        [Fact]
        public void GetVerbWithCorrectHttp()
        {
            verb = "GET";
            Assert.True(new VerbAndHttpVersion().Match(verb + correctHttp).IsSuccesful());
        }

        [Fact]
        public void HeadVerbWithWrongHttp()
        {
            verb = "HEAD";
            Assert.False(new VerbAndHttpVersion().Match(verb + wrongHttp).IsSuccesful());
        }

        [Fact]
        public void PostVerbWithCorrectHttp()
        {
            verb = "POST";
            Assert.True(new VerbAndHttpVersion().Match(verb + correctHttp).IsSuccesful());
        }
    
    }
}
