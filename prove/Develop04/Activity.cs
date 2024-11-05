public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    private string _endMessage;
    private DateTime _startTime;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
        _endMessage = $"Thank you for participating in the {_name} activity!";
        _startTime = DateTime.Now;
    }

    protected void BeginningMessage()
    {
        Console.WriteLine($"Welcome to the {_name} activity!");
        Console.WriteLine(_description);
    }
    protected void EndingMessage()
    {
        Console.WriteLine(_endMessage);
        Thread.Sleep(3000);
    }
    public bool Timer()
    {
        if (DateTime.Now < _startTime.AddSeconds(_duration))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected string RandomChoice(List<string> items)
    //Used in the Reflection and Ennumeration activities
    {
        Random random = new Random();
        int choice = random.Next(items.Count);
        return items[choice];
    }
    protected void Countdown(int time)
    //Used in the Breathing and Ennumeration activities
    {
        DateTime now = DateTime.Now;
        int t = time; //prevents the countdown from ending early
        do
        {
            Console.Write($"{time}...");
            time--;
            Thread.Sleep(1000);
        } while (DateTime.Now < now.AddSeconds(t));
        Console.WriteLine();
    }
}