using System.Windows;

public partial class CharacterDetailsWindow : Window
{
    public Character Character { get; private set; }

    public CharacterDetailsWindow(Character character)
    {
        InitializeComponent();
        Character = character;
        CharacterNameBox.Text = character.Name;
        NotesBox.Text = character.Notes;
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        Character.Name = CharacterNameBox.Text;
        Character.Notes = NotesBox.Text;
        DialogResult = true;
        Close();
    }
}