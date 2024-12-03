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
    public int GetEquipLoad()
    {
        return _abilities[1].GetAbilityBonus();
    }

    public void EquipItem(Equipment e)
    {
        _equipment.Add(e);
        _equipLoad += e.GetEquipCost();
    }
}