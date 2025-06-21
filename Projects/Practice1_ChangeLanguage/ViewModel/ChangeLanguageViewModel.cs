using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel;

public class ChangeLanguageViewModel : INotifyPropertyChanged
{
    public ObservableCollection<string> ChoiceLanguage { get; set; } = new();
    public ObservableCollection<string> TextsHello { get; set; } = new();

    public ChangeLanguageViewModel()
    {
        foreach (var languages in Content.Languages)
        {
            ChoiceLanguage.Add(languages);
        }
        
        foreach (var hello in Content.Hello)
        {
            TextsHello.Add(hello);
        }
    }
    
    private string _selectedLanguage = "Русский";
    public string SelectedLanguage
    {
        get => _selectedLanguage;
        set
        {
            _selectedLanguage = value;
            ComboBoxChangeLanguage();
            OnPropertyChanged();
        }
    }
    
    private string _textHello = "Добро пожаловать!";
    public string TextHello
    {
        get => _textHello;
        set
        {
            _textHello = value;
            OnPropertyChanged();
        }
    }

    public void ComboBoxChangeLanguage()
    {
        switch (_selectedLanguage)
        {
            case "English":
            {
                TextHello = TextsHello[0];
                break;
            }
            case "Русский":
            {
                TextHello = TextsHello[1];
                break;
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}