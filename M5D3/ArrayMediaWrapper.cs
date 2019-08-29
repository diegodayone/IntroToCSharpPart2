using System;
using System.Collections.Generic;
using System.Text;

namespace M5D3
{
    class ArrayMediaWrapper : IMediaWrapper
    {
        MediaItem[] items;

        public ArrayMediaWrapper(MediaItem[] initialItems)
        {
            items = initialItems;
        }

        public int AddItem(MediaItem toAdd)
        {
            //creating a bigger array with 1 extra space
            var biggerArray = new MediaItem[items.Length + 1];
            //copy previous array to new array
            items.CopyTo(biggerArray, 0);
            //putting the new value in the last position of the new array
            biggerArray[items.Length] = toAdd;
            //replacing previous array with new array
            items = biggerArray;
            //return the actual position of the new item
            return items.Length - 1;
        }

        public MediaItem[] List()
        {
            return items;
        }

        public bool RemoveItem(MediaItem toRemove)
        {
            //check if in the array we have one item with the same ID
            var toDelete = -1;
            for (var i = 0; i < items.Length; i++)
                if (items[i].id == toRemove.id)
                    toDelete = i;

            //if we don't find it, return false
            if (toDelete == -1) return false;

            //create a smaller array
            var newArray = new MediaItem[items.Length - 1];
            var currentItem = 0;
            //for each item of the previous array
            for(var i = 0; i < items.Length; i++)
            {
                if (toDelete != i) //if it's not the one to be deleted
                {
                    newArray[currentItem] = items[i]; //add it
                    currentItem++;
                }
            }
            items = newArray; //swap arrays

            return true; 
        }
    }
}
