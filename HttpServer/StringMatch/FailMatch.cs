namespace HttpServer
{
    class FailMatch : IMatch
    {
        private readonly string inputString;

        public FailMatch(string newString)
        {
            inputString = newString;
        }

        public bool IsSuccesful()
        {
            return false;
        }

        public string RemainingText()
        {
            return inputString;
        }
    }
}
