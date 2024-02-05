namespace DataProcess;

public interface IQuoteDataReader
{
    Task<IEnumerable<string>> FetchAsyncParallel(int limit, int pages);
    Task<IEnumerable<string>> FetchAsyncSequencial(int limit, int pages);
}