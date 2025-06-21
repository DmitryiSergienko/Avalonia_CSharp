using ReactiveUI;

namespace UserControl.ViewModels.Page;

public class ThirdPageViewModel : BasePageViewModel
{
    public string? Text { get; set; }
    public ThirdPageViewModel(IScreen hostScreen) : base(hostScreen)
    {
    }
}