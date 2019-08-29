using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace M5D3
{
    class SongToMediaItemConverter
    {
        public static MediaItem Convert(SongResponse song)
        {
            return new MediaItem()
            {
                 id = song.id.ToString(),
                 name = song.title,
                 mediaType = MediaType.Music,
                 image = song.album.cover,
                 Extra = JsonConvert.SerializeObject(song)
            };
        }
    }
}
