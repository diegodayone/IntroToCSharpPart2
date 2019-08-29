using System;
using System.Collections.Generic;
using System.Text;

namespace M5D3
{
    class MovieToMediaItemConverter
    {
        public static MediaItem Convert(MovieSearchResult myMovie, string extra = null)
        {
            return new MediaItem()
            {
                id = myMovie.imdbID,
                mediaType = MediaType.Video,
                image = myMovie.Poster,
                name = myMovie.Title,
                Year = myMovie.Year,
                Extra = extra
            };
        }
    }
}
