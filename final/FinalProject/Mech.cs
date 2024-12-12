public class Mech : HasAbility
{
    private List<Equipment> _equipment;
    private int _equipLoad = 0;

    public Mech() : base("mech")
    {
        _equipment = [new Weapon()];
    }
    public Mech(string n, List<Ability> a) : base(n, a)
    {
        _equipment = new List<Equipment>();
    }
    public Mech(string n, List<Ability> a, List<Equipment> e) : base(n, a)
    {
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
       Console.WriteLine();
       return new Mech(name, [arm, core, frame, mob, pow]);
    }

    public override void DisplayAbilities()
    {
        Console.WriteLine("Mech Abilities");
        base.DisplayAbilities();
    }
    public void DisplayEquipment()
    {
        foreach(Equipment e in _equipment)
        {
            e.DisplayEquipment();
        }
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
    {
        return _equipment.OfType<T>().FirstOrDefault();
    }

    public void EquipItem(Equipment e)
    {
        _equipment.Add(e);
        _equipLoad += e.GetEquipCost();
    }
    public void RemoveEquipment(Equipment e)
    {
        _equipment.Remove(e);
    }
    public void UpgradeEquipment()
    {
        Console.Write("Name of item to upgrade: ");
            string name = Console.ReadLine();
            Equipment item = null;
            foreach (Equipment e in _equipment)
            {
                if (e.GetName() == name)
                {
                    item = e;
                }
            }
            item.UpgradeItem();
    }

    public override string GetSaveData()
    {
        return "Mech" + base.GetSaveData();
    }
}