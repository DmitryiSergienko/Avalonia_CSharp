using Avalonia.Controls;
using ViewModel;

namespace View_ExchangeRates;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}