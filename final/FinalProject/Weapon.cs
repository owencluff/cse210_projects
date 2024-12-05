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

    static public Weapon CreateWeapon()
    {
       var i = CreateEquipmentBonus();
       Console.Write("Range: ");
       int r = Convert.ToInt32(Console.ReadLine());
       Console.Write("Damage: ");
       int d = Convert.ToInt32(Console.ReadLine());
       return new Weapon(i, r, d);
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
    //Randomizes the damage roll between normal and 2 the standard damage.
    {
        var rand = new Random();
        double multiplier = 1 + rand.NextDouble();
        var result = _damage * multiplier;
        return Convert.ToInt32(result);
    }
}
