namespace Model;

public class RepositoryMovie
{
    private readonly List<Movie> _movies;

    public RepositoryMovie()
    {
        _movies = new List<Movie>
        {
            new() { Title = "Inception", Year = 2010, Genre = "Science Fiction", Rating = 8.8 },
            new() { Title = "The Godfather", Year = 1972, Genre = "Crime", Rating = 9.2 },
            new() { Title = "The Dark Knight", Year = 2008, Genre = "Action", Rating = 9.0 },
            new() { Title = "Pulp Fiction", Year = 1994, Genre = "Crime", Rating = 8.9 },
            new() { Title = "Schindler's List", Year = 1993, Genre = "Drama", Rating = 8.9 },
            new() { Title = "The Shawshank Redemption", Year = 1994, Genre = "Drama", Rating = 9.3 },
            new() { Title = "Fight Club", Year = 1999, Genre = "Drama", Rating = 8.8 },
            new() { Title = "Forrest Gump", Year = 1994, Genre = "Drama", Rating = 8.8 }
        };
    }
    
    public int Count => _movies.Count;

    public List<Movie> LoadMovies(int page, int countElements)
    {
        return _movies
            .Skip((page - 1) * countElements)
            .Take(countElements)
            .ToList();
    }
}