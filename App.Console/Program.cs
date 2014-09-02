using App.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating a person...");
            Person mPerson = new Person("Ivo", "Ivanek", 24);
            Console.WriteLine(String.Format("Person {0} created!", mPerson.Fullname));

            mPerson.SelfIntroduce();
            mPerson.Say("Hi!!! Whats up?\nDo you like learning AOP?");
            mPerson.Say("Now I'm going to give a try in counting!");
            mPerson.CountFastToADesiredNumber(2000);

            Console.WriteLine("Read the output/debug window in Visual Studio now! :)");
            Console.ReadLine();
        }
    }
}
