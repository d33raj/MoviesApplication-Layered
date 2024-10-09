using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieLibrary.Services
{
    public class MovieSerializer
    {
        static string filePath = @"C:\Users\pc\MonoDotnet\Output\movies.json";
        public static List<Movies> DeserializeMovies()
        {
            if (!File.Exists(filePath))
                return new List<Movies>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                List<Movies> deserialAccounts = JsonSerializer.Deserialize<List<Movies>>(sr.ReadToEnd());
                return deserialAccounts;
            }
        }

        public static void SerializeMovies(List<Movies> movie)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(JsonSerializer.Serialize(movie));
            }
        }
    }
}
