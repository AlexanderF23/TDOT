namespace The_Datamatikers_of_Tønder.Models;

public class Inventory
{
    private List<Item> _items = new List<Item>();
    
    // tilføj en genstand til inventory
    public void addItem(Item item)
    {
        _items.Add(item);
        Console.WriteLine($"You picked up {item.Name}.");
    }
    
    // fjern en genstand fra inventory
    public void RemoveItem(Item item)
    {
        if (_items.Remove(item))
        {
            Console.WriteLine($"{item.Name} has been removed from your inventory.");
        }
        else
        {
            Console.WriteLine($"{item.Name} is not in your inventory.");
        }
    }
    
    //find en genstand
    public Item FindItem(string itemName)
    {
        return _items.FirstOrDefault(i => i.Name.ToLower() == itemName.ToLower());
    }
    
    //vis inventory
    public void ShowInventory()
    {
        if (_items.Count > 0)
        {
            Console.WriteLine("You have the following items:");
            foreach (var item in _items)
            {
                Console.WriteLine(item.Name);
            }
        }
        else
        {
            Console.WriteLine("You have no items in your inventory.");
        }
    }
}