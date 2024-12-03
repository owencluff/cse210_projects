public class ArmorPlating : Equipment
//Always has a penalty to mobility
{
    private int _damageReduction;

    public ArmorPlating(int a, int de, int dg, int m, int c, int dr) : base(a, de, dg, m, c)
    {
        _damageReduction = dr;
    }

    public override void DisplayEquipment()
    {
        Console.WriteLine("Armor Plating");
        base.DisplayEquipment();
        Console.WriteLine($"Damage Reduction: {_damageReduction}");
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