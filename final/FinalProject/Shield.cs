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

    public override void CreateItem<Shield>()
    {
        var i = CreateEquipmentBonus();
        Console.Write("Shield Points: ");
        _shieldPoints = Convert.ToInt32(Console.ReadLine());
        Console.Write("Refresh Rate: ");
        _shieldRefresh = Convert.ToInt32(Console.ReadLine());
        SetAttributes(i);
        Console.WriteLine();
    }

    public override void DisplayEquipment()
    {
        base.DisplayEquipment();
        Console.WriteLine($"Shield Points: {_shieldPoints}");
        Console.WriteLine($"Shield Refresh: {_shieldRefresh}");
        Console.WriteLine();
    }
    public int GetShieldPoints()
    {
        return _shieldPoints;
    }
    public int GetShieldRefresh()
    {
        return _shieldRefresh;
    }
    public override void UpgradeItem()
    {
        Console.WriteLine("Upgrade Bonus, Shield Points, or Refresh Rate?");
        Console.Write("(Bonus/Shield Points/Refresh Rate)>| ");
        string answer = Console.ReadLine();
        Console.Write("How many times? ");
        int times = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < times; i ++)
        {
            if (answer == "Bonus")
            {
                UpgradeBonus();
            }
            if (answer == "Shield Points")
            {
                _shieldPoints += 1;
            }
            if (answer == "Refresh Rate")
            {
                _shieldRefresh += 1;
            }
        }
        Console.WriteLine($"{answer} upgraded {times} time(s)");
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