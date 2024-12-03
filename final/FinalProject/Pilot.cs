public class Pilot
{
    private string _name;
    //Abilities in order: Grit, Intuition, Knowledge
    private List<Ability> _abilities;
    
    public Pilot(string n, List<Ability> a)
    {
        _name = n;
        _abilities = a;
    }

    public string GetName()
    {
        return _name;
    }
    public List<Ability> GetAbilities()
    {
        return _abilities;
    }
}   