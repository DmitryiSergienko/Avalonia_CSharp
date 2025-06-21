using Avalonia.Controls;
using ViewModel;

namespace View;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new ChangeLanguageViewModel();
    }
}