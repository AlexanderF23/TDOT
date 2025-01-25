namespace The_Datamatikers_of_Tønder.Models;

public class Room
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Dictionary<string, Room> Exit { get; set; } = new Dictionary<string, Room>();
}