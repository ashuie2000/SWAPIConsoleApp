namespace UserInteraction;


//the User interactor class handles the interaction through the console.
public class UserInteractor : IUserInteractor
{
    public bool GetBool()
    {
        string? choice = Console.ReadLine();

        bool isValid = choice!.ToLower() != "y" || choice.ToLower() != "n";

        while (!isValid)
        {
            Console.WriteLine("Please select either Y or N");
            choice = Console.ReadLine();
        }

        return choice == "y";
    }
    public string GetName()
    {
        string name;
        bool isValid;
        do
        {
            name = Console.ReadLine()!;
            isValid = NameValidator(name!);
        } while (!isValid);

        return name!;
    }

    public int GetNumber()
    {
        int num;
        bool isValid;
        do
        {
            string? number = Console.ReadLine();

            isValid = int.TryParse(number, out num);

            if (!isValid)
                Console.WriteLine("Please Select a valid number");

        } while (!isValid);

        return num;
    }



    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    private bool NameValidator(string name)
    {
        if (name is null || name == string.Empty)
        {
            Console.WriteLine("Please enter a valid input");
            return false;
        }

        return true;
    }
}



