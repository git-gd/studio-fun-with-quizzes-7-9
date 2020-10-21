using System;

namespace studio_fun_with_quizzes_7_9
{
    public class Question
    {
        public string Value { get; }

        public Answer Answer { get; }

        public Question(string value, Answer answer)
        {
            Value = value;
            Answer = answer;
        }

        public void QuestionUser()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{Environment.NewLine}{Value}");
            Console.ResetColor();
            Answer.ListOptions();
        }
    }
}