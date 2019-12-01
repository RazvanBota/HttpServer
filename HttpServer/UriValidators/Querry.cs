namespace HttpServer
{
    public class Querry : IPattern
    {
        public IMatch Match(string myString)
        {
            var querry = new OneOrMore(new Choice(new Pchar(), new Character('/'), new Character('?')));
            return querry.Match(myString);
        }
    }
}
