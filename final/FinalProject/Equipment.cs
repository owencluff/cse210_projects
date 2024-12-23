public abstract class Equipment
{
    private string _name;
    private int _attackBonus;
    private int _defenseBonus;
    private int _dodgeBonus;
    private int _equipCost;
    private Ability _abilityBonus;

    public Equipment()
    {
        _name = "Name";
        _attackBonus = 0;
        _defenseBonus = 0;
        _dodgeBonus = 0;
        _equipCost = 0;
        _abilityBonus = null;
    }
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
            int i = 0;
            do
            {
                try
                {
                    Console.Write("Attack Bonus: ");
                    ab = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Defense Bonus: ");
                    deb = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Dodge Bonus: ");
                    dgb = Convert.ToInt32(Console.ReadLine());
                    i ++;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            while(i == 0);
        }
        Console.Write("Equip Cost: ");
        int cost = Convert.ToInt32(Console.ReadLine());
        return (name, ab, deb, dgb, cost);
    }
    public virtual void CreateItem<T>() where T : Equipment
    {
        SetAttributes(("name", 0, 0, 0, 0));
    }
    static public Equipment CreateEquipment()
    {
        Equipment toAdd = null;
        Console.WriteLine("Create a weapon, shield, or armor plating?");
        Console.Write("(Weapon/Shield/ArmorPlating)>| ");
        string answer = Console.ReadLine();
        if (answer == "Weapon")
        {
            toAdd.CreateItem<Weapon>();
        }
        else if (answer == "Shield")
        {
            toAdd.CreateItem<Shield>();
        }
        else if (answer == "Armor Plating")
        {
            toAdd.CreateItem<ArmorPlating>();
        }
        else
        {
            Console.WriteLine("Unknown input");
        }
        return toAdd;
    }

    public virtual void SetAttributes((string, int, int, int, int) i)
    {
        _name = i.Item1;
        _attackBonus = i.Item2;
        _defenseBonus = i.Item3;
        _dodgeBonus = i.Item4;
        _equipCost = i.Item5;
        _abilityBonus = null;
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

    public abstract void UpgradeItem();
    public virtual void UpgradeBonus()
    {
        Console.WriteLine("Upgrade attack, defense, or dodge bonus?");
        Console.Write("(Attack/Defense/Dodge)>| ");
        string answer = Console.ReadLine();
        if (answer == "Attack")
        {
            _attackBonus += 5;
        }
        if (answer == "Defense")
        {
            _defenseBonus += 5;
        }
        if (answer == "Dodge")
        {
            _dodgeBonus += 5;
        }
    }

    public virtual string GetSaveData(string type)
    {
        string keeper = $"Equipment:{type}|Name:{_name},AttackBonus:{_attackBonus}";
        keeper += $",DefenseBonus:{_defenseBonus},DodgeBonus:{_dodgeBonus},EquipCost:{_equipCost}";
        return keeper;
    }
}