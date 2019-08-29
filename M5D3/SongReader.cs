using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace M5D3
{
    class SongReader : IMediaReader
    {
        public async Task<MediaItem> GetByID(string id)
        {
            using(var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "575de39080mshf1f9cab8127c63fp1bcad8jsn113d9f3f814b");
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "deezerdevs-deezer.p.rapidapi.com");
                //add headers for authorization
                var result = await client.GetStringAsync("https://deezerdevs-deezer.p.rapidapi.com/track/" + id);
                //parse it
                var song = JsonConvert.DeserializeObject<SongResponse>(result);
                return SongToMediaItemConverter.Convert(song);
            }
        }

        public async Task<MediaItem[]> Search(string query)
        {
            //https://deezerdevs-deezer.p.rapidapi.com/search?q=eminem
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "575de39080mshf1f9cab8127c63fp1bcad8jsn113d9f3f814b");
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "deezerdevs-deezer.p.rapidapi.com");
                //add headers for authorization
                var result = await client.GetStringAsync("https://deezerdevs-deezer.p.rapidapi.com/search?q=" + query);

                //parse the http response to make it look like a list of MediaItems
                var songs = JsonConvert.DeserializeObject<SearchSongResponse>(result);

                var mediaItems = new MediaItem[songs.data.Count];
                var i = 0;
                foreach(var song in songs.data)
                {
                    mediaItems[i] = SongToMediaItemConverter.Convert(song);
                    i++;
                }

                return mediaItems;
            }
        }
    }
}
