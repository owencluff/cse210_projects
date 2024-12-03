public class Ability
{
    private string _name;
    private int _score;

    public Ability(string name, int score)
    {
        _name = name;
        _score = score;
    }

    public get AbilityName()
    {
        return _name;
    }
    public string getAbilityScore()
    {
        return _score;
    }
}