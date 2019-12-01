namespace HttpServer
{
    public class HeaderContent : IPattern
    {
        public IMatch Match(string myString)
        {
            var requestHeader = new Sequance(new OneOrMore(new Choice(new Range('A', 'Z'), new Range('a', 'z'), new Character('-'))), new Character(':'));
            return requestHeader.Match(myString);
        }
    }
}
