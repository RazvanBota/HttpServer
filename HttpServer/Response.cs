using System.IO;

namespace HttpServer
{
    class Response
    {
        private readonly Stream Stream;
        private string Header;

        public Response(Stream stream, string header)
        {
            this.Stream = stream;
            this.Header = header;
        }

        public void SendResponse()
        {
            string path = System.IO.Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, "Resources");
            string[] splitHeader = Header.Split(' ');
            string fileName = splitHeader[1].Replace('/', '\\');

            new RequiredFile(Stream, path, fileName).Search(); 
        }
    }
}
