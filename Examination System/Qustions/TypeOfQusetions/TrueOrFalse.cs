using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Qustions
{
    internal class TrueOrFalse : Question
    {
        public TrueOrFalse(string headerOfQusetion, string bodyOfQusetion, float mark, Answer[] answersList, Answer rightAnswer) 
        : base(headerOfQusetion, bodyOfQusetion, mark, answersList, rightAnswer)
        {
        }
        #region Method to (Create T/F question)
        public static TrueOrFalse CreateTFQuestion(int QNum)
        {
            Console.WriteLine($"--- Question {QNum}) [True || False] ---");

            //Create Body of qeustion
            string? body;
            do
            {
                Console.Write("Question body: ");
                body = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(body));
            Console.WriteLine("        --------        ");
            //Declare Mark
            float mark;
            do
            {
                Console.Write("Enter mark of question(Note! >0): ");

            } while (!float.TryParse(Console.ReadLine(), out mark) || mark <= 0);
            Console.WriteLine("        --------        ");
            //Display Choices
            Answer[] answers =
            {
                new Answer(1, "True"),
                new Answer(2, "False")
            };

            //Choose id of Correct Answer
            int correctIndex;
            do
            {
                Console.Write("Enter number of correct answer [ 1)True | 2)False ]: ");
            } while (!int.TryParse(Console.ReadLine(), out correctIndex) || correctIndex < 1 || correctIndex > 2);

            Answer rightAnswer = answers[correctIndex - 1];

            return new TrueOrFalse($"True/False Q{QNum})", body, mark, answers, rightAnswer);
        }
        #endregion

        #region Method for (Display T/F question)
        public override void ShowQustion()
        {
            Console.WriteLine($"{HeaderOfQusetion}: {BodyOfQusetion}  (Mark: {Mark})");
            foreach (var answer in AnswersList)
            {
                Console.WriteLine(answer);
            }
        } 
        #endregion

    }
}
