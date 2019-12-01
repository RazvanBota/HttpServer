namespace HttpServer
{
    public class RegName : IPattern
    {
        public IMatch Match(string myString)
        {
            var unreserved = new Choice(new Choice(new Range('a', 'z'), new Range('A', 'Z')), new Range('0', '9'), new Any("-._~"));
            var subDelims = new Any("!$&'()*+,;=");
            var reg = new OneOrMore(new Choice(unreserved, subDelims));
            return reg.Match(myString);
        }
    }
}
