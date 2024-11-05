public class Breathing : Activity
{
    private string _breatheIn;
    private string _breatheOut;

    //a for name, b for description and c for duration
    public Breathing(string a, string b, int c) :base(a, b, c)
    {
        _breatheIn = "Breathe in...";
        _breatheOut = "Breathe out...";
    }

    public void Breathe()
    {
        Console.Clear();
        do
        {
            Console.WriteLine(_breatheIn);
            Countdown(3);
            Console.WriteLine(_breatheOut);
            Countdown(3);
        } while (Timer());
        EndingMessage();
    }
}