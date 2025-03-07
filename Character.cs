using System.ComponentModel;

public class Character : INotifyPropertyChanged
{
    private string _name;
    private string _color;

    public string Name
    {
        get => _name;
        set { _name = value; OnPropertyChanged(nameof(Name)); }
    }

    public string Color
    {
        get => _color;
        set { _color = value; OnPropertyChanged(nameof(Color)); }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
