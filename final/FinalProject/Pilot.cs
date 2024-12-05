public class Pilot
{
    private string _name;
    //Abilities in order: Grit, Intuition, Knowledge
    private List<Ability> _abilities;
    
    public Pilot()
    {
        _name = "John Pilot";
        _abilities = [
          new Ability("Grit", 20),
          new Ability("Intuition", 15),
          new Ability("Knowledge", 15)  
        ];
    }
    public Pilot(string n, List<Ability> a)
    {
        _name = n;
        _abilities = a;
    }

    static public Pilot CreatePilot()
    {
        Console.Write("Enter Pilot's name: ");
        string name = Console.ReadLine();
        Ability grit = Ability.SetAbility("Grit");
        Ability intuit = Ability.SetAbility("Intuition");
        Ability know = Ability.SetAbility("Knowledge");
        return new Pilot(name, [grit, intuit, know]);
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