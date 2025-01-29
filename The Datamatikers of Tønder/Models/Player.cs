namespace The_Datamatikers_of_Tønder.Models;

public class Player
{
    public string Name { get; set; }
    public Room CurrentRoom { get; set; }
    public Inventory Inventory { get; set; } = new Inventory();
    
    public int Level { get; set; } = 1; // starts at Level 1
    
    public int Experience { get; set; } = 0; // starts at 0
    
    public int ExperienceToNextLevel { get; set; } = 10; // starts at 10

    public Player(string name, Room startingRoom)
    {
        Name = name;
        CurrentRoom = startingRoom;
    }

    public void GainExperience(int amount)
    {
        Experience += amount;
        Console.WriteLine($"You gained {amount} experience!");
        
        if (Experience >= ExperienceToNextLevel)
        {
            LevelUp();
        }
        
    }
    
    public void LevelUp()
    {
        Level++;
        Experience -= ExperienceToNextLevel;
        ExperienceToNextLevel = (int)(ExperienceToNextLevel * 1.5);
        Console.WriteLine($"You leveled up to level {Level}!");
    }
    
    
    
    
    
}