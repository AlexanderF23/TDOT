

using System.ComponentModel;
using System.Reflection.Metadata;
using The_Datamatikers_of_Tønder.Models;
using The_Datamatikers_of_Tønder.Services;
using The_Datamatikers_of_Tønder.UI;

class Program
{
    static void Main(string[] args)
    {
        //Rooms
        var undervisningslokale = new Room("Undervisningslokale", "Her bliver du undervist i forskellige emner inden for programmering.");
        var kantinelokale = new Room("Kantine", "Her kan du købe mad og drikke.");
        var gangen = new Room("Gangen", "Her kan du gå til de forskellige lokaler.");
        var toilet = new Room("Toilet", "Her kan du gå på toilettet.");
        var kontor = new Room("Kontor", "Her kan du snakke med din underviser.");
        var græskar = new Room("Græskar", "Græskaret er et lille lyd-isoleret rum hvor man kan lave opgaver eller hygge med andre.");
        var kælderen = new Room("Kælderen", "Kælderen er et mørkt og uhyggeligt sted");
        var cykelskur = new Room("Cykelskur", "Her kan du parkere din cykel.");
        
        
        //Map
        //underVisningsLokale
        undervisningslokale.Exits["North"] = toilet;
        undervisningslokale.Exits["South"] = gangen;
        undervisningslokale.Exits["East"] = græskar;
        undervisningslokale.Exits["West"] = kontor;
        //gangen
        gangen.Exits["North"] = undervisningslokale;
        gangen.Exits["South"] = cykelskur;
        gangen.Exits["East"] = kantinelokale; 
        gangen.Exits["Down"] = kælderen;
        //cykelskur
        cykelskur.Exits["North"] = gangen;
        cykelskur.Exits["South"] = kantinelokale;
        //toilet
        toilet.Exits["South"] = undervisningslokale;
        //kontor
        kontor.Exits["East"] = undervisningslokale;
        //græskar
        græskar.Exits["West"] = undervisningslokale;
        //kantinelokale
        kantinelokale.Exits["West"] = gangen;
        kantinelokale.Exits["North"] = cykelskur;
        //kælderen
        kælderen.Exits["Up"] = gangen;
        
        //items
        var blyant = new Item("Blyant", "En blyant til at skrive med.");
        var vrheadset = new Item("VR-headset", "Et VR-headset til at lave VR-programmering.");
        var computer = new Item("Computer", "En computer til at programmere på.");
        var papir = new Item("Papir", "Papir til at skrive noter på.");
        var banan = new Item("Banan", "En banan til at spise.");
        var key1 = new Item("Kontor-Nøgle", "En Nøgle til at låse op for Kontoret.");
        
        undervisningslokale.Items.Add(computer);
        undervisningslokale.Items.Add(vrheadset);
        kantinelokale.Items.Add(banan);
        kontor.Items.Add(papir);
        cykelskur.Items.Add(key1);
        
        
        //beholder i undervisningslokale
        var taske = new Containers("Taske", "En taske til at opbevare dine ting i.", isLocked: false, keyName: "TaskeNøgle");
        taske.Items.Add(blyant);
        undervisningslokale.Containers.Add(taske);
        
        //Quest
        var FindeKeyQuest = new Quest("Find nøglen", "Find nøglen til at låse op for kontor.", "Nøgle");
        
        //enemy
        kantinelokale.Enemies.Add(new GymnasieElev());
        kælderen.Enemies.Add(new Pedel());
        
        //NPC
        var erik = new NPC("Erik", "Din underviser", "Hej, jeg er din underviser. jeg har tabt min Nøgle til mit kontor", quest: FindeKeyQuest, key1);
        
        var player = new Player("Hero", cykelskur);
        var gameEngine = new GameEngine(player);
        
        Console.WriteLine("Velkommen til første dag som datamatik studerende i Tønder!");
        Console.WriteLine("skriv 'look' for at inspisere et lokale, eller 'go [direction]' for at bevæge dig.");

        while (true)
        {
            var command = ConsoleUI.GetInput();
            gameEngine.ProcessCommand(command);
        }
    }
}