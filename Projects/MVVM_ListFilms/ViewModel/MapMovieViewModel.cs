using Model;

namespace ViewModel;

public class MapMovieViewModel
{
    public List<MovieViewModel> Map(List<Movie> movies)
    {
        return movies.Select(movie => Map(movie)).ToList();
    }
    
    private MovieViewModel Map(Movie movie)
    {
        return new MovieViewModel
        {
            Title = movie.Title,
            Year = movie.Year,
            Genre = movie.Genre,
            Rating = movie.Rating
        };
    }
}