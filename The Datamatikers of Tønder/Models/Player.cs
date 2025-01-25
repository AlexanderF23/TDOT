namespace The_Datamatikers_of_Tønder.Models;

public class Player
{
    public string Name { get; set; }
    public Room CurrentRoom { get; set; }
    public Inventory Inventory { get; set; } = new Inventory();

    public Player(string name, Room startingRoom)
    {
        Name = name;
        CurrentRoom = startingRoom;
    }
}