using Microsoft.VisualStudio.TestTools.UnitTesting;
using studio_fun_with_quizzes_7_9;
using System;
using System.Collections.Generic;

namespace FunWithQuizzesTests
{
    [TestClass]
    public class QuizTests
    {
        [TestMethod]
        public void TrueFalseConstructorTest()
        {
            TrueFalse trueFalse = new TrueFalse(true);
            Assert.AreEqual("True", trueFalse.CorrectAnswer);

            trueFalse = new TrueFalse(false);
            Assert.AreEqual("False", trueFalse.CorrectAnswer);
        }

        [TestMethod]
        public void TrueFalseListOptionsReturnsString()
        {
            TrueFalse trueFalse = new TrueFalse(false);
            Assert.AreEqual($"0 - False{Environment.NewLine}1 - True{Environment.NewLine}", trueFalse.ListOptions());
        }

        [TestMethod]
        public void MultipleChoiceConstructorTest()
        {
            List<string> choices = new List<string> { "Apple", "Banana", "Carrot"};
            MultipleChoice multipleChoice = new MultipleChoice(choices, choices[0]);

            Assert.AreEqual("Apple", multipleChoice.CorrectAnswer);
            Assert.AreEqual($"0 - Apple{Environment.NewLine}1 - Banana{Environment.NewLine}2 - Carrot{Environment.NewLine}", multipleChoice.ListOptions());
        }

        [TestMethod]
        public void CheckBoxConstructorTest()
        {
            Dictionary<string, bool> choices = new Dictionary<string, bool> { { "Apple" , true}, { "Banana", false }, { "Carrot", true } };
            Checkbox checkbox = new Checkbox(choices);

            Assert.AreEqual(true, checkbox.Options["Apple"]);
            Assert.AreEqual(false, checkbox.Options["Banana"]);
            Assert.AreEqual(true, checkbox.Options["Carrot"]);
        }

        [TestMethod]
        public void CheckBoxListOptionsReturnsString()
        {
            Dictionary<string, bool> choices = new Dictionary<string, bool> { { "Apple", true }, { "Banana", false }, { "Carrot", true } };
            Checkbox checkbox = new Checkbox(choices);

            Assert.AreEqual($"NOTE: Multiple answers can be selected.{Environment.NewLine}0 - [ ] Apple{Environment.NewLine}1 - [ ] Banana{Environment.NewLine}2 - [ ] Carrot{Environment.NewLine}9 - Submit Choices{Environment.NewLine}", checkbox.ListOptions());
        }

        [TestMethod]
        public void TestCheckBoxToggleAnswer()
        {
            Dictionary<string, bool> choices = new Dictionary<string, bool> { { "Apple", true }, { "Banana", false }, { "Carrot", true } };
            Checkbox checkbox = new Checkbox(choices);

            checkbox.ToggleAnswers("Banana");

            Assert.AreEqual($"NOTE: Multiple answers can be selected.{Environment.NewLine}0 - [ ] Apple{Environment.NewLine}1 - [x] Banana{Environment.NewLine}2 - [ ] Carrot{Environment.NewLine}9 - Submit Choices{Environment.NewLine}", checkbox.ListOptions());
        }

        [TestMethod]
        public void TestQuestionConstructor()
        {
            TrueFalse trueFalse = new TrueFalse(true);
            Question question = new Question("Dogs have four feet.", trueFalse);

            Assert.AreEqual("Dogs have four feet.", question.Value);
            Assert.AreEqual($"0 - False{Environment.NewLine}1 - True{Environment.NewLine}", question.Answer.ListOptions());
        }

        [TestMethod]
        public void QuestionPrintsErrorWhenListIsEmpty()
        {
            TrueFalse trueFalse = new TrueFalse(true);
            Question question = new Question("Dogs have four feet.", trueFalse);
            Quiz quiz = new Quiz();
            Assert.AreEqual("There are no questions to quiz. Please add questions.", quiz.Start());
        }

    }
}
