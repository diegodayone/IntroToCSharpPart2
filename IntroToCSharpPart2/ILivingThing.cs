using System;
using System.Collections.Generic;
using System.Text;

namespace IntroToCSharpPart2
{
    interface ILivingThing
    {
        void Attack(ILivingThing enemy);

        int HP { get; set; }
    }


    interface IDataProvider
    {
        string[] StudentNames();

        int[] StudentVotes();
    }

    public class DatabaseDataProvider : IDataProvider
    {
        public string[] StudentNames()
        {
            //RETRIEVE DATA FROM DATABASE
            throw new NotImplementedException();
        }

        public int[] StudentVotes()
        {
            //RETRIEVE DATA FROM DATABASE
            throw new NotImplementedException();
        }
    }

    public class RemoteStorageProvider : IDataProvider
    {
        public string[] StudentNames()
        {
            throw new NotImplementedException();
        }

        public int[] StudentVotes()
        {
            throw new NotImplementedException();
        }
    }

    public class FileSystemProvider : IDataProvider
    {
        public string[] StudentNames()
        {
            throw new NotImplementedException();
        }

        public int[] StudentVotes()
        {
            throw new NotImplementedException();
        }
    }
}
