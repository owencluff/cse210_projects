public class Shield : Equipment
//Shields act as a source of temporary hit points
{
    private int _shieldPoints;
    private int _currentShield;
    private int _shieldRefresh;

    public Shield(string n, int a, int de, int dg, int c, int p, int r) : base(n, a, de, dg, c)
    {
        _shieldPoints = p;
        _currentShield = p;
        _shieldRefresh = r;
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
            return 0;
        }
        else
        {
            return Math.Abs(result);
        }
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
}