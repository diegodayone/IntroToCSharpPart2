using System;
using System.Collections.Generic;
using System.Text;

namespace M5D3
{
    interface IMediaWrapper
    {
        //- Add item, receives a MediaItem and return the position
        int AddItem(MediaItem toAdd);
        //- Remove item, receives an ID, if available, removes and return true, otherwise return false
        bool RemoveItem(MediaItem toRemove);
        //- List items, prints all the MediaItems into the array
        MediaItem[] List();
    }
}
