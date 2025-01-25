

using System.ComponentModel;
using System.Reflection.Metadata;
using The_Datamatikers_of_Tønder.Models;
using The_Datamatikers_of_Tønder.Services;
using The_Datamatikers_of_Tønder.UI;

class Program
{
    static void Main(string[] args)
    {
        //rooms
        var Undervisningslokale = new Room("UnderVisningsLokale", "her bliver du undervist i forskellige emner inde for programmering.");
        //npc
        var  Erik = new NPC("Erik", "Din underviser", "Hej med dig, jeg er din underviser Erik.");
        
        //container
        var Taske = new Containers("Taske", "En taske til at opbevare dine ting i.", isLocked: false, keyName: "TaskeNøgle");
        Taske.Items.Add(new Item("Blyant", "En blyant til at skrive med."));
        
        Undervisningslokale.NPCs.Add(Erik);
        Undervisningslokale.Containers.Add(Taske);
        
        
        
        
        var Kantine = new Room("Kantine", "her kan du købe mad og drikke.");
        var  KantineDame = new NPC("KantineDame", "Damen i kantinen", "Hej med dig, jeg er damen i kantinen.");
        var køleskab = new Container("Køleskab", "Et køleskab til at opbevare mad og drikke i.");
        køleskab.Items.Add(new Item("Mælk", "En liter mælk."));
        Kantine.NPCs.Add(KantineDame);
        Kantine.Containers.Add(køleskab);
        
        
        
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