namespace The_Datamatikers_of_Tønder.UI;

public static class ConsoleUI
{
    public static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
    
    public static string GetInput()
    {
        Console.Write("> ");
        return Console.ReadLine();
    }
}