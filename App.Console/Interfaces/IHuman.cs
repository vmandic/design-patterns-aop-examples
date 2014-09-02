namespace App.ConsoleApp.Interfaces
{
    public interface IHuman
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        int Age { get; set; }
        string Fullname { get; }

        void Say(string message = "");

        void SelfIntroduce();

        void CountFastToADesiredNumber(int number);

        bool GetRichOrDieTrying();
    }
}
