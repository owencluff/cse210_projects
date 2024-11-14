public class Unit
{
    private Mech _mech;
    private Pilot _pilot;
    private System _system;

    public Unit(Mech mech, Pilot pilot, System system)
    {
        _mech = mech;
        _pilot = pilot;
        _system = system;
    }

    public static int GetMod(int attr)
    {
        return attr / 10;
    }
    public int GetSpeed(int bonus)
    {
        int speedScore = Mech.GetMobility() + _system.GetSpeedBonus() + bonus;
        int speed = GetMod(speedScore);
        return speed * 2;
    }

    //The following are just examples, and will be fleshed out further
    public int AttackChance()
    {
        return Mech.GetPower() + _pilot.GetIntuition() + _system.GetAttackBonus();
    }
    public int DodgeChance()
    {
        return Mech.GetMobility() + _pilot.GetIntuition() + _system.GetDodgeBonus();
    }
    public int MeltdownChance()
    {
        return Mech.GetCore() + _pilot.GetKnowledge();
    }
    public int DefendChance()
    {
        return Mech.GetArmor() + _pilot.GetGrit() + system.GetDefenseBonus();
    }
}

public class Pilot
{
    private int _grit;
    private int _intuition;
    private int _knowledge;

    public Pilot(int g, int i, int k)
    {
        _grit = g;
        _intuition = i;
        _knowledge = k;
    }

    public int GetGrit()
    {
        return _grit;
    }
    public int GetIntuition()
    {
        return _intuition;
    }
    public int GetKnowledge()
    {
        return _knowledge;
    }
}

public class System
{
    private List<Equipment> _equipment;
    private int _attackBonus;
    private int _defenseBonus;
    private int _dodgeBonus;
    private int _speedBonus;

    public System()
    {
        _equipment = []
        _attackBonus = 0;
        _defenseBonus = 0;
        _dodgeBonus = 0;
        _speedBonus = 0;
    }

    public void AddSystem(Equipment e)
    {
        _equipment.Add(e);
        _attackBonus += e.GetAttackBonus();
        _defenseBonus += e.GetDefenseBonus();
        _dodgeBonus += e.GetDodgeBonus();
        _speedBonus += e.GetSpeedBonus();
    }
    public void RemoveSystem(Equipment e)
    {
        _equipment.Remove(e);
        _attackBonus -= e.GetAttackBonus();
        _defenseBonus -= e.GetDefenseBonus();
        _dodgeBonus -= e.GetDodgeBonus();
        _speedBonus -= e.GetSpeedBonus();
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
    public int GetSpeedBonus()
    {
        return _speedBonus();
    }
}