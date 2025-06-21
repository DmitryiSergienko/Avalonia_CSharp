using System;
using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;
using UserControl.ViewModels.Page;

namespace UserControl.ViewModels.Factories;

public class FactoryPageViewModel
{
    private readonly IScreen _screen;
    public Dictionary<Type, IRoutableViewModel> ViewModelByType { get; } = new();

    public FactoryPageViewModel(IScreen screen)
    {
        _screen = screen;
        ViewModelByType.Add(typeof(FirstPageViewModel), new FirstPageViewModel(screen));
        ViewModelByType.Add(typeof(SecondPageViewModel), new SecondPageViewModel(screen));
        ViewModelByType.Add(typeof(ThirdPageViewModel), new ThirdPageViewModel(screen));
    }
    public ReactiveCommand<Unit, IRoutableViewModel> Create<T>() where T : IRoutableViewModel
    {
        var pageViewModel = ViewModelByType[typeof(T)];
        return ReactiveCommand.CreateFromObservable(
            () => _screen.Router.Navigate.Execute(pageViewModel));
    }
}