namespace StarWarsAPI.UserInteractor
{
    public interface IConsoleInteractor
    {
        string GetValidUserChoice(IEnumerable<string> choice);
        void PrintMessage(string message);
        void PrintTable<T>(IEnumerable<T> data);
    }
}