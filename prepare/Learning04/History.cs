public class History : Assignment
{
    private string _title;

    public History(string name, string topic, string title) : base(name, topic)
    {
        _title = title;
    }

    public string GetWritingInfo()
    {
        return _title + " by " + base._studentName;
    }
}