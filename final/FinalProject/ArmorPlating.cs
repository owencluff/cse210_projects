public class ArmorPlating : Equipment
//Always has a penalty to mobility
{
    private int _damageReduction;
    private int _mobilityPenalty;

    public ArmorPlating() : base(("Basic Plating", 0, 15, 0, 0))
    {
        _damageReduction = 1;
        _mobilityPenalty = 15;
        base.SetAbilityBonus(new Ability("Mobility", -15));
    }
    public ArmorPlating((string, int, int, int, int) i, int dr, int mp) : base(i)
    /*
    n = name, a = attack bonus, de = defense bonus, dg = dodge bonus
    c = equip cost, dr = damage reduction, mp = mobility penalty
    mp is input and displayed as positive
    */
    {
        _damageReduction = dr;
        _mobilityPenalty = mp;
        SetAbilityBonus(new Ability("Mobility", -mp));
    }

    public override void CreateItem<ArmorPlating>()
    {
        var i = CreateEquipmentBonus();
        Console.Write("Damage Reduction: ");
        _damageReduction = Convert.ToInt32(Console.ReadLine());
        Console.Write("Mobility Penalty: ");
        _mobilityPenalty = Convert.ToInt32(Console.ReadLine());
        SetAttributes(i);
        Console.WriteLine();
    }

    public override void DisplayEquipment()
    {
        base.DisplayEquipment();
        Console.WriteLine($"Damage Reduction: {_damageReduction}");
        Console.WriteLine($"Mobility Penalty: {_mobilityPenalty}");
        Console.WriteLine();
    }
    public int GetDamageReduction()
    {
        return _damageReduction;
    }

    public override void UpgradeItem()
    {
        Console.WriteLine("Upgrade bonus, damage reduction, or mobility penalty?");
        Console.Write("(Bonus/Damage Reduction/Mobility Penalty)>| ");
        string answer = Console.ReadLine();
        Console.Write("How many times? ");
        int times = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < times; i++)
        {
            if (answer == "Bonus")
            {
                UpgradeBonus();
            }
            if (answer == "Damage Reduction")
            {
                _damageReduction += 1;
            }
            if (answer == "Mobility Penalty")
            {
                _mobilityPenalty -= 5;
            }
        }
        Console.WriteLine($"{answer} upgraded {times} time(s)");
    }

    public int ReduceDamage(int damage)
    {
        int result = damage - _damageReduction;
        if (result > 0)
        {
            return result;
        }
        else
        {
            return 0;
        }
    }
    public override string GetSaveData(string type)
    {
        string keeper = base.GetSaveData(type);
        keeper += $",DamageReduction:{_damageReduction},MobilityPenalty:{_mobilityPenalty}";
        return keeper;
    }
}