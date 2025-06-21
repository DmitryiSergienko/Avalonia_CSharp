using Avalonia.Controls;
using ViewModel;

namespace View;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        DataContext = new ManagerMovieViewModel();
        InitializeComponent();
    }
}