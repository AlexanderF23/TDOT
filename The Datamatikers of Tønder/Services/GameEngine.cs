﻿using System.Runtime.CompilerServices;
using The_Datamatikers_of_Tønder.Models;


namespace The_Datamatikers_of_Tønder.Services;

public class GameEngine
{
    private Player _player;
    
    public GameEngine(Player player)
    {
        _player = player;
    }

    public void ProcessCommand(string command)
    {
        var words = command.Split(' ');
        var action = words[0].ToLower();

        switch (action)
        {
            case "look":
                Console.WriteLine(_player.CurrentRoom.Description);
                if (_player.CurrentRoom.Items.Count > 0)
                {
                    Console.WriteLine("You see the following items:");
                    foreach (var item in _player.CurrentRoom.Items)
                    {
                        Console.WriteLine(item.Name);
                    }
                }
                else
                {
                    Console.WriteLine("There are no items in this room.");
                }
                break;
            
            
            case "go":
                if (words.Length > 1 && _player.CurrentRoom.Exits.ContainsKey(words[1]))
                {
                    _player.CurrentRoom = _player.CurrentRoom.Exits[words[1]];
                    Console.WriteLine($"you enter {_player.CurrentRoom.Name}");
                }
                else
                {
                    Console.WriteLine("You can't go that way");
                }
                break;
            
            
            case "inventory":
                _player.Inventory.ShowInventory();
                break;
            
            
            case "use":
                if (words.Length > 1)
                {
                    var itemName = string.Join(" ", words.Skip(1));
                    var item = _player.Inventory.FindItem(itemName);
                    if (item != null)
                    {
                        Console.WriteLine($"You used {item.Name}.");
                        
                        if (item.Name.ToLower() == "key")
                        {
                            Console.WriteLine("You unlocked the door!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You don't have that item.");
                    }
                }
                else
                {
                    Console.WriteLine("You must specify an item to use.");
                }
                break;
            
            case "talk":
                if (words.Length > 1)
                {
                    var npcName = string.Join(" ", words.Skip(1));
                    var npc = _player.CurrentRoom.NPCs.FirstOrDefault(n => n.Name.ToLower() == npcName.ToLower());
                    if (npc != null)
                    {
                        npc.Speak();
                    }
                    else
                    {
                        Console.WriteLine("There's no one here by that name.");
                    }
                }
                else
                {
                    Console.WriteLine("You must specify an NPC to talk to.");
                }
                break;
            
            case "inspect":
                if (words.Length > 1)
                {
                    var npcName = string.Join(" ", words.Skip(1));
                    var npc = _player.CurrentRoom.NPCs.FirstOrDefault(n => n.Name.ToLower() == npcName.ToLower());
                    if (npc != null)
                    {
                        Console.WriteLine($"{npc.Name}: {npc.Description}");
                    }
                    else
                    {
                        Console.WriteLine("There's no one here by that name.");
                    }
                }
                else
                {
                    Console.WriteLine("You must specify an NPC to inspect.");
                }
                break;
                    
            
            
            
            case "attack":
                if (words.Length > 1)
                {
                    var npcName = string.Join("", words.Skip(1));
                    var npc = _player.CurrentRoom.NPCs.FirstOrDefault(n => n.Name.ToLower() == npcName.ToLower());
                    if (npc != null)
                    {
                        Console.WriteLine($"You attack {npc.Name}!");
                        _player.GainExperience(5);
                        _player.CurrentRoom.NPCs.Remove(npc);
                    }
                    else
                    {
                        Console.WriteLine("There's no one here by that name.");
                    }
                }
                else
                {
                    Console.WriteLine("You must specify an NPC to attack.");
                }
                break;
            
            
            
            
            
            
            case "open":
                if (words.Length > 1)
                {
                    var containerName = string.Join(" ", words.Skip(1));
                    var container = _player.CurrentRoom.Containers.FirstOrDefault(c => c.Name.ToLower() == containerName.ToLower());
                    if (container != null)
                    {
                        container.Open(_player);
                    }
                    else
                    {
                        Console.WriteLine("There's no such container here.");
                    }
                }
                else
                {
                    Console.WriteLine("open WHAT?");
                }
                break;
            
            case "take":
                if (words.Length > 2 && words[1].ToLower() == "from")
                {
                    var itemName = string.Join(" ", words.Skip(3));
                    var containerName = words[2];
                    var container = _player.CurrentRoom.Containers.FirstOrDefault(c => c.Name.ToLower() == containerName.ToLower());
                    
                    if (container != null)
                    {
                        var item = container.Items.FirstOrDefault(i => i.Name.ToLower() == itemName.ToLower());
                        if (item != null)
                        {
                            _player.Inventory.addItem(item);
                            container.Items.Remove(item);
                            Console.WriteLine($"You took {item.Name} from the {container.Name}.");
                        }
                        else
                        {
                            Console.WriteLine($"the {container.Name} does not contain that item.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("There's no such container here.");
                    }
                }

                break;
            
            
            
            case "stats":
                Console.WriteLine($"Level: {_player.Level}");
                Console.WriteLine($"XP: {_player.Experience}/{_player.ExperienceToNextLevel}");
                break;


            case "help":
                Console.WriteLine("available commands:");
                Console.WriteLine("- look: inspect the room");
                Console.WriteLine("- go [direction]: move to another room");
                Console.WriteLine("- take [item]: pick up an item");
                Console.WriteLine("- inventory: show your inventory");
                Console.WriteLine("- use [item]: use an item");
                Console.WriteLine("- help: show available commands");
                break;
            
            
            default:
                Console.WriteLine("i don't understand that command");
                break;
            
           
            
        }
    }
}
