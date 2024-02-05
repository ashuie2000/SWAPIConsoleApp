using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;
using DTOs;
using UserInteraction;

namespace DataProcess;


public class SearchQuote : ISearchQuote
{
    
    public async Task GetQoute(string wordToBeFound, IEnumerable<string> jsonData, bool isParallel)
    {
        if(isParallel)
        {
            var taskQuote = jsonData.Select(page => Task.Run(() => ProcessPage(page, wordToBeFound)));
       
            await Task.WhenAll(taskQuote);
            
        }else
        {

            foreach (var page in jsonData)
            {
                ProcessPage(page, wordToBeFound);
            }

        }

        
    }

    private static void ProcessPage(string page, string wordToBeFound)
    {
        
        string pattern = @"\b" + Regex.Escape(wordToBeFound) + @"\b";

        var rootDto = JsonSerializer.Deserialize<Root>(page);

        var matchQuotes = rootDto?.data
            .Where(quote => Regex.Match(quote.quoteText, pattern, RegexOptions.IgnoreCase).Success == true)
            .MinBy(shotQuote => shotQuote.quoteText.Length);

        if(matchQuotes is not null)
        {
            Console.WriteLine(matchQuotes.quoteText +" -- by " + matchQuotes.quoteAuthor);
        }
        else
        {
            Console.WriteLine("No quote found on this page");
        }

    }
}



