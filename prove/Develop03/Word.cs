public class Word
{
    private string _word;
    private bool _isRedacted;

    public Word(string word)
    {
        _word = word;
        _isRedacted = false;
    }

    public void RedactWord()
    {
        string result = "";
        foreach (char c in _word)
        {
            result += '*'; //this can be any character you choose
        }
        _word = result;
        _isRedacted = true;
    }
    public void DisplayWord()
    {
        Console.Write(_word);
    }
}