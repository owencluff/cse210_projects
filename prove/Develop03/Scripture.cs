using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private int _timesRedacted;

    public Scripture()
    {
        _reference = new Reference("John", "14", "15");
        _words = new List<Word>([new Word("If"), new Word("ye"), new Word("love"), new Word("me,"), new Word("keep"), new Word("my"), new Word("commandments.")]);
        _timesRedacted = 0;
    }
    public Scripture(Reference reference, List<Word> words)
    {
        _reference = reference;
        _words = words;
        _timesRedacted = 0;
    }

    public bool GetFullyRedacted()
    {
        if (_timesRedacted == _words.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public void DisplayScripture()
    {
        _reference.DisplayReference();
        foreach (Word word in _words)
        {
            word.DisplayWord();
        }
        Console.WriteLine();
    }
    public void RedactScripture()
    {
        Random random = new Random();
        int index = random.Next(_words.Count);
        if (!_words[index].GetRedacted())
        {
            _words[index].RedactWord();
            _timesRedacted +=1;
        }
        else
        {
            RedactScripture();
        }
    }
}