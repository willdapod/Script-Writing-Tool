public class ScriptLine
{
    public Character Speaker { get; set; }
    public string Dialogue { get; set; }

    public string FormattedLine => Speaker == null
        ? $"   {Dialogue}" // Scene transitions are centered
        : $"{Speaker.Name.ToUpper()}:\n   {Dialogue}";
}
