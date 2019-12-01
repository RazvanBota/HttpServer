namespace HttpServer
{
    public class Sequance : IPattern
    {
        private readonly IPattern[] array;

        public Sequance(params IPattern[] array)
        {
                this.array = array;
        }

        public IMatch Match(string inputText)
        {
            string originalInput = inputText;
            foreach (IPattern pattern in array) {
                var match = pattern.Match(inputText);
                if (match.IsSuccesful())
                    inputText = match.RemainingText();
                else
                    return new FailMatch(originalInput);
            }
            return new SuccesMatch(inputText);
        }
    }
}
