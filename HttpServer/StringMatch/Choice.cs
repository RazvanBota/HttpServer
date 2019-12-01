namespace HttpServer
{
    public class Choice : IPattern
    {
        private IPattern[] Array;

        public Choice(params IPattern[] array)
        {
            this.Array = array;
        }

        public void AddChoice(IPattern newPattern)
        {
            IPattern[] tempPattern = new IPattern[Array.Length+1];
            for(int i = 0; i < Array.Length; i++)            
                tempPattern[i] = Array[i];
            tempPattern[Array.Length] = newPattern;
            Array = tempPattern;
        }

        public IMatch Match(string inputText)
        {
            if (Array.Length == 0)
                return new SuccesMatch(inputText);

            foreach(IPattern pattern in Array) { 
                var match = pattern.Match(inputText);
                if (match.IsSuccesful())
                    return match;
            }
            return new FailMatch(inputText);
        }
    }
}
