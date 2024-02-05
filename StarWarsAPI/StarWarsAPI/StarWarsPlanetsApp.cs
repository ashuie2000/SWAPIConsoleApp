using StarWarsAPI;
using StarWarsAPI.DTOs;
using StarWarsAPI.Models;
using StarWarsAPI.PlanetFacts;
using StarWarsAPI.PlanetStats;
using StarWarsAPI.UserInteractor;
using StarWarsAPI.Utilities;

public partial class StarWarsPlanetsApp
{
    private readonly IAnyApiReader _apiReader;
    private readonly IJsonDeserializer _jsonDeserializer;
    private readonly IConsoleInteractor _consoleInteractor;

    public StarWarsPlanetsApp(IAnyApiReader apiReader,
        IJsonDeserializer jsonDeserializer,
        IConsoleInteractor consoleInteractor)
    {
        _apiReader = apiReader;
        _jsonDeserializer = jsonDeserializer;
        _consoleInteractor = consoleInteractor;
    }


    public async Task Run()
    {
        string BaseUrl = "https://swapi.dev/api/";
        string PlanetUrl = "planets/";

        var response = await _apiReader.Read(BaseUrl, PlanetUrl);

        Root? root = _jsonDeserializer.Deserialize<Root>(response);

        var allPlanets = DTOtoPlanetEntity.Convert(root);

        _consoleInteractor.PrintTable(allPlanets);

        _consoleInteractor.PrintMessage("What statistics would you like to see? Please choose from the options below");

        var planetSelectionOptions = PlanetSelection.Options();
        _consoleInteractor.PrintMessage(string.Join(Environment.NewLine, planetSelectionOptions.Keys));

        string choice = _consoleInteractor.GetValidUserChoice(planetSelectionOptions.Keys);


        _consoleInteractor.PrintMessage(PlanetStat.Get(choice, allPlanets, planetSelectionOptions[choice]));

        _consoleInteractor.PrintMessage("Press any key to exit");
        Console.ReadKey();
    }

}
