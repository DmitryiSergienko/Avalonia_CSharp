using ReactiveUI;
using UserControl.ViewModels.Page;
using UserControl.Views.Pages;

namespace UserControl.Views.Factories;

public class FactoryPageView : IViewLocator
{
    public IViewFor? ResolveView<T>(T? viewModel, string? contract = null)
    {
        if (viewModel is FirstPageViewModel)
        {
            var firstPage = new FirstPage
            {
                DataContext = viewModel
            };
            
            return firstPage;
        }

        if (viewModel is SecondPageViewModel)
        {
            var secondPage = new SecondPage
            {
                DataContext = viewModel
            };

            return secondPage;
        }
        
        var thirdPage = new ThirdPage
        {
            DataContext = viewModel
        };

        return thirdPage;
    }
}