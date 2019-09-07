using System;
using System.Net.Http;
using System.Threading.Tasks;
using IntroToCSharpPart2.Models;
using Newtonsoft.Json;

namespace IntroToCSharpPart2
{
    class Program
    {
        //static async Task GetGoogle()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var pippo = await client.GetStringAsync("https://www.google.com");
        //        Console.WriteLine(pippo);
        //    }
        //}

        //static Hero myHero;
        static Arena arena;




        static async Task GetHarryPotterDetails()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic YWRtaW46c3VwZXJzZWNyZXQ=");
                var result = await httpClient.GetAsync("https://strive-school-testing-apis.herokuapp.com/api/reservation");
                if (result.IsSuccessStatusCode)
                {
                    var stringResult = await result.Content.ReadAsStringAsync();

                    //Possibility #1: create a class for the type you expect to receive
                    var reservationsWithClass = JsonConvert.DeserializeObject<Reservation[]>(stringResult);
                    foreach (var resevation in reservationsWithClass)
                        Console.WriteLine(resevation.name + " --> " + resevation.dateTime.ToString());

                    //Possibility #2: use dynamic but be aware that the compiler is not helping you anymore
                    dynamic dynamicReservations = JsonConvert.DeserializeObject(stringResult);
                    foreach(var resevation in dynamicReservations)
                        Console.WriteLine(resevation.name + " --> " + resevation.dateTime.ToString());
                }
                else
                {
                    throw new Exception("Something went wrong!");
                }

                //Creating the object we'll send to the post
                var res = new Reservation()
                {
                     dateTime = DateTime.Now,
                     name = "Luca & Diego",
                     numberOfPersons = 2,
                     phone = "123123123",
                     smoking = false,
                     specialRequests = "We'll speak about unity"
                };

                //Serializing the previously created object to make it available to the httpclient
                var content = new StringContent(JsonConvert.SerializeObject(res), 
                    System.Text.Encoding.UTF8, 
                    "application/json");

                //posting the serialized object to the API
                var newObject = await httpClient.PostAsync("https://strive-school-testing-apis.herokuapp.com/api/reservation"
                    ,content);

                //var newObject2 = await httpClient.PostAsync("https://strive-school-testing-apis.herokuapp.com/api/reservation",
                //    new StringContent(JsonConvert.SerializeObject(new Reservation()
                //    {
                //        dateTime = DateTime.Now,
                //        name = "Luca & Diego",
                //        numberOfPersons = 2,
                //        phone = "123123123",
                //        smoking = false,
                //        specialRequests = "We'll speak about unity"
                //    }),
                //    System.Text.Encoding.UTF8,
                //    "application/json"));
            }
        }


        static void Main(string[] args)
        {
            var mage = SingleTonSomething.Instance;

            mage.CurrentHealthPoint--;

            var gandalf = SingleTonSomething.Instance;
            gandalf.CurrentHealthPoint = 10;

            var whateve123r = new Mage();
            whateve123r.CurrentHealthPoint = 5;

            GetHarryPotterDetails().Wait();


            var mon = new Monster();
            mon.KillSomebody().Wait();


            IDataProvider dataProvider;

            try
            {
                dataProvider = new DatabaseDataProvider();
            }
            catch
            {
                try
                {
                    dataProvider = new RemoteStorageProvider();
                }
                catch
                {
                    dataProvider = new FileSystemProvider();
                }
            }

            var students = dataProvider.StudentNames();
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }










            //GetGoogle().Wait();

            //var myClass = new ICanBeInstantiated();
            //myClass.CompareString("rushita", "ivaldo");


            //MyStringComparer.CompareString("rushita", "rob");


            var monster = new Monster();
            var bard = new Bard("Hansi");

            var livingThingRef = (ILivingThing)bard;

            arena.Fight(bard, monster);

            bard.SpecialAttack();

            var heroKrysz = new Warrior("Krysz");
            heroKrysz.PrintSomething();

            Hero.PrintSomething2();

            try
            {
                //Open File
                //Read File

                new Warrior("whatever").QuitGame();
            }
            catch (NullReferenceException nullReference)
            {
                Console.WriteLine("this code is executed ONLY if a NULL REFERENCE exeption occurs");
                Console.WriteLine(nullReference.Message + nullReference.StackTrace);
            }
            catch (IndexOutOfRangeException indexOutOfRange)
            {
                Console.WriteLine("this code is executed ONLY if a indexOutOfRange exeption occurs");
                Console.WriteLine(indexOutOfRange.Message + indexOutOfRange.StackTrace);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message + exception.StackTrace);
            }
            finally
            {
                //Close File
                Console.WriteLine("this code is executed in any case");
            }

            Console.WriteLine("Welcome to Strive RPG");
            Console.WriteLine("Select your name!");

            var selectedName = Console.ReadLine();

            Hero selectedHero = null;

            while (selectedHero == null)
            {
                Console.WriteLine("Select your class!");
                var selectedClass = Console.ReadLine();
                switch (selectedClass.ToLower())
                {
                    case "warrior":
                        selectedHero = new Warrior(selectedName);
                        break;
                    case "mage":
                        selectedHero = new Mage();
                        break;
                    case "bard":
                        selectedHero = new Bard(selectedName);
                        break;
                    default:
                        Console.WriteLine("Select a valid class");
                        break;
                }
            }

            while (true)
            {
                Console.WriteLine("Perform your attack! 1 for special attack, 2 for normal attack");
                Console.WriteLine(selectedHero.ToString());
                var selectedAttack = Console.Read();
                var number = Convert.ToChar(selectedAttack);

                if (number == '1')
                {
                    selectedHero.Attack(null);
                }
                else if (number == '2')
                {
                    selectedHero.SpecialAttack();
                }
                else
                {
                    Console.WriteLine("Thanks for playing with us");
                    break;
                }
            }


            //select your warrior
            //Hero selectedHero = new Mage();
            //selectedHero.SpecialAttack();
            //selectedHero.Attack();
            //selectedHero.SpecialAttack();
            //selectedHero.SpecialAttack();
            //selectedHero.SpecialAttack();

            //selectedHero = new Warrior("Hercules");
            //selectedHero.SpecialAttack();
            //selectedHero.Attack();
            //selectedHero.SpecialAttack();
            //selectedHero.SpecialAttack();
            //selectedHero.SpecialAttack();

            //var xena = new Warrior("Xena");


            //if (selectedHero.GetType() == typeof(Warrior))
            //{
            //    Console.WriteLine("The warrior is attacking");
            //    //....
            //}
            //else if (selectedHero.GetType() == typeof(Mage))
            //{
            //    Console.WriteLine("The mage is attacking");
            //    //..
            //}
            //else if (selectedHero.GetType() == typeof(Rogue))
            //{
            //    Console.WriteLine("The rogue is attacking");
            //    //..
            //}
            //else if (selectedHero.GetType() == typeof(Necromancer))
            //{
            //    Console.WriteLine("The necro is attacking");
            //    //..
            //}
            return;
            var names = System.IO.File.ReadAllLines("Names.txt");
            foreach(var name in names )
            {
                Console.WriteLine(name);
            }

            int x = 12;

            var myIntegerArray = new[] { 2, 3, 4, 45 };

            for (var i = 0; i < myIntegerArray.Length; i++)
            {
                Console.WriteLine(myIntegerArray[i]);
            }

            foreach(var whatever in myIntegerArray)
            {
                Console.WriteLine(whatever);
            }

            var myArray = new int[10];

            for(var i = 0; i < 10; i++)
            {
                myArray[i] = i;
            }

            //var myArrayWithTwoItems = new string[2];
            //myArrayWithTwoItems[0] = "Strive";
            //myArrayWithTwoItems[1] = "School";
            //var secondArray = new string[] { "Strive", "School" };
            //string[] thirdArray = { "Strive", "School" };
            //var forthArray = new[] { "Strive", "School" };

            /*
             * array1 = [ 0 , 23 , 25 , 20 ] 
             * array[3] =----------^
             * hey, add me an item at the end of the array!
             * 
             * -- find in memory some 5 space to use
             * -- clone the array into this 5 space area
             * -- put in the last the value that you select
             * array1 = [ 0 , 23 , 25 , 20, NewValue ] 
             * 
             * list = [ 0 ---> 2 ---> 25 --> 20 ]
             * 
             * ---------^
             *         item3?
             *         ------->
             *                item3?
             *                -------->
             *                
             * Where is item 3? Search the item is slower
             * 
             * list = [ 0 ---> 2 ---> 25 --> 20 --> newItem ]
             * 
             * */
        }
    }
}
