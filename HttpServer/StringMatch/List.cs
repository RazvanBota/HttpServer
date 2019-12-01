namespace HttpServer
{
    public class List : IPattern
    {
        private readonly IPattern pattern;
        private readonly IPattern separator;

        public List(IPattern pattern, IPattern separator)
        {
            this.pattern = new Many(new Sequance(separator, pattern));
            this.separator = pattern;
        }

        public IMatch Match(string inputText)
        {
            var match = separator.Match(inputText);
            if(match.RemainingText() != inputText)
                return pattern.Match(match.RemainingText());
            return new SuccesMatch(inputText);
        }
    }
}
