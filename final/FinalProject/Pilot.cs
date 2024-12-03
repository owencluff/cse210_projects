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

    public void DisplayPilot()
    {
        Console.WriteLine("Pilot Abilities");
        foreach(Ability a in _abilities)
        {
            Console.WriteLine(a.GetAbility());
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
}   