using System;
using System.Collections.Generic;
using System.Text;

namespace M5D3
{
    class MediaItem
    {
        public string id;
        public string name;
        public string image;
        public MediaType mediaType;
        public int Year;
        public string Extra;
    }

    enum MediaType
    {
        Image, Video, Music
    }
}
