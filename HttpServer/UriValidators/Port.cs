namespace HttpServer
{
    public class Port : IPattern 
    {
        public IMatch Match(string myString)
        {
            var digit = new Range('0', '9');
            var maxPort = new Sequance(new Range('6', '6'), new Range('5', '5'), new Range('0', '5'), new Range('0', '3'), new Range('0', '5'));
            var maxPortTwo = new Sequance(new Range('0', '6'), new Range('0', '4'), new Many(digit, 1, 4));
            var port = new Sequance(new Character(':'), new Choice(maxPort, maxPortTwo, new Many(digit, 1, 4)));
            return port.Match(myString);
        }
    }
}
