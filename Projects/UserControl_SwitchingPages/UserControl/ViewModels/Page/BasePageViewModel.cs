using ReactiveUI;

namespace UserControl.ViewModels.Page;

public class BasePageViewModel : ReactiveObject, IRoutableViewModel
{
    public string? UrlPathSegment { get; }
    public IScreen HostScreen { get; }

    public BasePageViewModel(IScreen hostScreen)
    {
        HostScreen = hostScreen;
    }
}