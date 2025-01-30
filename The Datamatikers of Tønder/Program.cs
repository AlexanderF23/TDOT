

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
        var undervisningslokale = new Room("UnderVisningsLokale", "her bliver du undervist i forskellige emner inde for programmering.");
        //npc
        var  erik = new NPC("Erik", "Din underviser", "Hej med dig, jeg er din underviser Erik.");
        //container
        var taske = new Containers("Taske", "En taske til at opbevare dine ting i.", isLocked: false, keyName: "TaskeNøgle");
        taske.Items.Add(new Item("Blyant", "En blyant til at skrive med."));
        
        undervisningslokale.NPCs.Add(erik);
        undervisningslokale.Containers.Add(taske);
        
        
        
        //rooms
        var kantine = new Room("Kantine", "her kan du købe mad og drikke.");
        //npc
        var  kantineDame = new NPC("KantineDame", "Damen i kantinen", "Hej med dig, jeg er damen i kantinen.");
        //Enemy
        var gymnasiestuderende = new Enemy("Gymnasiestuderende", 10, 2, 5);
        //container
       
        
        kantine.NPCs.Add(kantineDame);
        kantine.Enemies.Add(gymnasiestuderende);
        
        
        
        undervisningslokale.Exits["North"] = kantine;
        kantine.Exits["South"] = undervisningslokale;
        
        var player = new Player("Hero", undervisningslokale);
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