namespace HttpServer
{
    public class Fragment : IPattern
    {
        public IMatch Match(string myString)
        {
            var fragment = new OneOrMore(new Choice(new Pchar(), new Any("/?")));
            return fragment.Match(myString);
        }
    }
}
