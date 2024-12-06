public class Shield : Equipment
//Shields act as a source of temporary hit points
{
    private int _shieldPoints;
    private int _currentShield;
    private int _shieldRefresh;

    public Shield() : base(("Basic Shield", 0, 0, 10, 1))
    {
        _shieldPoints = 3;
        _currentShield = 3;
        _shieldRefresh = 1;
    }
    public Shield((string, int, int, int, int) i , int p, int r) : base(i)
    {
        _shieldPoints = p;
        _currentShield = p;
        _shieldRefresh = r;
    }

    static public Shield CreateShield()
    {
        var i = CreateEquipmentBonus();
        Console.Write("Equip Cost: ");
        int ec = Convert.ToInt32(Console.ReadLine());
        Console.Write("Shield Points: ");
        int sp = Convert.ToInt32(Console.ReadLine());
        Console.Write("Refresh Rate: ");
        int rr = Convert.ToInt32(Console.ReadLine());
        return new Shield(i, sp, rr);
    }

    public override void DisplayEquipment()
    {
        base.DisplayEquipment();
        Console.WriteLine($"Shield Points: {_shieldPoints}");
        Console.WriteLine($"Shield Refresh: {_shieldRefresh}");
    }
    public int GetShieldPoints()
    {
        return _shieldPoints;
    }
    public int GetShieldRefresh()
    {
        return _shieldRefresh;
    }

    public int ShieldDamage(int damage)
    //when taking damage, subtract damage from shield and return overflow damage
    {
        int result = _currentShield - damage;
        if (result <= 0)
        {
            result = 0;
        }
        else
        {
            result = Math.Abs(result);
        }
        Console.WriteLine($"Shield took {damage} and has {_currentShield} points remaining");
        Console.WriteLine($"Leftover damage: {result}");
        return result;
    }
    public void ShieldRefresh()
    {
        for (int i = _shieldRefresh; i <= _shieldPoints; i++)
        {
            if (_currentShield < _shieldPoints)
            {
                _currentShield ++;
            }
        }
    }

    public override string GetSaveData(string type)
    {
        string keeper = base.GetSaveData(type);
        keeper += $",ShieldPoints:{_shieldPoints},Refresh:{_shieldRefresh}";
        return keeper;
    }
}