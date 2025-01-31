namespace The_Datamatikers_of_Tønder.Models
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Room> Exits { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public List<NPC> NPCs { get; set; } = new List<NPC>();
        public List<Containers> Containers { get; set; } = new List<Containers>();
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();
        public bool IsLocked { get; set; } = false;
        public string RequiredKey { get; set; }
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Exits = new Dictionary<string, Room>();
            IsLocked = IsLocked;
            RequiredKey = RequiredKey;
        }

        public bool TryUnlock(Player player)
        {
            if (IsLocked && player.Inventory.FindItem(RequiredKey) != null)
            {
                IsLocked = false;
                Console.WriteLine($"du åbnede {Name} med {RequiredKey}");
                return true;
            }
            else
            {
                Console.WriteLine($"{Name} er låst. du skal bruge {RequiredKey} for at låse {Name} op.");
                return false;
            }
        }
    }
}