using MovieLibrary.Controller;
using MovieLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApplication.Presentation
{
    internal class MovieStore
    {
        static MovieManager manager;

        public static void DisplayMovieMenu()
        {
            manager = new MovieManager();

            while (true)
            {
                Console.WriteLine("Welcome to Movies App:\n" + "Select an option from below:\n"
                                  + "1. Add a Movie\n" + "2. Edit a Movie\n" +
                                  "3. Find Movie by ID\n" + "4. FInd Movie by Name\n" +
                                  "5. Display Movies\n" + "6. Remove Movie by ID\n" +
                                  "7. Clear All Movies\n" + "8. Exit\n" + "Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                TasktoDo(choice);
            }
        }

        static void TasktoDo(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddMovies();
                    break;
                case 2:
                    EditMovie();
                    break;
                case 3:
                    FindById();
                    break;
                case 4:
                    FindByName();
                    break;
                case 5:
                    DisplayMovies();
                    break;
                case 6:
                    RemoveById();
                    break;
                case 7:
                    ClearAllMovies();
                    break;
                case 8:
                    manager.SerializeBeforeExit();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Incorrect Choice");
                    break;
            }
        }

        static void AddMovies()
        {
            try
            {
                if (manager.MovieCount() >= 5)
                {
                    Console.WriteLine("The movie list is full. Cannot add more movies.");
                    return;
                }
                Console.WriteLine("Enter Movie ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Movie Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Movie Genre: ");
                string genre = Console.ReadLine();
                Console.WriteLine("Enter Movie Year: ");
                int year = Convert.ToInt32(Console.ReadLine());

                manager.NewMovie(id, name, genre, year);
                Console.WriteLine("Movie added successfully.");
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }

        static void EditMovie()
        {
            try
            {
                Console.WriteLine("Enter Movie ID to Edit: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter New Movie Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter New Movie Genre: ");
                string genre = Console.ReadLine();
                Console.WriteLine("Enter New Movie Year: ");
                int year = Convert.ToInt32(Console.ReadLine());

                manager.Edit(id, name, genre, year);
                Console.WriteLine("Movie Edited Successfully");
            }
            catch (InvalidMovieIdException ex)
            { Console.WriteLine(ex.Message); }
            catch (MovieListEmptyException ex)
            { Console.WriteLine(ex.Message); }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }

        static void FindById()
        {
            try
            {
                Console.WriteLine("Enter Movie ID: ");
                int mid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(manager.GetMovie(mid));
            }
            catch (MovieListEmptyException ex)
            { Console.WriteLine(ex.Message); }
            catch (InvalidMovieIdException ex)
            { Console.WriteLine(ex.Message); }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

        }

        static void FindByName()
        {
            try
            {
                Console.WriteLine("Enter Movie Name: ");
                string name = Console.ReadLine();
                var movie = manager.GetMovieByName(name);
                Console.WriteLine(movie);
            }
            catch (InvalidNameException ex)
            { Console.WriteLine(ex.Message); }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }

        static void DisplayMovies()
        {
            try
            {
                var movies = manager.GetAllMovies();
                Console.WriteLine("Movies List:");
                foreach (var m in movies)
                {
                    Console.WriteLine($"ID: {m.MovieID}, Name: {m.MovieTitle}, Genre: {m.MovieGenre}, Year: {m.MovieYear}\n");
                }
            }
            catch (MovieListEmptyException ex)
            { Console.WriteLine(ex.Message); }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }

        static void RemoveById()
        {
            try
            {
                Console.WriteLine("Enter Movie ID: ");
                int mid = Convert.ToInt32(Console.ReadLine());
                manager.RemoveMovie(mid);
                Console.WriteLine("Movie Removed Successfully");
            }
            catch (MovieListEmptyException ex)
            { Console.WriteLine(ex.Message); }
            catch (InvalidMovieIdException ex)
            { Console.WriteLine(ex.Message); }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

        }

        static void ClearAllMovies()
        {
            manager.ClearAll();
            Console.WriteLine("All movies cleared.");
        }
    }
}
