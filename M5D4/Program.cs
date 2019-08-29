using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace M5D4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using(var client = new HttpClient())
            {
                //fetch
                var res = await client.GetStringAsync("http://www.omdbapi.com/?apikey=24ad60e9&s=avengers");
                //.json()
                var movies = JsonConvert.DeserializeObject<MovieSearchResponse>(res);
                foreach(var movie in movies.Search.Where(x => x.Year.Length == 4 && int.Parse(x.Year) >= 2000))
                {
                    Console.WriteLine(movie.Title);
                }
            }
        }
    }
    public class SearchResponse
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }

    public class MovieSearchResponse
    {
        public List<SearchResponse> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }
}
