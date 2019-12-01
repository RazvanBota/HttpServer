namespace HttpServer
{
    public class Ipv4 : IPattern
    {
        public IMatch Match(string myString)
        {
            var digit = new Range('0', '9');
            var twoDigit = new Sequance(new Range('1', '9'), digit);
            var oneHundred = new Sequance(new Character('1'), digit, digit);
            var twoHundred = new Sequance(new Character('2'), new Range('0', '5'), new Range('0', '5'));
            var decOctet = new Choice(twoHundred, oneHundred, twoDigit, digit);
            var ip = new Sequance(decOctet, new Character('.'), decOctet, new Character('.'), decOctet, new Character('.'), decOctet);
            return ip.Match(myString);
        }
    }
}
