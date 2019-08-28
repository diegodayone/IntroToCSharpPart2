using System;

namespace M5D3
{
    class Program
    {
        static void Main(string[] args)
        {
            IMediaReader mediaReader = new MovieReader();
            var result = mediaReader.GetByID("tt0241527").Result;
            var results = mediaReader.Search("Harry%20Potter").Result;
        }
    }
}
