using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace studio_fun_with_quizzes_7_9
{
    public class Checkbox : Answer
    {
        Dictionary<string, bool> options; 
        Dictionary<string, bool> answers = new Dictionary<string, bool>();

        public Checkbox(Dictionary<string, bool> options)
        {
            this.options = options;
            
            // default all options as unselected, toggle bool as they are selected/unselected
            foreach (string option in this.options.Keys)
            {
                answers.Add(option, false);
            }
        }

        public void ToggleAnswers(string key)
        {
            // take a string key and toggle its bool value in answers dictionary - this is how we track the user input
            answers[key] = !answers[key];
        }

        public override void ListOptions()
        {
            Console.WriteLine($"NOTE: Multiple answers can be selected.{Environment.NewLine}");

            for (int i = 0; i < options.Count; i++)
            {
                string key = options.ElementAt(i).Key;

                Console.Write($"{i} - ");
                if (answers[key]) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[x] ");
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("[ ] ");
                }
                Console.ResetColor();
                Console.WriteLine($"{key}{Environment.NewLine}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"9 - Submit Choices{Environment.NewLine}");
            Console.ResetColor();
        }

        public override bool TakeInput()
        {
            int input;
            do
            {
                Console.Write("Your choice : ");

                int.TryParse(Console.ReadKey().KeyChar.ToString(), out input);

                if (input >= 0 && input < options.Count())
                {
                    answers[options.Keys.ElementAt(input)] = !answers[options.Keys.ElementAt(input)];
                }

                Console.SetCursorPosition(0, Console.CursorTop - 12);
                this.ListOptions();

            } while (input != 9);

            bool isCorrect = true;

            foreach (string key in options.Keys)
            {
                isCorrect = isCorrect && (options[key] == answers[key]);
            }

            return (isCorrect);
        }
    }
}