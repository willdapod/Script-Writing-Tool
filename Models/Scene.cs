using System.Collections.ObjectModel;

namespace ScriptWritingTool.Models
{
    public class Scene
    {
        public string Title { get; set; }
        public ObservableCollection<ScriptLine> ScriptLines { get; set; } = new();
    }
}
