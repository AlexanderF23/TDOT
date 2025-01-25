namespace The_Datamatikers_of_Tønder.Models
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Room> Exits { get; set; }
        
        public List<Item> Items { get; set; } = new List<Item>();

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Exits = new Dictionary<string, Room>();
        }
    }
}