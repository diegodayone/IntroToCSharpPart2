using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace M5D3
{
    class MovieReader : IMediaReader
    {
        public async Task<MediaItem> GetByID(string id)
        {
            using(var client = new HttpClient())
            {
                var result = await client.GetStringAsync("http://www.omdbapi.com/?apikey=24ad60e9&i=" + id);
                dynamic movie = JsonConvert.DeserializeObject(result);
                return new MediaItem()
                {
                     Extra = result,
                     id = movie.imdbID,
                     mediaType = MediaType.Video,
                     image = movie.Poster,
                     name = movie.Title,
                     Year = movie.Year
                };
            }
        }

        public async Task<MediaItem[]> Search(string query)
        {
            using (var client = new HttpClient()) //we are creating a web client
            {
                //we are querying the apis to search for movies
                var result = await client.GetStringAsync("http://www.omdbapi.com/?apikey=24ad60e9&s=" + query);
                //we are converting the response in an object (on JS was like response.json()) 
                var searchResult = JsonConvert.DeserializeObject<SearchResult>(result);
                //we are creating a new empty array with the size of the search result
                var transformedItems = new MediaItem[searchResult.Search.Count];

                var i = 0; //keeping the count
                foreach(var searchItem in searchResult.Search) //foreach each search result
                {
                    transformedItems[i] = new MediaItem() //we are creating a new Media Item
                    {
                        Extra = result,
                        id = searchItem.imdbID,
                        mediaType = MediaType.Video,
                        image = searchItem.Poster,
                        name = searchItem.Title,
                        Year = searchItem.Year
                    };
                    i++;//keeping the count
                }

                return transformedItems; //return the array with the result
            }
        }
    }
}
