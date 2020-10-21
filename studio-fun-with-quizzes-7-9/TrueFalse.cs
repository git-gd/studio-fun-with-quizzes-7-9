using System;
using System.Collections.Generic;

namespace studio_fun_with_quizzes_7_9
{
    public class TrueFalse : Answer
    {
        static readonly List<string> options = new List<string> { "False", "True" };

        public string CorrectAnswer { get; }

        public TrueFalse(bool correctAnswer)
        {
            CorrectAnswer = correctAnswer?"True":"False";
        }

        public override void ListOptions()
        {
            Console.WriteLine($"{Environment.NewLine}0 - False{Environment.NewLine}1 - True{Environment.NewLine}");
        }

        public override bool TakeInput()
        {
            string input = "";
            do
            {
                Console.Write("Your choice: ");
                input = Console.ReadLine();
            } while (input != "0" && input != "1" );

            return options[int.Parse(input)] == CorrectAnswer;
        }
    }
}