public abstract class Equipment
{
    private string _name;
    private int _attackBonus;
    private int _defenseBonus;
    private int _dodgeBonus;
    private int _equipCost;
    private Ability _abilityBonus;

    public Equipment(string n, int a, int de, int dg, int e)
    {
        _name = n;
        _attackBonus = a;
        _defenseBonus = de;
        _dodgeBonus = dg;
        _equipCost = e;
        _abilityBonus = null;
    }

    public virtual void DisplayEquipment()
    {
        Console.WriteLine($"{_name}:");
        Console.WriteLine($"Attack Bonus: {_attackBonus}");
        Console.WriteLine($"Defense Bonus: {_defenseBonus}");
        Console.WriteLine($"Dodge Bonus: {_dodgeBonus}");
        Console.WriteLine($"Equip Cost: {_equipCost}");
    }
    public virtual string GetName()
    {
        return _name;
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
    public virtual int GetEquipCost()
    {
        return _equipCost;
    }
    public void SetAbilityBonus(Ability a)
    {
        _abilityBonus = a;
    }
    public Ability GetAbilityBonus()
    {
        return _abilityBonus;
    }
}