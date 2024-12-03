public class Weapon : Equipment
{
    private int _range;
    private int _damage;

    public Weapon(string n, int a, int de, int dg, int c, int r, int da) : base(n, a, de, dg, c)
    {
        _range = r;
        _damage = da;
    }

    public override void DisplayEquipment()
    {
        base.DisplayEquipment();
        Console.WriteLine($"Range: {_range}");
        Console.WriteLine($"Damage: {_damage}");
    }
    public int GetRange()
    {
        return _range;
    }
    public int GetDamage()
    {
        return _damage;
    }

    public int RollDamage()
    //Randomizes the damage roll between normal and 1.5X the standard damage.
    {
        var rand = new Random();
        double multiplier = 1 + rand.NextDouble() * 0.5;
        var result = _damage * multiplier;
        return Convert.ToInt32(result);
    }
}
