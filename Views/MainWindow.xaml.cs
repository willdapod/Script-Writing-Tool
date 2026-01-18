using System.Windows;
using ScriptWritingTool.ViewModels;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }

    private void ExitApplication(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void AddScene_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is MainViewModel vm)
        {
            vm.AddScene();
        }
    }

    private void AddCharacter_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is MainViewModel vm)
        {
            vm.AddCharacter();
        }
    }

    private void CharacterList_DoubleClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is MainViewModel vm)
        {
            vm.OpenCharacterDetails();
        }
    }
}
