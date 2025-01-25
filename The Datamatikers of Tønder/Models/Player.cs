namespace The_Datamatikers_of_Tønder.Models;

public class Player
{
    public string Name { get; set; }
    public Room CurrentRoom { get; set; }
    public List<Item> Items { get; set; } = new List<Item>();

    public Player(string name, Room startingRoom)
    {
        Name = name;
        CurrentRoom = startingRoom;
    }
}