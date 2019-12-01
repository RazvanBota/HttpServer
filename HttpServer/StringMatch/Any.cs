namespace HttpServer
{
    public class Any : IPattern
    {
        private string StringOfChar;

        public Any(string inputText)
        {
            StringOfChar = inputText;
        }

        public IMatch Match(string inputText)
        {
            if(inputText.Length == 0)
                return new FailMatch(inputText);

            for (int i = 0; i < StringOfChar.Length; i++)
                if(StringOfChar[i] == inputText[0])
                    return new SuccesMatch(inputText.Substring(1));
            return new FailMatch(inputText);
        }
    }
}
