

using System.Reflection.Metadata;
using The_Datamatikers_of_Tønder.Models;
using The_Datamatikers_of_Tønder.Services;
using The_Datamatikers_of_Tønder.UI;

class Program
{
    static void Main(string[] args)
    {
        var Undervisningslokale = new Room("UnderVisningsLokale", "her bliver du undervist i forskellige emner inde for programmering.");
        var  Erik = new NPC("Erik", "Din underviser", "Hej med dig, jeg er din underviser Erik.");
        Undervisningslokale.NPCs.Add(Erik);
        
        
        
        var Kantine = new Room("Kantine", "her kan du købe mad og drikke.");
        var  KantineDame = new NPC("KantineDame", "Damen i kantinen", "Hej med dig, jeg er damen i kantinen.");
        Kantine.NPCs.Add(KantineDame);
        
        Undervisningslokale.Exits["North"] = Kantine;
        Kantine.Exits["South"] = Undervisningslokale;
        
        var player = new Player("Hero", Undervisningslokale);
        var gameEngine = new GameEngine(player);
        
        Console.WriteLine("Welcome to the game!");
        Console.WriteLine("Type 'look' to inspect the room, or 'go [direction]' to move.");

        while (true)
        {
            var command = ConsoleUI.GetInput();
            gameEngine.ProcessCommand(command);
        }
    }
}