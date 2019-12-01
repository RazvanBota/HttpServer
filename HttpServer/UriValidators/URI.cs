namespace HttpServer
{
    public class URI : IPattern
    {
        public IMatch Match(string myString)
        {
            var uri = new Sequance(new Optional(new Scheme()), new Optional(new Text("//")), new Optional(new Authority()), new Path(), 
                new Optional(new Sequance(new Character('?'), new Querry())), 
                new Optional(new Sequance(new Character('#'), new Fragment())));
            return uri.Match(myString);
        }
    }
}
