namespace The_Datamatikers_of_Tønder.Models;

public abstract class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public int ExperienceReward { get; set; }
    
    public Enemy(string name, int health, int attackPower, int experienceReward)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
        ExperienceReward = experienceReward;
    }

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} took {damage} damage!. Current health: {Health}");
        
        if (Health <= 0)
        {
            Console.WriteLine($"{Name} died!");
        }
    }
    
    public virtual void Attack(Player player)
    {
        Console.WriteLine($"{Name} attacks you for {AttackPower} damage!");
        player.TakeDamage(AttackPower);
    }
}

public class GymnasieElev : Enemy
{
    public GymnasieElev() : base("GymnasieElev", 5, 1, 5){ }

    public override void Attack(Player player)
    {
        Console.WriteLine($"{Name} Slår ud efter dig!");
        base.Attack(player);
    }
  
}

public class Pedel : Enemy
{
    public Pedel() : base("Pedel", 20, 7, 10){ }

    public override void Attack(Player player)
    {
        Console.WriteLine($"{Name} Slår ud efter dig med sin kost!");
        base.Attack(player);
    }
}