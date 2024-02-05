namespace DataProcess;

public interface ISearchQuote
{
    Task GetQoute(string word, IEnumerable<string> data, bool parallelOrNot);
}



