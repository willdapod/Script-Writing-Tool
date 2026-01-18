using System.Collections.Generic;
using System.IO;

public class SpellCheckService
{
    private HashSet<string> CustomDictionary { get; set; }

    public SpellCheckService()
    {
        LoadDictionary();
    }

    private void LoadDictionary()
    {
        if (File.Exists("custom_words.txt"))
            CustomDictionary = new HashSet<string>(File.ReadAllLines("custom_words.txt"));
        else
            CustomDictionary = new HashSet<string>();
    }

    public bool IsWordValid(string word)
    {
        return CustomDictionary.Contains(word) || System.Windows.Controls.SpellCheck.GetIsEnabled(new System.Windows.Controls.TextBox());
    }

    public void AddWord(string word)
    {
        CustomDictionary.Add(word);
        File.WriteAllLines("custom_words.txt", CustomDictionary);
    }
}
