public class Weapon : Equipment
{
    private int _range;
    private int _damage;

    public Weapon() : base(("Rifle", 15, 0, 0, 1))
    {
        _range = 30;
        _damage = 1;
    }
    public Weapon((string, int, int, int, int) i, int r, int da) : base(i)
    {
        _range = r;
        _damage = da;
    }

    public override void CreateItem<Weapon>()
    {
        var i = CreateEquipmentBonus();
        Console.Write("Range: ");
        _range = Convert.ToInt32(Console.ReadLine());
        Console.Write("Damage: ");
        _damage = Convert.ToInt32(Console.ReadLine());
        SetAttributes(i);
        Console.WriteLine();
    }

    public override void DisplayEquipment()
    {
        base.DisplayEquipment();
        Console.WriteLine($"Range: {_range}");
        Console.WriteLine($"Damage: {_damage}");
        Console.WriteLine();
    }
    public int GetRange()
    {
        return _range;
    }
    public int GetDamage()
    {
        return _damage;
    }

    public override void UpgradeItem()
    {
        Console.WriteLine("Upgrade bonus, range, or damage?");
        Console.Write("(Bonus/Range/Damage)>| ");
        string answer = Console.ReadLine();
        Console.Write("How many times? ");
        int times = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < times; i ++)
        {
            if (answer == "Bonus")
            {
                base.UpgradeBonus();
            }
        if (answer == "Range")
            {
                _range += 5;
            }
        if (answer == "Damage")
            {
                _damage += 1;
            }
        }
    }

    public int RollDamage()
    //Randomizes the damage roll between normal and 2 the standard damage.
    {
        var rand = new Random();
        double multiplier = 1 + rand.NextDouble();
        var result = _damage * multiplier;
        return Convert.ToInt32(result);
    }

    public override string GetSaveData(string type)
    {
        string keeper = base.GetSaveData(type);
        keeper += $",Range:{_range},Damage:{_damage}";
        return keeper;
    }
}
