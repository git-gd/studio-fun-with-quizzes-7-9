namespace studio_fun_with_quizzes_7_9
{
    public class Option
    {
        public string Value { get; }
        public bool IsCorrect { get; }

        public Option(string value, bool isCorrect)
        {
            Value = value;
            IsCorrect = isCorrect;
        }
    }
}
