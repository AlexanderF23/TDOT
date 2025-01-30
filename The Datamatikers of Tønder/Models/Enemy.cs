namespace The_Datamatikers_of_Tønder.Models;

public class Enemy
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

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} took {damage} damage!. Current health: {Health}");
        
        if (Health <= 0)
        {
            Console.WriteLine($"{Name} died!");
        }
    }
    
    public void Attack(Player player)
    {
        Console.WriteLine($"{Name} attacks you for {AttackPower} damage!");
        player.TakeDamage(AttackPower);
    }
}