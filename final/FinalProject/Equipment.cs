public abstract class Equipment
{
    private int _attackBonus;
    private int _defenseBonus;
    private int _dodgeBonus;
    private int _mobilityBonus;
    private int _equipCost;

    public Equipment(int a, int de, int dg, int m, int e)
    {
        _attackBonus = a;
        _defenseBonus = de;
        _dodgeBonus = dg;
        _mobilityBonus = m;
        _equipCost = e;
    }

    public virtual void DisplayEquipment()
    {
        Console.WriteLine($"Attack Bonus: {_attackBonus}");
        Console.WriteLine($"Defense Bonus: {_defenseBonus}");
        Console.WriteLine($"Dodge Bonus: {_dodgeBonus}");
        Console.WriteLine($"Mobility Bonus: {_mobilityBonus}");
        Console.WriteLine($"Equip Cost: {_equipCost}");
    }
    public virtual int GetAttackBonus()
    {
        return _attackBonus;
    }
    public virtual int GetDefenseBonus()
    {
        return _defenseBonus;
    }
    public virtual int GetDodgeBonus()
    {
        return _dodgeBonus;
    }
    public virtual int GetMobilityBonus()
    {
        return _mobilityBonus;
    }
    public virtual int GetEquipCost()
    {
        return _equipCost;
    }
}