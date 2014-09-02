using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ConsoleApp
{
    public enum TracingType
    {
        Info,
        Log,
        Timer
    }

    public enum ExceptionMessages
    {
        [Description("Message is empty! Please enter a message you wish the Person to say.")]
        PersonSay,

        [Description("Property Fullname is empty, please initialize the Person object!")]
        PersonSelfIntroduce,

        [Description("A number can not be 0! Enter a larger number then zero.")]
        PersonCountFastToADesiredNumber
    }
}
