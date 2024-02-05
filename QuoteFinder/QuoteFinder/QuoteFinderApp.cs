using DataProcess;
using UserInteraction;

public class QuoteFinderApp
{
    private readonly IQuoteDataReader _reader;
    private readonly ISearchQuote _search;
    private readonly IUserInteractor _interactor;

    public QuoteFinderApp(IQuoteDataReader reader,
        ISearchQuote search,
        IUserInteractor interactor)
    {
        _reader = reader;
        _search = search;
        _interactor = interactor;
    }
    public void Run()
    {
        _interactor.ShowMessage("What quote are you looking for?, Please enter a word to look for.");

        string quoteName = _interactor.GetName();

        _interactor.ShowMessage("How many pages of the quotes to look for?");

        int page = _interactor.GetNumber();

        _interactor.ShowMessage("How many quotes on each page?");

        int size = _interactor.GetNumber();

        _interactor.ShowMessage("Would you like the data procesing to be performed in Parallel or Series? Select Y for Parallel and N for Series");

        bool parallel = _interactor.GetBool();


        if(parallel)
        {
          
          var data = _reader.FetchAsyncParallel(size, page);
                
            _search.GetQoute(quoteName, data.Result, parallel);

        }
        else
        {
        
            var data = _reader.FetchAsyncSequencial(size, page);
       
            _search.GetQoute(quoteName, data.Result, parallel);
        }
    }
}



