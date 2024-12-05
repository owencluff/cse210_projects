using System.Reflection;

public class Mech
{
    private string _name  ;
    //Abilities in order: Armor, Core, Frame, Mobility, Power
    private List<Ability> _abilities;
    private List<Equipment> _equipment;
    private int _equipLoad = 0;

    public Mech()
    {
        _name = "Default Mech";
        _abilities = [
            new Ability("Armor", 30),
            new Ability("Core", 30),
            new Ability("Frame", 30),
            new Ability("Mobility", 30),
            new Ability("Power", 30)
        ];
        _equipment = [new Weapon()];
    }
    public Mech(string n, List<Ability> a)
    {
        _name = n;
        _abilities = a;
        _equipment = new List<Equipment>();
    }
    public Mech(string n, List<Ability> a, List<Equipment> e)
    {
        _name = n;
        _abilities = a;
        _equipment = e;
    }

    static public Mech CreateMech()
    {
       Console.Write("Enter Mech's name: ");
       string name = Console.ReadLine();
       Ability arm = Ability.SetAbility("Armor");
       Ability core = Ability.SetAbility("Core");
       Ability frame = Ability.SetAbility("Frame");
       Ability mob = Ability.SetAbility("Mobility");
       Ability pow = Ability.SetAbility("Power");
       return new Mech(name, [arm, core, frame, mob, pow]);
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
    public T GetEquipmentOfType<T>() where T : Equipment
    //This is Claude.ai's suggestion.
    {
        return _equipment.OfType<T>().FirstOrDefault();
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