using ReactiveUI;

namespace UserControl.ViewModels.Page;

public class SecondPageViewModel : BasePageViewModel
{
    public string? Text { get; set; }
    public SecondPageViewModel(IScreen hostScreen) : base(hostScreen)
    {
    }
}