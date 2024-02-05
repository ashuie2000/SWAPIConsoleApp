using DataAccess;
using DataProcess;
using UserInteraction;
using System.Diagnostics;


//The QuotesFinderApp console application interfaces with QuoteGarden API
//and provides the option to look for quotes by words.

//The primary objectiveof this project is to apply concepts of Asynchrony,
//multithreading and parallelism by utilizing .NET Task Parallel Library (TPL).



try
{
    var api = new QuoteFinderApp(
        new QuoteDataReader(new ApiReader(), new UserInteractor()),
        new SearchQuote(),
        new UserInteractor());

    api.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Something went wrong" + ex.Message);
}

// Code below can be uncommented to see performance difference between
// parallel and sequencial code in data retrival and processing


//var api = new ApiReader();

//var dataReader = new QuoteDataReader(api, new UserInteractor());

//var search = new SearchQuote();

//Console.WriteLine("fetching data in parallel... ");
//var time = Stopwatch.StartNew();
//var dataParallel =  await dataReader.FetchAsyncParallel(1000, 5);
//time.Stop();

//Console.WriteLine($"It took {time.ElapsedMilliseconds} milliseconds to fetch data in parallel");

//Console.WriteLine("Searching data in parallel... ");
//time.Start();
//await search.GetQoute("sea", dataParallel, true);
//time.Stop();
//Console.WriteLine($"It took {time.ElapsedMilliseconds} milliseconds to search quote in parallel");


//time.Start();
//Console.WriteLine("fetching data in sequence... ");
//var dataSequence = await dataReader.FetchAsyncSequencial(1000, 5);

//time.Stop();

//Console.WriteLine($"It took {time.ElapsedMilliseconds} milliseconds to fetch data in sequence");

//Console.WriteLine("Searching data in sequence... ");
//time.Start();
//await search.GetQoute("sea", dataSequence, false);
//time.Stop();
//Console.WriteLine($"It took {time.ElapsedMilliseconds} milliseconds to search quote in sequence");

Console.WriteLine("done!");

Console.ReadLine();



