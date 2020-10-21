using System;
using System.Collections.Generic;

namespace studio_fun_with_quizzes_7_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Quiz quiz = new Quiz();
            TrueFalse trueFalse = new TrueFalse(true);
            Question question = new Question("Yellow is yellow.", trueFalse);

            quiz.Add(question);

            MultipleChoice multipleChoice = new MultipleChoice(new List<string> { "Hat", "Boots", "Coat", "Pants" }, "Hat" );
            question = new Question("What do you wear on your head?", multipleChoice);
            quiz.Add(question);

            Dictionary<string, bool> things = new Dictionary<string, bool> { { "Hat", true }, { "Boots", false }, { "Coat", false }, { "Pants", true } };
        
            Checkbox checkbox = new Checkbox(things);
            question = new Question("What do I wear on my head?", checkbox);
            quiz.Add(question);

            string result = quiz.Start();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}{result}");
            Console.ResetColor();
        }
    }
}
