namespace HttpServer
{
    public class Authority : IPattern
    {
        public IMatch Match(string myString)
        {
            var authority = new Sequance(new Optional(new Sequance(new Userinfo(), 
                new Character('@'))), new Host(), new Optional(new Port()));
            return authority.Match(myString);
        }
    }
}
