namespace The_Datamatikers_of_Tønder.Models;

public class Containers
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsLocked { get; set; } = false;
    public string KeyName { get; set; } // Name of the key that unlocks the container
    public List<Item> Items { get; set; } = new List<Item>();

    public Containers(string name, string description, bool isLocked = false, string keyName = null)
    {
        Name = name;
        Description = description;
        IsLocked = isLocked;
        KeyName = keyName;
        Items = new List<Item>();
    }

    public void Open(Player player)
    {
        if (IsLocked)
        {
            Console.WriteLine($"The {Name} is locked. You need a {KeyName} to unlock it.");
            return;
        }

        if (Items.Count > 0)
        {
            Console.WriteLine($"You open the {Name} and find the following items:");
            foreach (var item in Items)
            {
                Console.WriteLine($"- {item.Name}");
            }
        }
        else
        {
            Console.WriteLine($"There are no items in the {Name}.");
        }
    }
}