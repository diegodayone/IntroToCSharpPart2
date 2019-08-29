using System;
using System.Collections.Generic;
using System.Text;

namespace M5D3
{
    public class MovieSearchResult
    {
        public string Title { get; set; }
        public string Year { get; set; }

        public int IntegerYear
        {
            get
            {
                return Year.Contains('–') ? int.Parse(Year.Split('–')[0]) : int.Parse(Year);
            }
        }

        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }

    public class SearchResult
    {
        public List<MovieSearchResult> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }
}
