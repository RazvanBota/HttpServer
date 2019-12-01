namespace HttpServer
{
    public class Pchar : IPattern
    {
        public IMatch Match(string myString)
        {
            var unreserved = new Choice(new Range('a', 'z'), new Range('A', 'Z'), new Range('0', '9'), new Any("._~"));
            var subDelims = new Any("!$&'()*+,;=");
            var pChar = new Choice(unreserved, subDelims, new Character(':'), new Character('@'));
            return pChar.Match(myString);
        }
    }
}
