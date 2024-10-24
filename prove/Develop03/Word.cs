public class Word
{
    private string _word;
    private bool _isRedacted;

    public Word(string word)
    {
        _word = word;
        _isRedacted = false;
    }

    public bool GetRedacted()
    {
        return _isRedacted;
    }

    public void RedactWord()
    //Checks if a word has been redacted, then redacts it if it not.
    //To redact a word, replace all letters and numbers with an '_', and set _is redacted to true.
    {
        if(!_isRedacted)
        {
            string result = "";
            foreach (char c in _word)
            {
                if (char.IsLetterOrDigit(c))
                {
                    result += '_';
                }
                else
                {
                    result += c;
                }
            }
            _word = result;
            _isRedacted = true;
        }
    }
    public void DisplayWord()
    {
        Console.Write(_word + ' ');
    }
}