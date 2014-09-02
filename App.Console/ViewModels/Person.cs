using App.ConsoleApp.AOP;
using App.ConsoleApp.Interfaces;
using System;
using PostSharp.Patterns.Model;

namespace App.ConsoleApp.Models
{
    [NotifyPropertyChanged]
    public class Person : IHuman
    {
        /// <summary>
        /// Creats an empty Person object.
        /// </summary>
        public Person()
        {

        }

        /// <summary>
        /// Creates a new Person object with a name, lastname and age.
        /// </summary>
        /// <param name="fn">Firstname</param>
        /// <param name="ln">Lastname</param>
        /// <param name="a">Age</param>
        public Person(string fn, string ln, int a)
        {
            this.mFirstname = fn;
            this.mLastname = ln;
            this.mAge = a;
        }

        private string mFirstname;

        public string Firstname
        {
            get { return mFirstname; }
            set { mFirstname = value; }
        }

        private string mLastname;

        public string Lastname
        {
            get { return mLastname; }
            set { mLastname = value; }
        }

        private int mAge;

        public int Age
        {
            get { return mAge; }
            set { mAge = value; }
        }

        public string Fullname
        {
            get { return String.Format("{0} {1}", this.mFirstname, this.mLastname); }
        }

        [TraceStartEnd(TracingType.Info, true)]
        public void Say(string message = "")
        {
            if (String.IsNullOrEmpty(message))
                throw new ArgumentException(ExceptionMessages.PersonSay.GetDescription());

            Console.WriteLine(String.Format("Person {0} says: {1}", this.Fullname, message));
        }

        [TraceStartEnd(TracingType.Info, true)]
        public void SelfIntroduce()
        {
            if (String.IsNullOrEmpty(this.Fullname.Trim()))
                throw new NullReferenceException(ExceptionMessages.PersonSelfIntroduce.GetDescription());

            Console.WriteLine(String.Format("Hi, I am {0}!", this.Fullname));
        }

        [TraceStartEnd(TracingType.Info, true)]
        public void CountFastToADesiredNumber(int number)
        {
            if (number == 0)
                throw new ArgumentException(ExceptionMessages.PersonCountFastToADesiredNumber.GetDescription());

            for (int i = 1; i <= number; i++)
                Console.Write(i + "\t");
        }

        public bool GetRichOrDieTrying()
        {
            throw new NotImplementedException("Still trying...");
        }
    }
}
