namespace UserInteraction;

public interface IUserInteractor
{
    string GetName();
    int GetNumber();
    void ShowMessage(string message);
    bool GetBool();
}