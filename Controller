using MovieLibrary.Exceptions;
using MovieLibrary.Models;
using MovieLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Controller
{
    public class MovieManager
    {
        static List<Movies> movie = new List<Movies>();
        public int movieIndex = 0;

        public MovieManager()
        {
            movie = MovieSerializer.DeserializeMovies();
            movieIndex = MovieCount();
        }

        public int MovieCount()
        {
            return movie.Count;
        }

        public Movies GetMovie(int mid)
        {
            if (movie.Count() == 0)
            { throw new MovieListEmptyException("No Movie in the List. Create a new movie first."); }
            var movies = movie.Find(m => m.MovieID == mid);
            if (movies == null)
            { throw new InvalidMovieIdException("No movie found with given ID."); }
            return movies;

        }

        public List<Movies> GetAllMovies()
        {
            if (movie.Count() == 0)
            {
                throw new MovieListEmptyException("No Movie in the List. Create a new movie first.");
            }
            return movie;
        }

        public void NewMovie(int id, string name, string genre, int year)
        {
            var newMovie = new Movies(id, name, genre, year);
            movie.Add(newMovie);
            movieIndex++;
        }

        public void ClearAll()
        {
            movie.Clear();
            movieIndex = 0;
        }

        public void RemoveMovie(int id)
        {
            if (movie.Count() == 0)
            { throw new MovieListEmptyException("No Movie in the List. Create a new movie first."); }
            var movieId = GetMovie(id);
            if (movieId == null)
            { throw new InvalidMovieIdException("No movie found with given ID."); }
            movie.Remove(movieId);
            movieIndex--;
        }

        public void Edit(int id, string newName, string newGenre, int newYear)
        {
            if (movie.Count() == 0)
            { throw new MovieListEmptyException("No Movie in the List. Create a new movie first."); }
            var movies = movie.Find(m => m.MovieID == id);
            if (movies == null)
            { throw new InvalidMovieIdException("No movie found with given ID."); }
            var movieId = GetMovie(id);
            movieId.MovieTitle = newName;
            movieId.MovieGenre = newGenre;
            movieId.MovieYear = newYear;
        }

        public Movies GetMovieByName(string name)
        {
            if (movie.Count() == 0)
            { throw new MovieListEmptyException("No Movie in the List. Create a new movie first."); }
            string lowerCaseName = name.ToLower();
            var movies = movie.Find(m => m.MovieTitle.ToLower().Equals(lowerCaseName));
            if (movies == null)
            { throw new InvalidNameException("No Movie found with given name. Ensure you enter correct Name."); }
            return movies;
        }

        public void SerializeBeforeExit()
        {
            MovieSerializer.SerializeMovies(movie);
        }
    }
}
