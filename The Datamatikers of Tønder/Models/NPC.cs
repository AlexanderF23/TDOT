namespace The_Datamatikers_of_Tønder.Models;

public class NPC
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Dialogue { get; set; }
    public Quest AssignedQuest { get; set; }
    public bool HasKey { get; set; } = false;
    public Item KeyItem { get; set; }
    
    
    public NPC(string name, string description, string dialogue, Quest quest = null, Item item = null)
    {
        Name = name;
        Description = description;
        Dialogue = dialogue;
        AssignedQuest = quest;
        KeyItem = item;
        {
            HasKey = true;
            KeyItem = keyItem;
        }
    }
    
    public void Speak()
    {
        Console.WriteLine($"{Name} says: \"{Dialogue}\"");
        
        if (AssignedQuest != null)
        {
            Console.WriteLine($"Quest: {AssignedQuest.Name} - {AssignedQuest.Description}");
        }
        else if (HasKey && AssignedQuest != null && AssignedQuest.IsCompleted)
        {
            Console.WriteLine($"{Name} giver dig {KeyItem.Name}");
            Player.Inventory.addItem(KeyItem);
            HasKey = false;
        }
    }

    public void CheckQuestCompletion(Player player)
    {
        if (AssignedQuest != null && !AssignedQuest.IsCompleted)
        {
            if (AssignedQuest.IsCompleted(player))
            {
                Console.WriteLine($"{Name} says: \"{AssignedQuest.Name} er fuldført!\"");
                HasKey = true; // The NPC now has the key
            }
        }
    }
    
}