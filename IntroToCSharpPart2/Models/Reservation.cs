using System;
using System.Collections.Generic;
using System.Text;

namespace IntroToCSharpPart2.Models
{

  
    class Reservation
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public int numberOfPersons { get; set; }
        public bool smoking { get; set; }
        public DateTime dateTime { get; set; }
        public string specialRequests { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int __v { get; set; }

        public string CompleteReservationInfo
        {
            get
            {
                return name + " --> " + dateTime.ToString() + " for " + numberOfPersons;
            }
        }

    //public string get_Name()
    //{
    //    return name;
    //}
    //public void set_Name(string n)
    //{
    //    name = n;
    //}


}
}
