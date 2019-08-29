using System;
using System.Collections.Generic;
using System.Text;

namespace M5D3
{
    class MovieToMediaItemConverter
    {
        public static MediaItem Convert(MovieSearchResult myMovie, string extra = null)
        {
            //var intYear = myMovie.Year.Contains('–') ? int.Parse(myMovie.Year.Split('–')[0]) : int.Parse(myMovie.Year);

            return new MediaItem()
            {
                id = myMovie.imdbID,
                mediaType = MediaType.Video,
                image = myMovie.Poster,
                name = myMovie.Title,
                Year = myMovie.IntegerYear,
                Extra = extra
            };
        }
    }
}
