using System.IO;
using System.Linq;
using System.Text;

namespace HttpServer
{
    class RequiredFile
    {
        private Stream Stream;
        private string Path;
        private readonly string FileName;
        private byte[] Bytes = new byte[1024];

        public RequiredFile(Stream stream, string path, string fileName)
        {
            this.Stream = stream;
            this.Path = path;
            this.FileName = fileName;
        }

        public void Search()
        {
            try
            {
                using (FileStream fstream = File.Open(Path + FileName, FileMode.Open)) {
                    Path += FileName;
                    Found(fstream);
                }
            }
            catch (FileNotFoundException)
            {
                NotFound("\\index.html");
            }
            catch (DirectoryNotFoundException)
            {
                NotFound("\\index.html");
            }
        }

        private void Found(FileStream file)
        {
            var len = new FileInfo(Path).Length;
            string request = "HTTP/1.1 200 OK\r\n" +
                $"Content-Length: {len}\r\n" +
                "\r\n";

            Bytes = Encoding.ASCII.GetBytes(request);
            Stream.Write(Bytes, 0, Bytes.Count());

            file.CopyTo(Stream);
        }

        private void NotFound(string fileName)
        {
            try
            {
                using (FileStream fileStream = File.Open(Path + fileName, FileMode.Open)) {
                    Path += fileName; 
                    Found(fileStream);
                }
            }
            catch (FileNotFoundException)
            {
                if (fileName == "\\index.htm")
                {
                    string error = "HTTP/1.1 404 Not Found\r\n";

                    Bytes = Encoding.ASCII.GetBytes(error);
                    Stream.Write(Bytes, 0, Bytes.Count());
                }
                else
                    NotFound("\\index.htm");
            }
        }
    }
}
