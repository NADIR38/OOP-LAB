using System;
using System.Collections.Generic;

class Stats
{
    // Data members
    public string Name { get; }
    public double Damage { get; }
    public double Penetration { get; }
    public double Heal { get; }
    public double Cost { get; }
    public string Description { get; }

    // Constructor: note that the order is (name, damage, penetration, heal, cost, description)
    public Stats(string name, double damage, double penetration, double heal, double cost, string description)
    {
        Name = name;
        Damage = damage;
        Penetration = penetration;
        Heal = heal;
        Cost = cost;
        Description = description;
    }
}

class Player
{
    // Data members
    public string Name { get; private set; }
    public double Hp { get; private set; }
    public double MaxHp { get; }
    public double Energy { get; private set; }
    public double MaxEnergy { get; }
    public double Armor { get; private set; }
    
    // The learned skill (if any)
    private Stats skillStatistics;

    // Constructor: current health/energy become the initial maximum values if not provided separately
    public Player(string name, double currentHp, double maxHp, double currentEnergy, double maxEnergy, double armor)
    {
        Name = name;
        Hp = currentHp;
        MaxHp = maxHp;
        Energy = currentEnergy;
        MaxEnergy = maxEnergy;
        Armor = armor;
    }

    // Methods to update player properties ensuring values remain within [0, max] bounds.
    public void UpdateHealth(double newHealth)
    {
        Hp = Math.Max(0, Math.Min(newHealth, MaxHp));
    }

    public void UpdateEnergy(double newEnergy)
    {
        Energy = Math.Max(0, Math.Min(newEnergy, MaxEnergy));
    }

    public void UpdateArmor(double newArmor)
    {
        // Armor is clamped between 0 and 100.
        Armor = Math.Max(0, Math.Min(newArmor, 100));
    }

    public void UpdateName(string newName)
    {
        Name = newName;
    }

    // learnSkill method: assign the given skill to the player.
    public void LearnSkill(Stats skill)
    {
        skillStatistics = skill;
        Console.WriteLine($"{Name} learned skill: {skill.Name}");
    }

    // attack method: perform an attack on a target player.
    public string Attack(Player target)
    {
        // Check if a skill is learned.
        if (skillStatistics == null)
            return $"{Name} has not learned any skill yet!";

        // Energy check.
        if (Energy < skillStatistics.Cost)
            return $"{Name} attempted to use {skillStatistics.Name}, but didn't have enough energy!";

        // Deduct the energy cost.
        UpdateEnergy(Energy - skillStatistics.Cost);

        // Calculate effective armor: subtract penetration from target's armor.
        double effectiveArmor = target.Armor - skillStatistics.Penetration;
        effectiveArmor = effectiveArmor < 0 ? 0 : effectiveArmor;
        effectiveArmor = effectiveArmor > 100 ? 100 : effectiveArmor;

        // Each percent of effective armor reduces damage by 1%.
        double damageMultiplier = (100 - effectiveArmor) / 100;
        double finalDamage = skillStatistics.Damage * damageMultiplier;

        // Apply damage to the target.
        target.UpdateHealth(target.Hp - finalDamage);

        // Heal the attacker if applicable.
        UpdateHealth(Hp + skillStatistics.Heal);

        // Build the result string.
        string result = $"{Name} used {skillStatistics.Name}, {skillStatistics.Description}, against {target.Name}, doing {finalDamage:F2} damage!";
        if (skillStatistics.Heal > 0)
            result += $" {Name} healed for {skillStatistics.Heal} health!";
        if (target.Hp == 0)
            result += $" {target.Name} died.";
        else
        {
            double hpPerc = (target.Hp / target.MaxHp) * 100;
            result += $" {target.Name} is at {hpPerc:F2}% health.";
        }
        return result;
    }
}

class Program
{
    static List<Player> players = new List<Player>();
    static List<Stats> skills = new List<Stats>();

    static void Main()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Player");
            Console.WriteLine("2. Add Skill Statistics");
            Console.WriteLine("3. Display Player Info");
            Console.WriteLine("4. Learn a Skill");
            Console.WriteLine("5. Attack");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddPlayer();
                    break;
                case "2":
                    AddSkill();
                    break;
                case "3":
                    DisplayPlayers();
                    break;
                case "4":
                    LearnSkill();
                    break;
                case "5":
                    Attack();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    // Option 1: Add Player
    static void AddPlayer()
    {
        Console.Write("Enter player name: ");
        string name = Console.ReadLine();
        Console.Write("Enter current health: ");
        double currentHp = double.Parse(Console.ReadLine());
        Console.Write("Enter max health: ");
        double maxHp = double.Parse(Console.ReadLine());
        Console.Write("Enter current energy: ");
        double currentEnergy = double.Parse(Console.ReadLine());
        Console.Write("Enter max energy: ");
        double maxEnergy = double.Parse(Console.ReadLine());
        Console.Write("Enter armor (0-100): ");
        double armor = double.Parse(Console.ReadLine());
        players.Add(new Player(name, currentHp, maxHp, currentEnergy, maxEnergy, armor));
        Console.WriteLine("Player added successfully!");
    }

    // Option 2: Add Skill Statistics
    static void AddSkill()
    {
        Console.Write("Enter skill name: ");
        string name = Console.ReadLine();
        Console.Write("Enter damage: ");
        double damage = double.Parse(Console.ReadLine());
        Console.Write("Enter penetration: ");
        double penetration = double.Parse(Console.ReadLine());
        Console.Write("Enter heal amount: ");
        double heal = double.Parse(Console.ReadLine());
        Console.Write("Enter cost: ");
        double cost = double.Parse(Console.ReadLine());
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        skills.Add(new Stats(name, damage, penetration, heal, cost, description));
        Console.WriteLine("Skill added successfully!");
    }

    // Option 3: Display Player Info
    static void DisplayPlayers()
    {
        foreach (Player p in players)
        {
            Console.WriteLine($"Name: {p.Name}, Health: {p.Hp}/{p.MaxHp}, Energy: {p.Energy}/{p.MaxEnergy}, Armor: {p.Armor}");
        }
    }

    // Option 4: Learn a Skill
    static void LearnSkill()
    {
        Console.Write("Enter player name: ");
        string playerName = Console.ReadLine();
        Console.Write("Enter skill name: ");
        string skillName = Console.ReadLine();

        Player player = players.Find(p => p.Name.Equals(playerName, StringComparison.OrdinalIgnoreCase));
        Stats skill = skills.Find(s => s.Name.Equals(skillName, StringComparison.OrdinalIgnoreCase));

        if (player == null)
        {
            Console.WriteLine("Player not found.");
            return;
        }
        if (skill == null)
        {
            Console.WriteLine("Skill not found.");
            return;
        }
        player.LearnSkill(skill);
    }

    // Option 5: Attack
    static void Attack()
    {
        Console.Write("Enter attacker name: ");
        string attackerName = Console.ReadLine();
        Console.Write("Enter target name: ");
        string targetName = Console.ReadLine();

        Player attacker = players.Find(p => p.Name.Equals(attackerName, StringComparison.OrdinalIgnoreCase));
        Player target = players.Find(p => p.Name.Equals(targetName, StringComparison.OrdinalIgnoreCase));

        if (attacker == null || target == null || attacker == target)
        {
            Console.WriteLine("Invalid attacker or target.");
            return;
        }

        Console.WriteLine(attacker.Attack(target));
    }
}
