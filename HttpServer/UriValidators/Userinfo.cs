namespace HttpServer
{
    public class Userinfo : IPattern
    {
        public IMatch Match(string myString)
        {
            Choice alpha = new Choice(new Range('a', 'z'), new Range('A', 'Z'));
            Range digit = new Range('0', '9');
            Choice unreserved = new Choice(alpha, digit, new Any("-._~"));
            Any subDelims = new Any("!$&'()*+,;=");
            Sequance usserInfo = new Sequance(unreserved, new Many(new Choice(unreserved, subDelims)), new Character(':'));
            return usserInfo.Match(myString);
        }
    }
}
