using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer
{
    class ReadDemand
    {
        public async Task Listen()
        {
            IPAddress ipAddress = Dns.GetHostEntry("localhost").AddressList[0];
            TcpListener listener = new TcpListener(ipAddress, 8080);
            listener.Start();

            while (true)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                NetworkStream stream = client.GetStream();
                byte[] bytes = new byte[256];
                
                string response = "";

                while (!response.Contains("\r\n\r\n"))
                {
                    stream.Read(bytes, 0, bytes.Length);
                    response += Encoding.ASCII.GetString(bytes);
                }

                string[] lines = response.Split('\n');

                if (new CheckHeader(lines).IsValid())
                    new Response(stream, lines[0]).SendResponse();
                else
                {
                    bytes = Encoding.ASCII.GetBytes("HTTP/1.1 400 Bad Request\r\n");
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
        }
    }
}
