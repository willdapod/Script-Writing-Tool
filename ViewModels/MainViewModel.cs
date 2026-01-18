using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows.Input;

public class MainViewModel : ViewModelBase
{
    public ObservableCollection<Character> Characters { get; set; } = new();
    public ObservableCollection<Scene> Scenes { get; set; } = new();
    public ObservableCollection<string> SceneTransitions { get; set; } = new()
    {
        "FADE IN:", "FADE OUT:", "CUT TO:", "DISSOLVE TO:", "SMASH CUT TO:"
    };

    private Character _selectedCharacter;
    public Character SelectedCharacter
    {
        get => _selectedCharacter;
        set { _selectedCharacter = value; RaisePropertyChanged(); }
    }

    private Scene _currentScene;
    public Scene CurrentScene
    {
        get => _currentScene;
        set { _currentScene = value; RaisePropertyChanged(); }
    }

    private string _selectedTransition;
    public string SelectedTransition
    {
        get => _selectedTransition;
        set { _selectedTransition = value; RaisePropertyChanged(); }
    }

    public ICommand OpenCharacterDetailsCommand { get; }

    public MainViewModel()
    {
        OpenCharacterDetailsCommand = new RelayCommand(OpenCharacterDetails); 
        AddCharacterCommand = new RelayCommand(AddCharacter);
        AddSceneCommand = new RelayCommand(AddScene);
        AddScriptLineCommand = new RelayCommand(AddScriptLine);
        SaveCommand = new RelayCommand(SaveData);
        LoadCommand = new RelayCommand(LoadData);
        AddTransitionCommand = new RelayCommand(AddTransition);
    }

    private void OpenCharacterDetails()
    {
        if (SelectedCharacter != null)
        {
            var window = new CharacterDetailsWindow(SelectedCharacter);
            window.ShowDialog();
            RaisePropertyChanged(nameof(Characters));
        }
    }

    public ICommand AddCharacterCommand { get; }
    public ICommand AddSceneCommand { get; }
    public ICommand AddScriptLineCommand { get; }
    public ICommand SaveCommand { get; }
    public ICommand LoadCommand { get; }
    public ICommand AddTransitionCommand { get; }

    private void AddCharacter()
    {
        var window = new AddCharacterWindow();
        if (window.ShowDialog() == true)
        {
            Characters.Add(new Character { Name = window.CharacterName });
        }
    }

    private void AddScene()
    {
        var window = new AddSceneWindow();
        if (window.ShowDialog() == true)
        {
            Scenes.Add(new Scene { Title = window.SceneTitle });
        }
    }


    private void AddScriptLine()
    {
        if (CurrentScene != null && SelectedCharacter != null)
        {
            CurrentScene.ScriptLines.Add(new ScriptLine
            {
                Speaker = SelectedCharacter,
                Dialogue = ""
            });
            RaisePropertyChanged(nameof(CurrentScene));
        }
    }

    private void AddTransition()
    {
        if (CurrentScene != null && !string.IsNullOrWhiteSpace(SelectedTransition))
        {
            CurrentScene.ScriptLines.Add(new ScriptLine
            {
                Speaker = null,
                Dialogue = SelectedTransition
            });
            RaisePropertyChanged(nameof(CurrentScene));
        }
    }

    private void SaveData()
    {
        var data = new { Characters, Scenes };
        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("script_data.json", json);
    }

    private void LoadData()
    {
        if (File.Exists("script_data.json"))
        {
            string json = File.ReadAllText("script_data.json");
            var data = JsonSerializer.Deserialize<dynamic>(json);

            Characters.Clear();
            Scenes.Clear();

            foreach (var c in data.Characters)
                Characters.Add(new Character { Name = c.Name, Color = c.Color });

            foreach (var s in data.Scenes)
            {
                var scene = new Scene { Title = s.Title };
                foreach (var line in s.ScriptLines)
                {
                    scene.ScriptLines.Add(new ScriptLine
                    {
                        Speaker = Characters.FirstOrDefault(ch => ch.Name == line.Speaker.Name),
                        Dialogue = line.Dialogue
                    });
                }
                Scenes.Add(scene);
            }
        }
    }
}
