using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;

namespace M5D3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                var myImage = await client.GetByteArrayAsync("http://strive.school/assets/img/Strive-logo_blackbg_nopayoff.png");
                File.WriteAllBytes(@"C:\Users\Diego\Desktop\downloadedLogo.png", myImage);
            }

            //check if file exists
            var fileExist = File.Exists(@"C:\Users\Diego\Desktop\text.txt");
            //reads all lines
            //var lines = File.ReadAllLines(@"C:\Users\Diego\Desktop\text.txt");
            //foreach (var line in lines)
            //{
            //    Console.WriteLine(line);
            //}

            using (var file = File.AppendText(@"C:\Users\Diego\Desktop\text.txt"))
            {
                file.WriteLine("Diego");
                file.WriteLine("Strive School");
            }

                var listOfFiles = Directory.GetFiles(@"C:\Users\Diego\Desktop\", "*.txt");
            foreach (var line in listOfFiles)
            {
                Console.WriteLine(line);
            }

            IMediaReader mediaReader = new SongReader();

            File.Delete(@"C:\Users\Diego\Desktop\eminem.json");

            //var song = await mediaReader.GetByID("1109731");
            var eminemSongs = await mediaReader.Search("eminem");

            //write on my desktop all the songs from eminem
            File.WriteAllText(@"C:\Users\Diego\Desktop\eminem.json", JsonConvert.SerializeObject(eminemSongs));
            

            //Generics + LINQ
            var list = new List<MediaItem>();
            list.AddRange(eminemSongs);

            //exaclty as FILTER in javascript
            var listOfSongs = list.Where(songLoseYouself => songLoseYouself.name == "Lose Yourself");

            //exactly as SOME in javascript (check if an item exists and return true if so)
            var checkIfSongExists = list.Any(x => x.name == "Lose Youself");

            //exacly as slice(0,3)
            var first3Items = list.Take(3);

            //exactly as slice(3,3)
            var second3items = list.Skip(3).Take(3);

            //exactly as map(x => { name =.... )
            var newItems = list.Select(x => new
            {
                name = x.name,
                id = x.id
            });

            var avg = list.Select(x => x.Year).Average();

            //filter().slice(0,3).map(....)
            var songsWith = list.Where(x => x.name.Contains("E"));
            var take3 = songsWith.Take(3);
            var take3withE = take3.Select(x => new
            {
                Name = x.name,
                Year = x.Year
            });

            //filter().slice(0,3).map(....)
            var first5SongsWithE = list.Where(x => x.name.Contains("E")).Take(3).Select(x => new
            {
                Name = x.name,
                Year = x.Year
            });

            //Dictionary contains a key-value pair of the type that you wish
            //creates a dictionary in which the key is a string and the value is a MediaItem
            var dictionary = new Dictionary<string, MediaItem>();
            var dictionaryNames = new Dictionary<string, string>();

            //[item1 , item2, item3...]
            //[ Key 123 => item1, key333 => item2... ]

            //we can iterate the List 'cause it is implementing IEnumerable
            foreach (var songInList in list)
            {
                //we are adding to the dictionary an item with Key = songInList.id and value = songInList
                dictionary.Add(songInList.id, songInList);
                dictionaryNames.Add(songInList.id, songInList.name);
            }

            //we are getting the song with id = "1109731"
            var loseYourself = dictionary["1109731"];




            //Files (easy peasy)



            return;
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
