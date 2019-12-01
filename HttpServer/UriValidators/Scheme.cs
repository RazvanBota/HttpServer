namespace HttpServer
{
    public class Scheme : IPattern
    {
        public IMatch Match(string scheme)
        {
            var alpha = new Choice(new Range('a', 'z'), new Range('A', 'Z'));
            var schemeContent = new Sequance(alpha, new OneOrMore(new Choice(alpha, new Range('0', '9'), new Any("+-."))));
            var schemeEndChar = new Character(':');
            var schemeComplete = new Sequance(schemeContent, schemeEndChar);

            return schemeComplete.Match(scheme);
        }
    }
}
