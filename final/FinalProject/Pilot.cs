public class Pilot : HasAbility
{    
    public Pilot() : base("pilot")
    {
    }
    public Pilot(string n, List<Ability> a) : base(n, a)
    {
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


    public override void DisplayAbilities()
    {
        Console.WriteLine("Pilot Abilities:");
        base.DisplayAbilities();
    }

    public override string GetSaveData()
    {
        return "Pilot" + base.GetSaveData();
    }
}   