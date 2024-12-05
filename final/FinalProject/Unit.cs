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
    private int _currentHitPoints;
    private int _movePoints;

    public Unit()
    {
        _pilot = new Pilot();
        _mech = new Mech();
        _systems = new Systems();
        _weapon = _mech.GetEquipmentOfType<Weapon>();
        _hitPoints = _mech.GetAbilityScore("Frame") / 10;
        _currentHitPoints = _hitPoints;
        _movePoints = _mech.GetAbilityScore("Mobility") / 10;
    }
    public Unit(Pilot p, Mech m, Systems s)
    {
        _pilot = p;
        _mech = m;
        _systems = s;
        _weapon = m.GetEquipmentOfType<Weapon>();
        _hitPoints = m.GetAbilityScore("Frame") / 10;
        _currentHitPoints = _hitPoints;
        _movePoints = m.GetAbilityScore("Mobility") / 10;
    }

    static public Unit CreateUnit()
    {
        Pilot pilot = Pilot.CreatePilot();
        Mech mech = Mech.CreateMech();
        Unit unit1 = new Unit(pilot, mech, new Systems());
        return unit1;
    }

    public void SetHitPoints()
    {
        int frame = _mech.GetAbilityScore("Frame") + _systems.GetAbilityBonus("Frame");
        _hitPoints = frame / 10;
    }
    public void TakeDamage(int damage)
    {
        int loss = damage;
        if (_mech.GetEquipmentOfType<Shield>() != null)
        {
            loss = _mech.GetEquipmentOfType<Shield>().ShieldDamage(loss);
        }
        if (loss > 0 && _mech.GetEquipmentOfType<ArmorPlating>() != null)
        {
            loss = _mech.GetEquipmentOfType<ArmorPlating>().ReduceDamage(loss);
        }
        _currentHitPoints -= loss;
        Console.WriteLine($"{GetName()} has {_currentHitPoints} left");
        if (_currentHitPoints <= 0)
        {
            Console.WriteLine($"{GetName()} has been destroyed");
        }
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

    public int DetermineAttackBonus(int weaponRange, int targetRange, int other)
    //inside a range, attack is normal. for each range outside of the range, a -15 penalty is applied
    {
        int result = _systems.GetAttackBonus() + other;
        for (int i = targetRange; i > weaponRange; i -= weaponRange)
        {
            result -= 15;
        }
        return result;
    }
    public int DetermineDefenseBonus(int coverLevel, int other)
    //cover level: for each level of cover, a +15 bonus is applied (max of 4 levels of cover)
    {
        int result = _systems.GetDefenseBonus() + other;
        for (int i = coverLevel; i > 0; i --)
        {
            result += 15;
        }
        return result;
    }
    public int DetermineDodgeBonus(int dodgeDistance, int other)
    //dodge distance: determines how far a unit must move to dodge, 0 = not an Aoe attack
    //dodge distance must be <= movement ability
    {
        int result = _systems.GetDodgeBonus() + other;
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

    public int MakeAttack(int enemyRange, bool enemySuccess, int other)
    //gets bonuses, then rolls
    //Returns the damage delt
    {
        int damage = 0;
        int attackBonus = DetermineAttackBonus(_weapon.GetRange(), enemyRange, other);
        int attackScore = GetCheckScore(attackBonus, "Intuition", "Power");
        if (RollCheck(attackScore))
        {
            Console.WriteLine("Attack hit!");
            damage = _weapon.RollDamage();
            if (enemySuccess)
            {
                Console.WriteLine("Enemy Defended!");
                damage = damage / 2;
            }
        }
        else
        {
            Console.WriteLine("Attack Missed");
        }
        Console.WriteLine($"Dealt {damage} damage");
        return damage;
    }
    public bool MakeDefense(int coverLevel, int other)
    {
        int defenseBonus = DetermineDefenseBonus(coverLevel, other);
        int defenseScore = GetCheckScore(defenseBonus, "Grit", "Armor");
        if (RollCheck(defenseScore))
        {
            return true;
        }
        return false;
    }
    public bool MakeDodge(int dodgeDistance, int other)
    {
        int dodgeBonus = DetermineDodgeBonus(dodgeDistance, other);
        int dodgeScore = GetCheckScore(dodgeBonus, "Intuition", "Mobility");
        if (RollCheck(dodgeScore))
        {
            return true;
        }
        return false;
    }
}