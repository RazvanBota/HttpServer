namespace HttpServer
{
    public class Character : IPattern
    {
        private readonly char CharacterToMatch;

        public Character(char character)
        {
            this.CharacterToMatch = character;
        }

        public IMatch Match(string inputText)
        {
            if (inputText.Length == 0)
                return new FailMatch(inputText);

            if (inputText[0] == CharacterToMatch)
                return new SuccesMatch(inputText.Substring(1));

            return new FailMatch(inputText);
        }
    }
}
