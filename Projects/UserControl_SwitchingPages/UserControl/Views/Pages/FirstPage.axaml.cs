using Avalonia.ReactiveUI;
using UserControl.ViewModels.Page;

namespace UserControl.Views.Pages;

public partial class FirstPage : ReactiveUserControl<FirstPageViewModel>
{
    public FirstPage()
    {
        InitializeComponent();
    }
}