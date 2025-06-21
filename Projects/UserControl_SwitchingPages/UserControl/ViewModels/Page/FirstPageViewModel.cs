using ReactiveUI;

namespace UserControl.ViewModels.Page;

public class FirstPageViewModel : BasePageViewModel
{
    public string? Text { get; set; }
    public FirstPageViewModel(IScreen hostScreen) : base(hostScreen)
    {
    }
}