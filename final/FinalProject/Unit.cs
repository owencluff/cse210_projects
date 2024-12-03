public class Unit
{
    private Pilot _pilot;
    private Mech _mech;
    private Systems _systems;

    public Unit(Pilot p, Mech m, Systems s)
    {
        _pilot = p;
        _mech = m;
        _systems = s;
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
        if((_mech.GetEquipLoad() + e.GetEquipCost()) < _mech.GetEquipLoad())
        {
            _systems.AddSystem(e);
            _mech.EquipItem(e);
        }
    }
    public void DisplayInfo()
    /*
    Name
    Abilities
    Equipment
    */
    {
        Console.WriteLine(GetName());
        foreach (Ability a in _pilot.GetAbilities())
        {
            Console.WriteLine(a.GetAbility());
        }
        foreach (Ability a in _mech.GetAbilities())
        {
            Console.WriteLine(a.GetAbility());
        }
        foreach (Equipment e in _mech.GetEquipment())
        {
            e.DisplayEquipment();
        }
    }
}