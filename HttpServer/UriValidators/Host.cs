namespace HttpServer
{
    public class Host : IPattern
    {
        public IMatch Match(string myString)
        {
            var ipv4 = new Ipv4();
            var regName = new RegName();
            var host = new Choice(ipv4, regName);
            return host.Match(myString);
        }
    }
}

