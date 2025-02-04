namespace The_Datamatikers_of_Tønder.Models;

public class Quest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    public string RequiredItem { get; set; } // Name of the item that is required to complete the quest
    
    public Quest(string name, string description, string requiredItem = null)
    {
        Name = name;
        Description = description;
        RequiredItem = requiredItem;
    }

    public bool CompleteQuest(Player player)
    {
        var item = player.Inventory.FindItem(RequiredItem);
        if (item != null)
        {
            IsCompleted = true;
            player.Inventory.RemoveItem(item);
            Console.WriteLine($"Du fandt {item.Name} og gav den til {Name}!");
            return true;
        }
        else
        {
            Console.WriteLine($"Du mangler {RequiredItem} for at hjælpe {Name}.");
            return false;
        }
    }
}