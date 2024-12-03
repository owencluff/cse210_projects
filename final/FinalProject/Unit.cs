public class Unit
/*
Missing: HP, Movement
*/
{
    private Pilot _pilot;
    private Mech _mech;
    private Systems _systems;
    private Weapon _weapon;
    private int _hitPoints;
    private int _movePoints;

    public Unit(Pilot p, Mech m, Systems s)
    {
        _pilot = p;
        _mech = m;
        _systems = s;
        _hitPoints = m.GetAbilityScore("Frame") / 10;
        _movePoints = m.GetAbilityScore("Mobility") / 10;
    }
    
    public void SetHitPoints()
    {
        int frame = _mech.GetAbilityScore("Frame") + _systems.GetAbilityBonus("Frame");
        _hitPoints = frame / 10;
    }
    public void SetMovePoints()
    {
        int mobility = _mech.GetAbilityScore("Mobility") + _systems.GetAbilityBonus("Mobility");
        _movePoints = mobility / 10;
    }
    public Pilot GetPilot()
    {
        return _pilot;
    }
    public Mech GetMech()
    {
        return _mech;
    }
    public Systems GetSystems()
    {
        return _systems;
    }
    public string GetName()
    {
        return $"{_pilot.GetName()} {_mech.GetName()}";
    }
    public void AddEquipment(Equipment e)
    {
        if((_mech.GetEquipLoad() + e.GetEquipCost()) < _mech.GetMaxEquipLoad())
        {
            _systems.AddSystem(e);
            _mech.EquipItem(e);
        }
    }

    public void DisplayInfo()
    /*
    Name
    Abilities
    Systems
    */
    {
        Console.WriteLine(GetName());
        _pilot.DisplayPilot();
        _mech.DisplayMech();
        _systems.DisplaySystems();
    }

    /*
    The first two are generics, that may be used anywhere.
    Following will be ways to determine the bonuses for each check.
    */
    public bool RollCheck(int score)
    {
        var rand = new Random();
        if (rand.Next(99) < score)
        {
            return true;
        }
        return false;
    }
    public int GetCheckScore(int bonus, string pilotAbility, string mechAbility)
    //takes the two abilities to be used and the total bonus, adds them together;
    {
        return _pilot.GetAbilityScore(pilotAbility) + _mech.GetAbilityScore(mechAbility) + bonus;
    }

    public int DetermineAttackBonus(int weaponRange, int targetRange)
    //inside a range, attack is normal. for each range outside of the range, a -15 penalty is applied
    {
        int result = _systems.GetAttackBonus();
        for (int i = targetRange; i > weaponRange; i -= weaponRange)
        {
            result -= 15;
        }
        return result;
    }
    public int DetermineDefenseBonus(int coverLevel)
    //cover level: for each level of cover, a +15 bonus is applied (max of 4 levels of cover)
    {
        int result = _systems.GetDefenseBonus();
        for (int i = coverLevel; i > 0; i --)
        {
            result += 15;
        }
        return result;
    }
    public int DetermineDodgeBonus(int dodgeDistance)
    //dodge distance: determines how far a unit must move to dodge, 0 = not an Aoe attack
    //dodge distance must be <= movement ability
    {
        int result = _systems.GetDodgeBonus();
        for (int i = dodgeDistance; i > 0; i --)
        {
            result -= 15;
        }
        return result;
    }
    public int DetermineCheckBonus(List<string> bonuses)
    {
        int result = 0;
        foreach (string s in bonuses)
        {
            result += _systems.GetAbilityBonus(s);
        }
        return result;
    }

    public int MakeAttack(int enemyRange, bool enemySuccess)
    //gets bonuses, then rolls
    {
        int attackBonus = DetermineAttackBonus(_weapon.GetRange(), enemyRange);
        int attackScore = GetCheckScore(attackBonus, "Intuition", "Power");
        if (RollCheck(attackScore) && !enemySuccess)
        {
            return _weapon.RollDamage();
        }
        return 0;
    }
    public bool MakeDefense(int coverLevel)
    {
        int defenseBonus = DetermineDefenseBonus(coverLevel);
        int defenseScore = GetCheckScore(defenseBonus, "Grit", "Armor");
        if (RollCheck(defenseScore))
        {
            return true;
        }
        return false;
    }
    public bool MakeDodge(int dodgeDistance)
    {
        int dodgeBonus = DetermineDodgeBonus(dodgeDistance);
        int dodgeScore = GetCheckScore(dodgeBonus, "Intuition", "Mobility");
        if (RollCheck(dodgeScore))
        {
            return true;
        }
        return false;
    }
}