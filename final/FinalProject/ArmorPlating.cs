public class ArmorPlating : Equipment
//Always has a penalty to mobility
{
    private int _damageReduction;
    private int _mobilityPenalty;

    public ArmorPlating(string n, int a, int de, int dg, int c, int dr, int mp) : base(n, a, de, dg, c)
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
}