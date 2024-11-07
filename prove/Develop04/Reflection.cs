public class Reflection : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    //For convenience, I am using a for name, b for description and c for duration
    public Reflection(string a, string b, int c) : base(a, b, c)
    {
        _prompts = [
            "Think of a time you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you failed."
        ];
        _questions = [
            "Why was this experience meaningful?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was done?",
            "What made this time different from other times?",
            "What is your favorite thing about this experience",
            "What could you learn from this experience?",
            "What did you learn about yourself from this experience?",
            "How can you keep this experience in mind in the future?"
        ];
    }
    
    public void Reflect()
    {
        Console.Clear();
        string prompt = RandomChoice(_prompts);
        string question;
        Console.WriteLine(prompt);
        Console.WriteLine("Please reflect on the following:");
        do
        {
            question = RandomChoice(_questions);
            Console.WriteLine(question);
            Spinner(5);
        } while (Timer());
        EndingMessage();
    }
    private void Spinner(int time)
    {
        DateTime now = DateTime.Now;
        do
        {
            Console.Write("-|-");
            Thread.Sleep(1000);
            Console.Write("\b\b\b");
            Console.Write("|-|");
            Thread.Sleep(1000);
            Console.Write("\b\b\b");
        } while (DateTime.Now < now.AddSeconds(time));
    }
}