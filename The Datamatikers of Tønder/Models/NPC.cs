namespace The_Datamatikers_of_Tønder.Models;

public class NPC
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Dialogue { get; set; }
    public bool IsHostile { get; set; } = false;
    
    
    public NPC(string name, string description, string dialogue)
    {
        Name = name;
        Description = description;
        Dialogue = dialogue;
    }
    
    public void Speak()
    {
        Console.WriteLine($"{Name} says: \"{Dialogue}\"");
    }
    
    public void Attack(Player player)
    {
        Console.WriteLine($"{Name} attacks {player.Name}!");
    }
    
}