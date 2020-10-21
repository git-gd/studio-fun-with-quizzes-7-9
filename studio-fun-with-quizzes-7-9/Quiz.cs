using System;
using System.Collections.Generic;

namespace studio_fun_with_quizzes_7_9
{
    public class Quiz
    {
        internal List<Question> Questions = new List<Question>();

        public void Add(Question question)
        {
            // if Question isn't already in the list, add it
            if (!Questions.Contains(question)) Questions.Add(question);
        }

        public void Remove(string question)
        {
            // remove questions
            Console.WriteLine("Not yet implemented");
        }

        public string Start()
        {
            int correct = 0;

            // run the quiz!
            if (Questions.Count < 1) return "There are no questions to quiz. Please add questions.";

            for (int i = 0; i < Questions.Count; i++)
            {
                Questions[i].QuestionUser();

                correct += Questions[i].Answer.TakeInput() ? 1 : 0; // lots of better ways to track correct answers
            }

            return $"You answered {correct} out of {Questions.Count} questions correctly!";
        }
    }
}