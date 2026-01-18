using System.Windows;

public partial class AddSceneWindow : Window
{
    public string SceneTitle { get; private set; }

    public AddSceneWindow()
    {
        InitializeComponent();
    }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        SceneTitle = SceneTitleBox.Text;
        DialogResult = true;
        Close();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}
