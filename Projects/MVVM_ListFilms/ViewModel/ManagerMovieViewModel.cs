using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel;

public class ManagerMovieViewModel : INotifyPropertyChanged
{
    public ObservableCollection<MovieViewModel> Movies { get; set; } = new();
    
    private readonly RepositoryMovie _repositoryMovie = new();
    private readonly MapMovieViewModel _mapMovieViewModel = new();

    private const int CountElements = 3;
    private readonly int _countPage;
    public ManagerMovieViewModel()
    {
        _countPage = (int)Math.Ceiling((double)_repositoryMovie.Count / CountElements);
        _currentPage = 1;
        RefreshMoviesOnPage(_currentPage, CountElements);
    }

    private int _currentPage;
    public int CurrentPage
    {
        get => _currentPage;
        private set
        {
            if (_currentPage != value)
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }
    }
    
    public void ToPreviousPage()
    {
        if (_currentPage < 2)
        {
            return;
        }
        CurrentPage--;
        RefreshMoviesOnPage(_currentPage, CountElements);
    }

    public void ToNextPage()
    {
        if (_currentPage > _countPage - 1)
        {
            return;
        }
        CurrentPage++;
        RefreshMoviesOnPage(_currentPage, CountElements);
    }

    private void RefreshMoviesOnPage(int currentPage, int countElements)
    {
        Movies.Clear();
        var movies = _repositoryMovie.LoadMovies(currentPage, countElements);
        var moviesViewModel = _mapMovieViewModel.Map(movies);
        foreach (var movieViewModel in moviesViewModel)
        {
            Movies.Add(movieViewModel);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}