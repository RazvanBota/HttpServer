using System.Collections.Generic;

namespace HttpServer
{
    class CheckHeader
    {
        private readonly string Verb;
        private readonly string HttpVersion;
        private readonly string Path;
        private readonly string[] HeaderOnLines;
        private readonly Dictionary<string, string> HeaderInfo = new Dictionary<string, string>();

        public CheckHeader(string[] headerOnLines)
        {
            this.HeaderOnLines = headerOnLines;
            string[] firstLine = headerOnLines[0].Split(' ');
            HeaderInfo = new Header(headerOnLines).CollectInfo();
            Verb = firstLine[0];
            Path = firstLine[1];
            HttpVersion = firstLine[2];
        }

        public bool IsValid()
        {
            return HeaderContent() && new VerbAndHttpVersion().Match(Verb + HttpVersion).IsSuccesful() && new URI().Match(Path).IsSuccesful();
        }

        private bool HeaderContent()
        {
            int i = 1;
            while(HeaderOnLines[i].Length > 2)
            {
                if (!new HeaderContent().Match(HeaderOnLines[i]).IsSuccesful())
                    return false;
                i++;
            }
            return true;
        }
    }
}
