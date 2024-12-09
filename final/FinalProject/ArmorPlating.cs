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
        base.SetAbilityBonus(new Ability("Mobility", -mp));
    }

    static public ArmorPlating CreatePlating()
    {
        var i = CreateEquipmentBonus();
        Console.Write("Damage Reduction: ");
        int dr = Convert.ToInt32(Console.ReadLine());
        Console.Write("Mobility Penalty: ");
        int mp = Convert.ToInt32(Console.ReadLine());
        return new ArmorPlating(i, dr, mp);
    }

    public override void DisplayEquipment()
    {
        base.DisplayEquipment();
        Console.WriteLine($"Damage Reduction: {_damageReduction}");
        Console.WriteLine($"Mobility Penalty: {_mobilityPenalty}");
    }
    public int GetDamageReduction()
    {
        return _damageReduction;
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