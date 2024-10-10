using System.Transactions;

public class Journal
{
    List<string> _prompts = ["Who is the most interesting person you met today?", "How have you seen the hand of the Lord today?", "What made you smile today?", "Did you go anywhere new today?", "List five things you are grateful for:"]; //enter prompts here.
    public List<Entry> entries = new List<Entry>();

    public void GetEntry()
    {
        Random rnd = new Random();
        Entry e = new Entry();
        e.date = DateTime.Now.ToShortDateString();
        e.prompt = _prompts[rnd.Next(_prompts.Count)];
        Console.WriteLine($"Today's prompt: {e.prompt}");
        e.content = Console.ReadLine();
        entries.Add(e);
        Console.WriteLine();
    }
    public void DisplayJournal()
    {
        foreach (Entry e in entries)
        {
            e.DisplayEntry();
        }
    }
    public void SaveJournal(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry e in entries)
            {
                outputFile.WriteLine(e.SaveEntry());
            }
        }
    }
    public void LoadJournal(string filename)
    {
        List<Entry> result = new List<Entry>();
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            Entry e = new Entry();
            e.date = parts[0];
            e.prompt = parts[1];
            e.content = parts[2];
            result.Add(e);
        }
        entries = result;
    }

}