namespace The_Datamatikers_of_Tønder.Models;

public class Player
{
    public string Name { get; set; }
    public Room CurrentRoom { get; set; }
    public Inventory Inventory { get; set; } = new Inventory();
    public int Level { get; set; } = 1; // starts at Level 1
    public int Experience { get; set; } = 0; // starts at 0
    public int ExperienceToNextLevel { get; set; } = 10; // starts at 10
    public int Health { get; set; } = 20; // starts at 100
    public int AttackPower { get; set; } = 5; // starts at 5
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
        Health += 5;
        AttackPower += 2;
        
        Console.WriteLine($"You leveled up to level {Level}!");
        Console.WriteLine($"your health increased to {Health} and your attack power increased to {AttackPower}");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"You took {damage} damage!. Current health: {Health}");
        
        if (Health <= 0)
        {
            Console.WriteLine("You died!");
            Environment.Exit(0); // Ends game
        }
    }
    
    
    
    
    
}