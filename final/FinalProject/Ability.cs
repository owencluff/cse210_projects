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
        int score = 0;
        do
        {
            try
            {
                Console.Write($"Enter the {name}: ");
                score = Convert.ToInt32(Console.ReadLine());
                if (score == 0)
                {
                    throw new Exception("Ability Score cannot be zero");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }while(score == 0);
        return new Ability(name, score);
    }

    public void UpgradeAbility(int times)
    {
        for (int i = 0; i < times; i ++)
        {
            _score += 5;
        }
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

    public string GetSaveData()
    {
        return $",Ability:{_name}.{_score}";
    }
}