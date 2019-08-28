using System;
using System.Threading.Tasks;

namespace M5D3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IMediaReader mediaReader = new MovieReader();
            var result = await mediaReader.GetByID("tt0241527");
            var results = await mediaReader.Search("Harry%20Potter");
        }
    }
}
