using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;
using UserControl.ViewModels.Factories;
using UserControl.ViewModels.Page;

namespace UserControl.ViewModels;

public partial class MainWindowViewModel : ReactiveObject, IScreen
{
    public RoutingState Router { get; } = new();
    private readonly FactoryPageViewModel _factoryPageViewModel;
    public ReactiveCommand<Unit, IRoutableViewModel> GoToFirstPage { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> GoToSecondPage { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> GoToThirdPage { get; }
    public ReactiveCommand<Unit, IRoutableViewModel> GoBack { get; }
    private Stack<IRoutableViewModel> currentStack = new();

    public void MyFirstPage()
    {
        currentStack.Push(_factoryPageViewModel.ViewModelByType[typeof(FirstPageViewModel)]);
        GoToFirstPage.Execute();
    }
    public void MySecondPage()
    {
        currentStack.Push(_factoryPageViewModel.ViewModelByType[typeof(SecondPageViewModel)]);
        GoToSecondPage.Execute();
    }
    public void MyThirdPage()
    {
        currentStack.Push(_factoryPageViewModel.ViewModelByType[typeof(ThirdPageViewModel)]);
        GoToThirdPage.Execute();
    }
    public void MyGoBack()
    {
        GoBack.Execute();
    }
    public void GoForward()
    {
        var lastViewModel = currentStack.Pop();
        Router.NavigationStack.Add(lastViewModel);
    }
    public MainWindowViewModel()
    {
        _factoryPageViewModel = new FactoryPageViewModel(this);
        
        GoToFirstPage = _factoryPageViewModel.Create<FirstPageViewModel>();
        GoToSecondPage = _factoryPageViewModel.Create<SecondPageViewModel>();
        GoToThirdPage = _factoryPageViewModel.Create<ThirdPageViewModel>();
        GoBack = Router.NavigateBack;
        
        GoToFirstPage.Execute();
    }
}