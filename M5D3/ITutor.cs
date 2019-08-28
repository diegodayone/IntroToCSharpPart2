using System;
using System.Collections.Generic;
using System.Text;

namespace M5D3
{
    //An interface cannot be instatiated. We cannot do something like new Tutor();
    interface ITutor
    {
        //In interface we don't need to specify the visibility of the method.
        //whatever we put into the interface SHOULD be public
        void LiveCoding(string subject);
        bool IsAvailFor1on1(DateTime timeframe);
        void AssignHomework(DateTime day);
    }

    class Stefano : ITutor
    {
        public void AssignHomework(DateTime day)
        {
            throw new NotImplementedException();
        }

        public bool IsAvailFor1on1(DateTime timeframe)
        {
            throw new NotImplementedException();
        }

        public void LiveCoding(string subject)
        {
            throw new NotImplementedException();
        }
    }


    class StriveSchool
    {
        public void AddTutor(ITutor tutorToAdd)
        {
            //....
        }
    }

}
