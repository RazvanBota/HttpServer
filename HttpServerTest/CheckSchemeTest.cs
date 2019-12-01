using Xunit;
using HttpServer;

namespace HttpServerTest
{
    public class CheckSchemeTest
    {
        [Fact]
        public void HttpsFormat()
        {
            Assert.True(new Scheme().Match("Https:").IsSuccesful());
        }

        [Fact]
        public void RandomTypeOfCorrectFormatOnlyWithLetters()
        {
            Assert.True(new Scheme().Match("bcdasdr:").IsSuccesful());
        }

        [Fact]
        public void TextWithCharsAndNumbers()
        {
            Assert.True(new Scheme().Match("Asd123:").IsSuccesful());
        }

        [Fact]
        public void TextWithAllAllowedChars()
        {
            Assert.True(new Scheme().Match("Aa1+sd21-.+:").IsSuccesful());
            Assert.Equal("", new Scheme().Match("Aa1+sd21-.+:").RemainingText());
        }

        [Fact]
        public void TextWithIncorrectFirstLetterFormat()
        {
            Assert.False(new Scheme().Match("1asd").IsSuccesful());
        }

        [Fact]
        public void TextWithNotAllowedChars()
        {
            Assert.False(new Scheme().Match("asd123/AS").IsSuccesful());
        }
    }
}
