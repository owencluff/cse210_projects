using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private int _timesRedacted;

    public Scripture()
    //Used for the case where someone memorizes a scripture without saving one first.
    {
        _reference = new Reference("John", "14", "15");
        _words = [new Word("If"), new Word("ye"), new Word("love"), new Word("me,"), new Word("keep"), new Word("my"), new Word("commandments.")];
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
    //Takes a random word in _words and checks if it is redacted.
    //If not, it redacts it and increases the count of words redacted.
    //If it is, runs the funtion again.
    {
        Random random = new Random();
        int index = random.Next(_words.Count);
        if (!_words[index].GetRedacted())
        {
            _words[index].RedactWord();
            _timesRedacted++;
        }
        else
        {
            RedactScripture();
        }
    }
}