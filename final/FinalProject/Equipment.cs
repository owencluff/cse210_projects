public abstract class Equipment
{
    private string _name;
    private int _attackBonus;
    private int _defenseBonus;
    private int _dodgeBonus;
    private int _equipCost;
    private Ability _abilityBonus;

    public Equipment((string, int, int, int, int) i)
    {
        _name = i.Item1;
        _attackBonus = i.Item2;
        _defenseBonus = i.Item3;
        _dodgeBonus = i.Item4;
        _equipCost = i.Item5;
        _abilityBonus = null;
    }

    static public (string, int, int, int, int) CreateEquipmentBonus()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        int ab = 0;
        int deb = 0;
        int dgb = 0;
        Console.WriteLine("Does this have any bonuses?");
        Console.Write("(y/n)>| ");
        string response = Console.ReadLine();
        if (response == "y")
        {
            Console.Write("Attack Bonus: ");
            ab = Convert.ToInt32(Console.ReadLine());
            Console.Write("Defense Bonus: ");
            deb = Convert.ToInt32(Console.ReadLine());
            Console.Write("Dodge Bonus: ");
            dgb = Convert.ToInt32(Console.ReadLine());
        }
        Console.Write("Equip Cost: ");
        int cost = Convert.ToInt32(Console.ReadLine());
        return (name, ab, deb, dgb, cost);
    }

    public virtual void DisplayEquipment()
    {
        Console.WriteLine($"{_name}:");
        Console.WriteLine($"Attack Bonus: {_attackBonus}");
        Console.WriteLine($"Defense Bonus: {_defenseBonus}");
        Console.WriteLine($"Dodge Bonus: {_dodgeBonus}");
        Console.WriteLine($"Equip Cost: {_equipCost}");
    }
    public virtual string GetName()
    {
        return _name;
    }
    public virtual int GetAttackBonus()
    {
        return _attackBonus;
    }
    public virtual int GetDefenseBonus()
    {
        return _defenseBonus;
    }
    public virtual int GetDodgeBonus()
    {
        return _dodgeBonus;
    }
    public virtual int GetEquipCost()
    {
        return _equipCost;
    }
    public void SetAbilityBonus(Ability a)
    {
        _abilityBonus = a;
    }
    public Ability GetAbilityBonus()
    {
        return _abilityBonus;
    }
}