using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace M5D3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IMediaReader mediaReader = new SongReader();

            //var song = await mediaReader.GetByID("1109731");
            var eminemSongs = await mediaReader.Search("eminem");
            var catalogue = new ArrayMediaWrapper(eminemSongs);

            Console.WriteLine("Current lenght: " + catalogue.List().Length);

            //Add item and test
            var song = await mediaReader.GetByID("2114406");
            catalogue.AddItem(song);
            Console.WriteLine("Current lenght: " + catalogue.List().Length);

            //remove existing item
            var remove1Result = catalogue.RemoveItem(song);
            Console.WriteLine("Current lenght: " + catalogue.List().Length);

            //remove not existing item
            var remove2Result = catalogue.RemoveItem(song);
            Console.WriteLine("Current lenght: " + catalogue.List().Length);


            //var result = await mediaReader.GetByID("tt0241527");
            //var results = await mediaReader.Search("Harry%20Potter");
        }
    }
}
