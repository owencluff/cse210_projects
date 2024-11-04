public class Breathing : Activity
{
    private string _breatheIn;
    private string _breatheOut;

    public Breathing(string name, string descr, int durat) :base(name, descr, durat)
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
            Countdown();
            Console.WriteLine(_breatheOut);
            Countdown();
        } while (Timer());
        EndingMessage();
    }
}