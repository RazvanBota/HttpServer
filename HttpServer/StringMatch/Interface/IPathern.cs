namespace HttpServer
{
    public interface IPattern
    {
        IMatch Match(string myString);
    }
}
