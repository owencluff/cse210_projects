public abstract class HasAbility
{
    protected string _name;
    protected List<Ability> _abilities;

    public HasAbility(string name, List<Ability> abilities)
    {
        _name = name;
        _abilities = abilities;
    }
    public HasAbility(string type)
    {
        if (type == "pilot")
        {
            _name = "John Pilot";
            _abilities = [
                new Ability("Grit", 20),
                new Ability("Intuition", 15),
                new Ability("Knowledge", 15)
            ];
        }
        if (type == "mech")
        {
            _name = "Basic Mech";
            _abilities = [
                new Ability("Armor", 30),
                new Ability("Core", 30),
                new Ability("Frame", 30),
                new Ability("Mobility", 30),
                new Ability("Power", 30)
            ];
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
    public Ability GetAbility(string name)
    {
        foreach (Ability a in _abilities)
        {
            if (a.GetAbilityName() == name)
            {
                return a;
            }
        }
        return null;
    }
    public int GetAbilityScore(string name)
    {
        return GetAbility(name).GetAbilityScore();
    }

    public virtual void DisplayAbilities()
    {
        foreach (Ability a in _abilities)
        {
            Console.WriteLine(a.GetAbility());
        }
    }
    
    public virtual string GetSaveData()
    {
        string keeper = $"|Name:{_name}";
        foreach (Ability a in _abilities)
        {
            keeper += a.GetSaveData();
        }
        return keeper;
    }
}