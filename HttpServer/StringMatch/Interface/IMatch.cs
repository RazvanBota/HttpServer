namespace HttpServer
{
    public interface IMatch
    {
        bool IsSuccesful();
        string RemainingText();
    }
}
