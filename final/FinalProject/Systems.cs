public class Systems
{
    private int _attackBonus = 0;
    private int _defenseBonus = 0;
    private int _dodgeBonus = 0;
    private int _mobilityBonus = 0;

    public Systems(List<Equipment> s)
    {
        foreach (Equipment e in s)
        {
            _attackBonus += e.GetAttackBonus();
            _defenseBonus += e.GetDefenseBonus();
            _dodgeBonus += e.GetDodgeBonus();
            _mobilityBonus += e.GetMobilityBonus();
        }
    }

    public void AddSystem(Equipment e)
    {
        _attackBonus += e.GetAttackBonus();
        _defenseBonus += e.GetDefenseBonus();
        _dodgeBonus += e.GetDodgeBonus();
        _mobilityBonus += e.GetMobilityBonus();
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
    public int GetMobilityBonus()
    {
        return _mobilityBonus;
    }
}