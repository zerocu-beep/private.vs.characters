namespace VisualScript.Runtime.Characters
{
    public interface ISearchable
    {
        string SearchText  { get; }
        int SearchPriority { get; }
    }
}
