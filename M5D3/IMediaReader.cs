using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace M5D3
{
    interface IMediaReader
    {
        //- Search, that receives a query and returns an array of MediaItem.The method should be async
        Task<MediaItem[]> Search(string query);

        //- GetByID, that receives a string and returns a MediaItem.The method should be async
        Task<MediaItem> GetByID(string id);
    }
}
