using System;
using System.Collections.Generic;

namespace studio_fun_with_quizzes_7_9
{
    public class MultipleChoice : Answer
    {
        List<string> options;

    string CorrectAnswer;

        public MultipleChoice(List<string> options, string correctAnswer)
        {
            CorrectAnswer = correctAnswer;
            this.options = options;
        }

        public override void ListOptions() 
        {
            Console.WriteLine();
            for (int i=0; i<options.Count; i++)
            {
                Console.WriteLine($"{i} - {options[i]}");
            }
            Console.WriteLine();
        }
        public override bool TakeInput()
        {
            List<string> valid = new List<string>();
            for (int i = 0; i < options.Count; i++)
            {
                valid.Add(i.ToString());
            }

            string input = "";
            do
            {
                Console.Write("Your choice: ");
                input = Console.ReadLine();
            } while (!valid.Contains(input));

            return options[int.Parse(input)] == CorrectAnswer;
        }
    }
}