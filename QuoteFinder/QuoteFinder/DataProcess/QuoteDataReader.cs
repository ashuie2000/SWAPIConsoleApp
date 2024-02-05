using System.Diagnostics;
using DataAccess;
using UserInteraction;

namespace DataProcess;

public class QuoteDataReader : IQuoteDataReader
{
    private readonly IApiReader _reader;
    private readonly IUserInteractor _interactor;
    public QuoteDataReader(IApiReader reader, IUserInteractor interactor)
    {
        _reader = reader;
        _interactor = interactor;
    }

    //send a request in one go. we don't wait for the response of the first iteration to come back before we send the next one
    // with the WhenAll method we start to await after all the tasks have been started.
    public async Task<IEnumerable<string>> FetchAsyncParallel(int limit, int pages)
    {
        _interactor.ShowMessage("Parallel process intitiated... ");


        List<Task<string>> quotes = new();


        for (int i = 1; i <= pages; i++)
        {
            var fetchedData = _reader.ReadAsync(limit, i);
            quotes.Add(fetchedData);
        }

        return await Task.WhenAll(quotes);
    }


    // on this implementaion we await for each response to come before we send the next request;

    public async Task<IEnumerable<string>> FetchAsyncSequencial(int limit, int pages)
    {

        _interactor.ShowMessage("Sequencial process initiated... ");
    

        List<string> quotes = new();


        for (int i = 1; i <= pages; i++)
        {

            var fetchedData = await _reader.ReadAsync(limit, i);
            quotes.Add(fetchedData);
        }

        return quotes;
    }
}



