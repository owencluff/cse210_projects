public class Ability
{
    private string _name;
    private int _score;

    public Ability(string n, int s)
    {
        _name = n;
        _score = s;
    }

    static public Ability SetAbility(string name)
    {
        Console.Write($"Enter the {name}");
        return new Ability(name, Convert.ToInt32(Console.ReadLine()));
    }

    public string GetAbility()
    {
        return $"{_name}: {_score}";
    }
    public string GetAbilityName()
    {
        return _name;
    }
    public int GetAbilityScore()
    {
        return _score;
    }
    public int GetAbilityBonus()
    {
        return _score / 10;
    }
}