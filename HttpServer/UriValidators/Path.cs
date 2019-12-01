namespace HttpServer
{
    public class Path : IPattern
    {
        public IMatch Match(string myString)
        {
            var unreserved = new Choice(new Range('a', 'z'), new Range('A', 'Z'), new Range('0', '9'), new Any("._~"));
            var subDelims = new Any("!$&'()*+,;=");

            var pathAbempty = new OneOrMore(new Sequance(new Character('/'), new OneOrMore(new Pchar())));
            var pathAbsolute = new Sequance(new Character('/'), new OneOrMore(new Sequance(new Pchar(), new OneOrMore(new Sequance(new Character('/'), new OneOrMore(new Pchar()))))));
            var pathNoscheme = new Sequance(new Choice(unreserved, subDelims, new Character('@')), new OneOrMore(new Sequance(new Character('/'), new OneOrMore(new Pchar()))));
            var pathRootless = new Sequance(new Pchar(), new OneOrMore(new Sequance(new Character('/'), new OneOrMore(new Pchar()))));
            var pathEmpty = new Character('/');
            var path = new Choice(pathAbempty, pathAbsolute, pathNoscheme, pathRootless, pathEmpty);

            return path.Match(myString);
        }
    }
}
