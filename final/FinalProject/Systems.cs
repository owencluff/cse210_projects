public class Systems
{
    private int _attackBonus = 0;
    private int _defenseBonus = 0;
    private int _dodgeBonus = 0;
    private List<Ability> _abilityBonuses = [];

    public Systems()
    {
        _attackBonus = 0;
        _defenseBonus = 0;
        _dodgeBonus = 0;
    }
    public Systems(List<Equipment> s)
    {
        foreach (Equipment e in s)
        {
            _attackBonus += e.GetAttackBonus();
            _defenseBonus += e.GetDefenseBonus();
            _dodgeBonus += e.GetDodgeBonus();
            _abilityBonuses.Add(e.GetAbilityBonus());
        }
    }

    public void AddSystem(Equipment e)
    {
        _attackBonus += e.GetAttackBonus();
        _defenseBonus += e.GetDefenseBonus();
        _dodgeBonus += e.GetDodgeBonus();
    }

    public void DisplaySystems()
    {
        Console.WriteLine("Systems:");
        Console.WriteLine($"Attack Bonus: {_attackBonus}");
        Console.WriteLine($"Defense Bonus: {_defenseBonus}");
        Console.WriteLine($"Dodge Bonus: {_dodgeBonus}");
    }
    public int GetAttackBonus()
    {
        return _attackBonus;
    }
    public int GetDefenseBonus()
    {
        return _defenseBonus;
    }
    public int GetDodgeBonus()
    {
        return _dodgeBonus;
    }
    public int GetAbilityBonus(string ability)
    {
        int result = 0;
        foreach(Ability a in _abilityBonuses)
        {
            if (a.GetAbilityName() == ability)
            {
                result += a.GetAbilityScore();
            }
        }
        return result;
    }
}