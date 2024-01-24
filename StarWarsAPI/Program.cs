using StarWarsAPI;
using StarWarsAPI.UserInteractor;

try
{
    var app = new StarWarsPlanetsApp(new AnyApiReader(),
        new JsonDeserializer(),
        new ConsoleInteractor());
    await app.Run();
}catch(Exception ex)
{
    Console.WriteLine("Sorry, the application crashed and needs to close.");
    Console.WriteLine(ex.Message);
}
