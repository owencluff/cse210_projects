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
        if (duration <= 0)
        {
            throw new Exception($"This activity requires more than {duration} seconds.");
        }
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
    //checks if the set amount of time has passed
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
    //Counts down the input number of seconds
    {
        DateTime now = DateTime.Now;
        int t = time; //prevents the countdown from ending early
        do
        {
            Console.Write($"{t}...");
            t--;
            Thread.Sleep(1000);
        } while (DateTime.Now < now.AddSeconds(time));
        Console.WriteLine();
    }
    public static int SetDuration()
    {
        Console.WriteLine("How long would you like to do this activity?");
        Console.Write("Enter the number of seconds: ");
        int duration = Convert.ToInt32(Console.ReadLine());
        return duration;
    }
}