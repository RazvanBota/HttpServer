namespace HttpServer
{
    public class VerbAndHttpVersion : IPattern
    {
        public IMatch Match(string myString)
        {
            IPattern method = new Choice(new Text("OPTIONS"), new Text("GET"), new Text("HEAD"), new Text("POST"),
                                new Text("PUT"), new Text("DELETE"), new Text("TRACE"), new Text("CONNECT"));
            IPattern requestLine = new Sequance(method, new Text("HTTP/1.1\r"));
            return requestLine.Match(myString);
        }
    }
}
