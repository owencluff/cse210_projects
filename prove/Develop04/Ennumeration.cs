public class Ennumeration : Activity
{
    private List<string> _prompts;
    private List<string> _inputs;

    public Ennumeration(string a, string b, int c) : base(a, b, c)
    {
        _prompts = [
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        ];
        _inputs = [];
    }

    public void Ennumerate()
    {
        Console.Clear();
        string prompt = RandomChoice(_prompts);
        Console.WriteLine("Please think about this prompt:");
        Console.WriteLine(prompt);
        Countdown();
        Console.WriteLine("Please list your items below.");
        do
        {
            Console.Write(">| ");
            string item = Console.ReadLine();
            _inputs.Add(item);
        } while (Timer());
        Console.WriteLine($"You entered {_inputs.Count} items.");
        EndingMessage();
    }
}