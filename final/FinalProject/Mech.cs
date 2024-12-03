public class Mech
{
    private string _name  ;
    //Abilities in order: Armor, Core, Frame, Mobility, Power
    private List<Ability> _abilities;
    private List<Equipment> _equipment;
    private int _equipLoad = 0;

    public Mech(string n, List<Ability> a)
    {
        _name = n;
        _abilities = a;
        _equipment = [];
    }
    public Mech(string n, List<Ability> a, List<Equipment> e)
    {
        _name = n;
        _abilities = a;
        _equipment = e;
    }

    public void DisplayMech()
    {
        Console.WriteLine("Mech Abilities");
        foreach(Ability a in _abilities)
        {
            Console.WriteLine(a.GetAbility());
        }
    }
    public void DisplayEquipment()
    {
        foreach(Equipment e in _equipment)
        {
            e.DisplayEquipment();
        }
    }
    public string GetName()
    {
        return _name;
    }
    public List<Ability> GetAbilities()
    {
        return _abilities;
    }
    public List<Equipment> GetEquipment()
    {
        return _equipment;
    }
    public int GetMaxEquipLoad()
    {
        return _abilities[1].GetAbilityBonus();
    }
    public int GetEquipLoad()
    {
        return _equipLoad;
    }

    public int GetAbilityScore(string name)
    {
        foreach(Ability a in _abilities)
        {
            if(a.GetAbilityName() == name)
            {
                return a.GetAbilityScore();
            }
        }
        return 0;
    }

    public void EquipItem(Equipment e)
    {
        _equipment.Add(e);
        _equipLoad += e.GetEquipCost();
    }
}