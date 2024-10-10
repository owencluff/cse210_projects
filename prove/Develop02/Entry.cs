public class Entry
{
    public string date;
    public string prompt;
    public string content;

    public void DisplayEntry()
    {
        Console.WriteLine(date);
        Console.WriteLine(prompt);
        Console.WriteLine(content + "\n");
    }
    public string SaveEntry()
    {
        return date + '|' + prompt + '|' + content;
    }
}