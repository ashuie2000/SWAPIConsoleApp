
namespace DataAccess;

public interface IApiReader
{
    Task<string> ReadAsync(int limit, int page);
}