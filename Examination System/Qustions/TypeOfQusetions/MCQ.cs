using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Qustions
{
    internal class MCQ : Question
    {
        public MCQ(string headerOfQusetion, string bodyOfQusetion, float mark, Answer[] answersList, Answer rightAnswer) 
        : base(headerOfQusetion, bodyOfQusetion, mark, answersList, rightAnswer)
        {
        }

        #region Method For ( Create MCQ Exam )
        public static MCQ CreateMCQQustion(int QNum)
        {
            Console.WriteLine($"-------- Question {QNum}) [MCQ] --------");
            //Create body of question
            string? body;
            do
            {
                Console.Write("Qustion body : ");
                body = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(body));
            Console.WriteLine("------------------");
            //Declare Choices
            Answer[] answers = new Answer[3];
            for (int i = 0; i < 3; i++)
            {
                string? text;
                do
                {
                    Console.Write($"Enter choice {i + 1} : ");
                    text = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(text));
                answers[i] = new Answer(i + 1, text);
            }
            //Define id of right answer
            Console.Write("\nNumber of right answer: ");
            int correctIndex;
            while (!int.TryParse(Console.ReadLine(), out correctIndex) || correctIndex < 1 || correctIndex > 3) ;
            Answer rightAnswer = answers[correctIndex - 1];
            //Define mark of question
            float mark;
            do
            {
                Console.Write("\nMark of qustion = ");
            } while (!float.TryParse(Console.ReadLine(), out mark) || mark < 0);
            return new MCQ("MCQ", body, mark, answers, rightAnswer);
        }
        #endregion
        #region Method for (Display questions and its choices) 
        public override void ShowQustion()
        {
            Console.Write($"{HeaderOfQusetion}: {BodyOfQusetion}   (Mark: {Mark})");
            foreach (var answer in AnswersList)
                Console.WriteLine(answer);
        } 
        #endregion
    }
}
