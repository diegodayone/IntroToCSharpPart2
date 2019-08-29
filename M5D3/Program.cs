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
            //Ex1:
            //Use the MovieReader class to extract all the avengers movies.
            //On the list, apply a LINQ filter to obtain only the movies that has been produced in this century
            //# MindTheYear: some of them could have some "not-immediatly-parsable" Year. Try to convert them.
            //–
            //-
            var movieReader = new MovieReader();
            var loadedMovies = movieReader.Load();

            //Ex6:
            //Use Lambda expressions to calculate the average of the release year of a movie

            var average = loadedMovies.Select(x => x.Year).Average();

            //Ex7:
            //Use lambda expressions to get only the 5th and 6th results when available
            // loadedMovies.slice(4,2);
            var av5and6 = loadedMovies.Skip(4).Take(2);

            var avengersMovie = await movieReader.Search("avengers");
            //movieReader.Save(avengersMovie);

            var avengerAfter2000 = avengersMovie.Where(x => x.Year >= 2000);

            //Ex2:
            //Use the MovieReader class to extract all the lord of the rings movies.
            //On the list, apply a LINQ filter to obtain only the items of Type Video and sort them by Year
            var lotr = await movieReader.Search("lord of the rings");
            var onlyMovies = lotr.Where(x => x.mediaType == MediaType.Video)
                                 .OrderByDescending(x => x.Year);

            //OrderByDescending => Z -> A
            //Order => A => Z

            //Ex3:
            //Create a console application that allows the user to choose between Movie and Songs and then a query.
            //The console app will then display the result and every newly entered string will be a filter on the result from the APIs.
            //The result should, in every case, be sorted alphabetically by Name

            //select between movies and music
            Console.WriteLine("Type 1 for search Movies, type 2 for search Music");
            var userSelection = Console.ReadLine();

            //defining an interface reference
            IMediaReader myMediaReader;

            switch (userSelection)
            {
                //assign to the reference a movie reader
                case "1": myMediaReader = new MovieReader(); break;
                //assign to the reference a song reader
                case "2": myMediaReader = new SongReader(); break;
                //explode
                default: throw new Exception("Select 1 or 2");
            }

            //request the user for a query
            Console.WriteLine("Insert your query");
            userSelection = Console.ReadLine();

            //use the mediaReader to search the query & print the result
            var result = await myMediaReader.Search(userSelection);
            foreach(var singleResult in result)
                Console.WriteLine(singleResult.name);
             
            while (true) //forever
            {
                //read a new filter
                Console.WriteLine("Insert your filter");
                userSelection = Console.ReadLine();

                //apply the filter to the result of the previous query
                var toPrint = result.Where(x => x.name.Contains(userSelection))
                     .OrderBy(x => x.name);

                //print it out
                foreach (var singleResult in toPrint)
                    Console.WriteLine(singleResult.name);
            }


        //Ex4:
        //Add to MediaReader a new Method "Save".
        //When the method is invoked, the result should be saved as result.json.
        //Implement the method for both MovieReader and SongReader.

        //Ex5:
        //Add to MediaReader a new Method "Load".
        //When the method is invoked, result.json should be loaded inside of object.
        //Implement the method for both MovieReader and SongReader.

       


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
