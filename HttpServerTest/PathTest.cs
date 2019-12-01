using Xunit;
using HttpServer;

namespace HttpServerTest
{
    public class PathTest
    {
        [Fact]
        public void CheckAnCorrectInput()
        {
            Assert.True(new Path().Match("/a/b/c/d").IsSuccesful());
        }

        [Fact]
        public void CheckForAnSlashTextOnly()
        {
            var path = new Path().Match("///");
            Assert.True(path.IsSuccesful());
            Assert.Equal("//", path.RemainingText());
        }

        [Fact]
        public void CheckForAnFolder()
        {
            Assert.True(new Path().Match("/a/b/c/").IsSuccesful());
        }

        [Fact]
        public void IfThePathIsWithDigits()
        {
            Assert.True(new Path().Match("/123/1as/3").IsSuccesful());
        }

        [Fact]
        public void PathHaveDoubleSlash()
        {
            var path = new Path().Match("//ab//cd//ef");
            Assert.True(path.IsSuccesful());
            Assert.Equal("/ab//cd//ef", path.RemainingText());
        }
    }
}
