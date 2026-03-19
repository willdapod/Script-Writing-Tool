using System.Windows;
using ScriptWritingTool.ViewModels;

namespace ScriptWritingTool.Views
{
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

        private void SceneList_DoubleClick(object sender, RoutedEventArgs e)
        {
            // Optional: Implement scene-specific double click logic (e.g. focusing on the scene)
        }
    }
}
