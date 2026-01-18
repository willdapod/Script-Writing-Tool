using System.Windows;

public partial class AddCharacterWindow : Window
{
    public string CharacterName { get; private set; }

    public AddCharacterWindow()
    {
        InitializeComponent();
    }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        CharacterName = CharacterNameBox.Text;
        DialogResult = true;
        Close();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}
