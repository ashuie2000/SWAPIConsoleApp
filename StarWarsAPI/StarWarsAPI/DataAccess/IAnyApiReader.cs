namespace StarWarsAPI
{
    public interface IAnyApiReader
    {
        Task<string> Read(string baseUrl, string requestApi);
    }
}