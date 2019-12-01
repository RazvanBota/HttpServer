using System.Collections.Generic;

namespace HttpServer
{
    class Header
    {
        string[] header;

        public Header(string[] header)
        {
            this.header = header;
        }

        public Dictionary<string, string> CollectInfo()
        {
            Dictionary<string, string> headerInfo = new Dictionary<string, string>();

            for(int i = 1; i < header.Length; i++)
            {
                string[] line = header[i].Split(new char[] { ':' }, 2);
                if (line[0] == "\r")
                    i = header.Length + 1;
                else
                    if(line.Length == 2)
                        headerInfo.Add(line[0], line[1]);
            }

            return headerInfo;
        }
    }
}
