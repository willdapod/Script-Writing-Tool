using System.Collections.ObjectModel;

public class Scene
{
    public string Title { get; set; }
    public ObservableCollection<ScriptLine> ScriptLines { get; set; } = new();
}
