public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, List<Word> words)
    {
        _reference = reference;
        _words = words;
    }

    public void DisplayScripture()
    {
        DisplayReference();
        foreach (Word word in _words)
        {
            
        }
    }
}